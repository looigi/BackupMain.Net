Imports System.Globalization
Imports System.IO
Imports System.Text
Imports BackupMain.NET.OperazioniSuFile
Imports Ionic.Zip
Imports OperazioniSuFile

Module mdlGenerale
	Public UltimaOperazione As String = ""
	Public NotifyIcon1 As NotifyIcon = New NotifyIcon
	Public UtenzaMail As String
	Public PasswordMail As String
	Public PercorsoDBTemp As String

	Public ModalitaEsecuzioneAutomatica As Boolean
	'Public MascheraProcedura() As frmProcedura
	'Public qMaschereProcedura As Integer = 0

	'Public MascheraEsecuzione() As frmEsecuzione
	'Public qMaschereEsecuzione As Integer = 0

	Public NomeProceduraScelta As String
	Public InEsecuzione As Boolean = False

	'Public Enum TipoOperazione
	'    Nulla = 0
	'    Copia = 1
	'    Spostamento = 2
	'    Sincronizzazione = 3
	'    Eliminazione = 4
	'    CreaDirectory = 5
	'    EliminaDirectory = 6
	'    RiavvioPC = 7
	'    AvvioServizio = 8
	'    FermaServizio = 9
	'    AvviaEseguibile = 10
	'    FermaEseguibile = 11
	'    Attendi = 12
	'    SincroniaIntelligente = 13
	'    Zip = 14
	'End Enum

	Public Enum StrutturaTabella
		idProc = 0
		Progressivo = 1
		idOperazione = 2
		Origine = 3
		Destinazione = 4
		Sovrascrivi = 5
		Sottodirectory = 6
		Filtro = 7
		Parametro = 8
		UtenzaOrigine = 9
		PasswordOrigine = 10
		UtenzaDestinazione = 11
		PasswordDestinazione = 12
		Attivo = 13
		ListaFile = 14
		Messaggio = 15
	End Enum

	Public Function FormattaNumero(Numero As Single, ConVirgola As Boolean, Optional Lunghezza As Integer = -1) As String
		Dim Ritorno As String
		Dim Formattazione As String

		Select Case ConVirgola
			Case True
				Formattazione = "0,000.00"
			Case False
				Formattazione = "0,000"
			Case Else
				Formattazione = "0"
		End Select

		Ritorno = Numero.ToString(Formattazione, CultureInfo.InvariantCulture)

		Do While Left(Ritorno, 1) = "0"
			Ritorno = Mid(Ritorno, 2, Ritorno.Length)
		Loop
		If ConVirgola = True Then
			If Left(Ritorno.Trim, 1) = "." Then
				Ritorno = "0" & Ritorno
			End If
		Else
			If Left(Ritorno.Trim, 1) = "," Then
				Ritorno = Mid(Ritorno, 2, Ritorno.Length)
				For i As Integer = 1 To Ritorno.Length
					If Mid(Ritorno, i, 1) = "0" Then
						Ritorno = Mid(Ritorno, 1, i - 1) & "*" & Mid(Ritorno, i + 1, Ritorno.Length)
					Else
						Exit For
					End If
				Next
				Ritorno = Ritorno.Replace("*", "")
				If Ritorno = "" Then Ritorno = "0"
			End If
		End If

		Ritorno = Ritorno.Replace(",", "+")
		Ritorno = Ritorno.Replace(".", ",")
		Ritorno = Ritorno.Replace("+", ".")

		If Ritorno = ".000" Then
			Ritorno = "0"
		End If

		If Lunghezza <> -1 Then
			Dim Spazi As String = ""

			If Ritorno.Length < Lunghezza Then
				For i As Integer = 1 To Lunghezza - Ritorno.Length
					Spazi += " "
				Next
				Ritorno = Spazi & Ritorno
			End If
		End If

		Return Ritorno
	End Function

	Public Function SistemaLunghezzaCampo(Campo As String, Lunghezza As String) As String
		Dim Ritorno As String = Campo.Trim

		If Ritorno.Length < Lunghezza Then
			For i As Integer = Ritorno.Length To Lunghezza
				Ritorno = Ritorno & " "
			Next
		Else
			Ritorno = Mid(Ritorno, 1, (Lunghezza / 2)) & "..." & Mid(Ritorno, Ritorno.Length - (Lunghezza / 2), Lunghezza)
		End If

		Return Ritorno
	End Function


	Public Function PrendeDataOra() As String
		Dim Ritorno As String = Format(Now.Day, "00") & " / " & Format(Now.Month, "00") & " / " & Now.Year & " " & Format(Now.Hour, "00") & ":" & Format(Now.Minute, "00") & ":" & Format(Now.Second, "00")

		Return Ritorno
	End Function

	Public Function EliminaFilesVecchi(Instance As Form) As Integer
		Dim Quanti As Integer = 0
		Dim gf As New GestioneFilesDirectory
		gf.ScansionaDirectorySingola("C:\BackupLog", Instance)
		Dim Filetti() As String = gf.RitornaFilesRilevati
		Dim qFiletti As Integer = gf.RitornaQuantiFilesRilevati
		Dim d As Date = Now
		Dim g As String = d.Day.ToString.Trim
		Dim m As String = d.Month.ToString.Trim
		Dim h As String = d.Hour.ToString.Trim
		Dim mm As String = d.Minute.ToString.Trim
		Dim s As String = d.Second.ToString.Trim
		If g.Length = 1 Then g = "0" & g
		If m.Length = 1 Then m = "0" & m
		If h.Length = 1 Then h = "0" & h
		If mm.Length = 1 Then mm = "0" & mm
		If s.Length = 1 Then s = "0" & s
		Dim df As String = d.Year & m & g & h & mm & s
		Dim Destinazione As String = "C:\BackupLog\Archivio_" & df & ".zip"
		Dim f As New List(Of String)

		'Using zip As New ZipFile()
		Dim zip As New ZipFile()
		Dim FileZippante As ZipEntry

		If qFiletti > 60000 Then
			zip.UseZip64WhenSaving = Zip64Option.Always
		End If
		zip.ParallelDeflateThreshold = -1

		For i As Integer = 1 To qFiletti
			If Not Filetti(i).Contains("Config\") And Not Filetti(i).Contains("Dati\") And Not Filetti(i).Contains("Servizio.txt") And Not Filetti(i).Contains("MAIL.log") Then
				Dim datellaFile As Date = FileDateTime(Filetti(i))
				Dim days As Integer = DateDiff(DateInterval.Day, datellaFile, Now)
				If days > 15 Then
					Quanti += 1
					FileZippante = zip.AddFile(Filetti(i))
					f.Add(Filetti(i))
				End If
			End If
		Next

		If Quanti > 0 Then
			zip.Save(Destinazione)
		End If
		'End Using
		zip = Nothing

		For Each ff As String In f
			File.Delete(ff)
		Next
		gf = Nothing

		Return Quanti
	End Function

	Private Function ProvaACreareFile(Lettera As String) As String
		Dim Ritorno As String = ""

		If Lettera <> "C:" And Lettera.Trim <> "" Then
			Dim gf As New GestioneFilesDirectory
			Dim Lettera2 As String = Lettera
			If Not Lettera2.EndsWith("\") Then
				Lettera2 &= "\"
			End If
			gf.CreaDirectoryDaPercorso(Lettera2)

			Dim Path As String = Lettera & "\Buttami.txt"

			Try
				Dim fs As FileStream = File.Create(Path)

				' Add text to the file.
				Dim info As Byte() = New UTF8Encoding(True).GetBytes("ppp")
				fs.Write(info, 0, info.Length)
				fs.Close()
			Catch ex As Exception
				Ritorno = ex.Message
			End Try

			If Ritorno = "" Then
				Dim Stringa As String = gf.LeggeFileIntero(Path)
				If Stringa <> "ppp" Then
					Ritorno = "Errore in fase di lettura disco"
				End If
			Else
			End If

			Try
				Kill(Path)
			Catch ex As Exception

			End Try

			gf = Nothing
		End If

		Return Ritorno
	End Function

	Public Function ControllaDischi(idProc As Integer, clLog As LogCasareccio.LogCasareccio.Logger, txtNomeProcedura As TextBox, lstOperazioni As ListBox) As Boolean
		Dim Ok As Boolean = True
		Dim Db As New GestioneACCESS
		Dim ConnSQL As New ADODB.Connection

		clLog.ScriveLogServizio("Controllo esistenza dischi: apertura db")
		If Db.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			Db.ApreDB(idProc, clLog)

			Dim Rec(,) As String
            Dim opFile As New OperazioniSuFile
            clLog.ScriveLogServizio("Controllo esistenza dischi: caricamento righe procedura")
            idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, txtNomeProcedura.Text, lstOperazioni, clLog)
            Rec = opFile.TornaRecordsetRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, idProc, clLog)
            Dim Ancora As Boolean = True
            Dim Riga As Integer = 0
            Dim gf As New GestioneFilesDirectory

            Do While Ancora
                Dim Origine As String = Rec(Riga, StrutturaTabella.Origine)
                Dim Destinazione As String = Rec(Riga, StrutturaTabella.Destinazione)
                Dim OrigineCompleta As String = Origine
                Dim DestinazioneCompleta As String = Destinazione
                Dim Attivo As String = Rec(Riga, StrutturaTabella.Attivo)

                If Attivo = "S" Then
                    If OrigineCompleta.Contains(".") Then
                        OrigineCompleta = gf.TornaNomeDirectoryDaPath(OrigineCompleta)
                    End If

                    If DestinazioneCompleta.Contains(".") Then
                        DestinazioneCompleta = gf.TornaNomeDirectoryDaPath(DestinazioneCompleta)
                    End If

                    Origine = Mid(Origine, 1, 1)
                    Destinazione = Mid(Destinazione, 1, 1)

                    Dim OkVai As Boolean = True

                    If Rec(Riga, StrutturaTabella.idOperazione) = TipoOperazione.EsegueSQL Then
                        ' In caso di script sql non esegue il controllo sui dischi
                        OkVai = False
                    End If

                    If OkVai Then
                        If Not ControllaNomeDisco(Origine, OrigineCompleta, opFile, clLog, "Origine") Then
                            Exit Do
                        End If

                        'If Origine <> "\" Then
                        '    clLog.ScriveLogServizio("Controllo esistenza dischi: controllo origine " & Origine)

                        '    Dim Lettera As String = opFile.EsisteLetteraDisco(Origine)
                        '    If Lettera = "" Then
                        '        If ModalitaEsecuzioneAutomatica Then
                        '            clLog.ScriveLogServizio("Errore disco " & Origine & " non presente")
                        '            Ok = False
                        '            Exit Do
                        '        Else
                        '            MsgBox("Errore disco " & Origine & " non presente", MsgBoxStyle.Exclamation)
                        '            Ok = False
                        '            Exit Do
                        '        End If
                        '    Else
                        '        If Origine.Trim <> "" Then
                        '            clLog.ScriveLogServizio("Controllo esistenza dischi: prova permessi di scrittura " & OrigineCompleta & ":")

                        '            Dim Ritorno As String = ProvaACreareFile(OrigineCompleta)
                        '            If Ritorno <> "" Then
                        '                If ModalitaEsecuzioneAutomatica Then
                        '                    clLog.ScriveLogServizio("Errore su cartella origine (" & OrigineCompleta & "): " & vbCrLf & vbCrLf & Ritorno)
                        '                    Ok = False
                        '                    Exit Do
                        '                Else
                        '                    MsgBox("Errore su cartella origine (" & OrigineCompleta & "): " & vbCrLf & vbCrLf & Ritorno, MsgBoxStyle.Exclamation)
                        '                    Ok = False
                        '                    Exit Do
                        '                End If
                        '            End If
                        '        End If
                        '    End If
                        'End If

                        If Not ControllaNomeDisco(Destinazione, DestinazioneCompleta, opFile, clLog, "Destinazione") Then
                            Exit Do
                        End If

                        'If Destinazione <> "\" Then
                        '    clLog.ScriveLogServizio("Controllo esistenza dischi: controllo destinazione " & Origine)

                        '    Dim Lettera As String = opFile.EsisteLetteraDisco(Destinazione)
                        '    If Lettera = "" Then
                        '        If ModalitaEsecuzioneAutomatica Then
                        '            clLog.ScriveLogServizio("Errore disco " & Origine & " non presente")
                        '            Ok = False
                        '            Exit Do
                        '        Else
                        '            MsgBox("Errore disco " & Destinazione & " non presente", MsgBoxStyle.Exclamation)
                        '            Ok = False
                        '            Exit Do
                        '        End If
                        '    Else
                        '        If Destinazione.Trim <> "" Then
                        '            clLog.ScriveLogServizio("Controllo esistenza dischi: prova permessi di scrittura " & DestinazioneCompleta & ":")

                        '            Dim Ritorno As String = ProvaACreareFile(DestinazioneCompleta)
                        '            If Ritorno <> "" Then
                        '                If ModalitaEsecuzioneAutomatica Then
                        '                    clLog.ScriveLogServizio("Errore su cartella destinazione (" & DestinazioneCompleta & "): " & vbCrLf & vbCrLf & Ritorno)
                        '                    Ok = False
                        '                    Exit Do
                        '                Else
                        '                    MsgBox("Errore su cartella destinazione (" & DestinazioneCompleta & "): " & vbCrLf & vbCrLf & Ritorno, MsgBoxStyle.Exclamation)
                        '                    Ok = False
                        '                    Exit Do
                        '                End If
                        '            End If
                        '        End If
                        '    End If
                        'End If
                    End If
                End If

                If Rec(Riga + 1, StrutturaTabella.idProc) = "***" Then
                    Ancora = False
                Else
                    Riga += 1
                End If
            Loop

            opFile = Nothing

			Db.ChiudeDB(True)
		End If
        clLog.ScriveLogServizio("Controllo esistenza dischi: " & Ok)

        Return Ok
    End Function

    Public Function ControllaNomeDisco(Origine As String, OrigineCompleta As String, opFile As OperazioniSuFile, clLog As LogCasareccio.LogCasareccio.Logger, Tipo As String) As Boolean
        Dim Ok As Boolean = True

        If Origine <> "\" Then
            clLog.ScriveLogServizio("Controllo esistenza dischi: controllo " & Tipo & " " & Origine)

            Dim Lettera As String = opFile.EsisteLetteraDisco(Origine)
            If Lettera = "" Then
                If ModalitaEsecuzioneAutomatica Then
                    clLog.ScriveLogServizio("Errore disco " & Tipo & ": " & Origine & " non presente")
                    Ok = False
                Else
                    ' MsgBox("Errore disco " & Tipo & ": " & Origine & " non presente", MsgBoxStyle.Exclamation)
                    Ok = False
                End If
            Else
                If Origine.Trim <> "" Then
                    clLog.ScriveLogServizio("Controllo esistenza dischi: prova permessi di scrittura " & Tipo & ": " & OrigineCompleta & ":")

                    Dim Ritorno As String = ProvaACreareFile(OrigineCompleta)
                    If Ritorno <> "" Then
                        If ModalitaEsecuzioneAutomatica Then
                            clLog.ScriveLogServizio("Errore su cartella " & Tipo & " (" & OrigineCompleta & "): " & vbCrLf & vbCrLf & Ritorno)
                            Ok = False
                        Else
                            ' MsgBox("Errore su cartella " & Tipo & " (" & OrigineCompleta & "): " & vbCrLf & vbCrLf & Ritorno, MsgBoxStyle.Exclamation)
                            Ok = False
                        End If
                    End If
                End If
            End If
        End If

        Return Ok
    End Function
End Module
