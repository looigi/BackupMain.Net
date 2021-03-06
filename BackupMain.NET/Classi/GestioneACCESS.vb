﻿Imports System.Windows.Forms
Imports System.IO
Imports Log

Public Class GestioneACCESS
    Private Connessione As String
	Private Conn As ADODB.Connection

	Public Function ProvaConnessione() As String
		Try
			Conn.Open(Connessione)
			Conn.Close()
			Conn.Dispose()
			Conn = Nothing
			Return ""
		Catch ex As Exception

			Return ex.Message
        End Try
    End Function

	Public Function LeggeImpostazioniDiBase(ModalitaAutomatica As Boolean, PercorsoDBTemp As String, Chiave As String,
											Optional TipoDbPassato As Integer = -1, Optional clLog As Object = Nothing,
											Optional DbTemp As Boolean = False) As Boolean
		Dim PercorsoDB As String
		Dim connectionString As String = ""

		If ModalitaAutomatica Then
			PercorsoDB = PercorsoDBTemp
			' connectionString = "Data Source=" & PercorsoDB & ";"
			If DbTemp Or PercorsoDB.ToUpper.Contains(".MDB") Then
				connectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & PercorsoDB
				' Connessione = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;" & connectionString
			Else
				connectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & PercorsoDB & "\DB\dbBackup.mdb;"
				' Connessione = "Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;" & connectionString
			End If
			Connessione = "Persist Security Info=False;" & connectionString & ";pooling=false;"

			If Not clLog Is Nothing Then
				clLog.ScriveLogServizio("Lettura impostazioni di base per modalità automatica: " & Connessione)
			End If
		Else
			PercorsoDB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "PathDB", "")

			If PercorsoDB = "" Then
				Dim gf As New GestioneFilesDirectory
				gf.CreaAggiornaFile("D:\Errore.txt", "ERRORE: Path DB Non trovato")
				gf = Nothing
				Stop
			End If

			If Not clLog Is Nothing Then
				clLog.ScriveLogServizio("Lettura impostazioni di base per modalità NON automatica 1: " & TipoDbPassato)
			End If

			Select Case TipoDbPassato
				Case 1
					DBSql = TipoDB.Access
				Case 2
					DBSql = TipoDB.SQLCE
				Case -1
					ImpostaDBSqlAccess()
			End Select

			Select Case DBSql
				Case TipoDB.Access
					' connectionString = "Data Source=" & PercorsoDB & "\DB\dbBackup.mdb;"
					connectionString = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & PercorsoDB & "\DB\dbBackup.mdb;"

					Connessione = "Persist Security Info=False;" & connectionString & ";Pooling=False;"
				Case TipoDB.SQLCE
					connectionString = "Data Source=" & PercorsoDB & "\DB\dbBackup.sdf;"
					Connessione = "Provider=Microsoft.SQLSERVER.CE.OLEDB.4.0;" & connectionString
				Case TipoDB.Niente
					Stop
			End Select

			If Not clLog Is Nothing Then
				clLog.ScriveLogServizio("Lettura impostazioni di base per modalità NON automatica 2: " & connectionString)
				clLog.ScriveLogServizio("                                                          : " & Connessione)
			End If
		End If

		Return True
	End Function

	Public Sub ApreDB(idProc As Integer, clLog As LogCasareccio.LogCasareccio.Logger) ' As Object
		' Routine che apre il DB e vede se ci sono errori

		Conn = New ADODB.Connection()
		Try
			Conn.Open(Connessione)
			Conn.CommandTimeout = 0
		Catch ex As Exception
			'MsgBox(ex.Message)
			If Not clLog Is Nothing Then
				clLog.ScriveLogServizio("ERRORE SU CONNESSIONE:" & Connessione)
				ScriveErrore(idProc, ex.Message, clLog)
			End If
		End Try

		' Return Conn
	End Sub

	Private Sub ScriveErrore(idProc As Integer, Errore As String, cllog As LogCasareccio.LogCasareccio.Logger)
        If Not cllog Is Nothing Then
            ScriveLog(idProc, "ERRORE " & Errore, cllog)
        End If
    End Sub

    Private Function ControllaAperturaConnessione(idProc As Integer, ByRef Conn As Object, clLog As LogCasareccio.LogCasareccio.Logger) As Boolean
        Dim Ritorno As Boolean = False

        If Conn Is Nothing Then
            Ritorno = True
			ApreDB(idProc, clLog)
		End If

        Return Ritorno
    End Function

	Public Function EsegueSql(idProc As Integer, ByVal Sql As String, clLog As LogCasareccio.LogCasareccio.Logger) As String
		Dim AperturaManuale As Boolean = ControllaAperturaConnessione(idProc, Conn, clLog)
		Dim Ritorno As Boolean = True
		Dim Errore As String = ""

		' Routine che esegue una query sul db
		Try
			Conn.Execute(Sql)
		Catch ex As Exception
			If Not clLog Is Nothing Then
				ScriveErrore(idProc, "ERRORE in EsegueSQL: " & Sql & " -> " & ex.Message, clLog)
			End If
			Ritorno = False
		End Try

		ChiudeDB(AperturaManuale)

		Return Ritorno
	End Function

	Public Function EsegueSqlSenzaTRY(idProc As Integer, ByVal Sql As String, clLog As LogCasareccio.LogCasareccio.Logger) As String
		Dim AperturaManuale As Boolean = ControllaAperturaConnessione(idProc, Conn, clLog)
		Dim Ritorno As Boolean = True
		Dim Errore As String = ""

		' Routine che esegue una query sul db senza controllo degli errori
		Conn.Execute(Sql)

		ChiudeDB(AperturaManuale)

		Return Ritorno
	End Function

	Public Sub ChiudeDB(ByVal TipoApertura As Boolean)
		If TipoApertura = True Then
			If Not Conn Is Nothing Then
				Conn.Close()
				Conn = Nothing
			End If
		End If
	End Sub

	Public Function LeggeQuery(idProc As Integer, ByVal Sql As String, clLog As LogCasareccio.LogCasareccio.Logger) As Object
		Dim AperturaManuale As Boolean = ControllaAperturaConnessione(idProc, Conn, clLog)
		Dim Rec As New ADODB.Recordset
		Dim Mess As String = ""
		Dim Conta As Integer = 0

		Do While Mess = "" Or Mess.Contains("CONNESSIONE CHIUSA O")
			Try
				Rec.Open(Sql, Conn)
				Mess = "OK"
			Catch ex As Exception
				Mess = ex.Message.ToUpper
				If Mess.Contains("CONNESSIONE CHIUSA O") Then
					System.Threading.Thread.Sleep(2000)
					Conta += 1
					If Conta = 5 Then
						Mess = "KO"
					Else
						ApreDB(idProc, clLog)
						Rec = New ADODB.Recordset
					End If
				Else
					Rec = Nothing
				End If

				If Not clLog Is Nothing Then
					ScriveErrore(idProc, "ERRORE in LeggeQuery:" & Sql & " -> " & ex.Message, clLog)
				End If
			End Try
		Loop

		ChiudeDB(AperturaManuale)

		Return Rec
	End Function

	Public Sub CompattazioneDb()
        ' RICORDARSI DI INCLUDERE LE JRO... 
        ' Microsoft Jet and Replication Objects 2.6 Library
        ' per la compattazione e...
        ' RICORDARSI CHE LA LIBRERIA FUNZIONA SOLO X86

        Dim PercorsoDB As String

        PercorsoDB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "PathDB", "")

        If PercorsoDB = "" Then
            Dim gf As New GestioneFilesDirectory
            gf.CreaAggiornaFile("D:\Errore.txt", "ERRORE: Path DB Non trovato")
            gf = Nothing
            Stop
        End If

        Dim JRO As JRO.JetEngine
        JRO = New JRO.JetEngine

        Dim NomeDB As String = PercorsoDB & "\DB\dbBackup.mdb"
        Dim NomeCompactDB As String = PercorsoDB & "\DB\dbBackupCOMP.mdb"

        Dim source As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & NomeDB & ";"
        Dim compact As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & NomeCompactDB & ";"

        Try
            JRO.CompactDatabase(source, compact)

            System.IO.File.Delete(NomeDB)

            System.IO.File.Move(NomeCompactDB, NomeDB)
        Catch ex As Exception
			' MsgBox("Problema nella compattazione del db:" & vbCrLf & vbCrLf & ex.Message, vbExclamation)
		End Try
    End Sub
End Class
