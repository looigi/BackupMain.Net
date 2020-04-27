Imports OperazioniSuFile
Imports System.Text
Imports System.IO
Imports System.Threading
Imports frmLog
Imports OperazioniSuFile
Imports BackupMain.NET.OperazioniSuFile

Public Class frmEsecuzione
	Private NomeProcedura As String
	Private NomeFileLog As String
	Private Rec(,) As String
	Private idProc As Integer
	'Private NomeFileDiLog As String
	Private log As StringBuilder
	Private clLog As LogCasareccio.LogCasareccio.Logger
	Private opeFileGlobale As OperazioniSuFile
	Private Blocca As Boolean = False
	Private Skippa As Boolean = False
	Private InPausa As Boolean = False
	Private InvioMail As String = "N"
	Private Riga As Integer
	Private idMaschera As Integer

	Private Sub frmEsecuzione_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		'Try
		'    MascheraEsecuzione(idMaschera) = Nothing
		'Catch ex As Exception

		'End Try
	End Sub

	Public Sub ImpostaNomeProcedura(NFileLog As String, Nome As String, NumeroMaschera As Integer, opFile As OperazioniSuFile, clL As LogCasareccio.LogCasareccio.Logger)
		idMaschera = NumeroMaschera
		opeFileGlobale = opFile
		clLog = clL

		Timer1.Enabled = False

		NomeProcedura = Nome
		lblNomeProc.Text = Nome
		NomeFileLog = NFileLog

		clLog.ScriveLogServizio("Caricamento righe procedura")
		idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, Nome, lstOperazioni)
		clLog.ScriveLogServizio("Caricamento recordset procedura. Percorso Db Temp: " & PercorsoDBTemp)
		Rec = opFile.TornaRecordsetRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, idProc, clLog, True)

		clLog.ScriveLogServizio("Caricamento dettagli righe operazioni procedura")
		Dim Campi As String = opFile.CaricaDatiProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, idProc, clLog)
		If Campi.Contains(";") Then
			Dim CampiInterni() As String = Campi.Split(";")
			InvioMail = Campi(0)
		End If

		log = New StringBuilder
		log.Append("Inizio log: " & PrendeDataOra() & vbCrLf)

		'Dim NomeFileUltimaOperazione As String = Application.StartupPath & "\UltimaOperazione.txt"
		'Dim gf As New GestioneFilesDirectory
		'gf.EliminaFileFisico(NomeFileUltimaOperazione)
		'gf = Nothing

		PulisceFileDiLog()

		Riga = 0

		Timer1.Enabled = True
		InEsecuzione = True

		'If ModalitaEsecuzioneAutomatica Then
		'End If

		'Me.Show()
	End Sub

	Private Sub PulisceFileDiLog()
		'Dim DB As New GestioneACCESS

		'If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp , "ConnDB") = True Then
		'    Db.ApreDB(idProc)
		'    Dim Sql As String = "Delete From LogOperazioni Where idProc=" & idProc

		'    DB.EsegueSql(idProc, Sql)
		'    DB.ChiudeDB(True, ConnSQL)
		'End If

		'DB = Nothing
	End Sub

	Private Sub frmEsecuzione_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		If InEsecuzione Then
			e.Cancel = True
		Else
			If ModalitaEsecuzioneAutomatica Then
				Try
					File.Delete(PercorsoDBTemp)
				Catch ex As Exception

				End Try

				NotifyIcon1.Visible = False

				End
			Else
				frmProcedura.ImpostaNomeProcedura(NomeProceduraScelta, idMaschera)
				frmProcedura.Show()

				Me.Hide()
			End If
		End If
	End Sub

	Private Sub frmEsecuzione_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		lblContatore.Text = ""
		lblOperazione.Text = ""

		InPausa = False
		Blocca = False
		Skippa = False

		cmdPausa.Enabled = True
		cmdStop.Enabled = True
		cmdSkip.Enabled = True

		cmdRipristina.Visible = False

		Try
			MkDir("C:\BackupLog")
		Catch ex As Exception

		End Try

		If ModalitaEsecuzioneAutomatica Then
			' Me.WindowState = FormWindowState.Minimized
		End If
	End Sub

	Private trd As Thread
	Private ProgressivoInterno As String

	Private Sub EsegueOperazione()
		' Try
		Dim Operazione As Integer = Rec(Riga, StrutturaTabella.idOperazione)
		Dim Origine As String = Rec(Riga, StrutturaTabella.Origine)
		Dim Destinazione As String = Rec(Riga, StrutturaTabella.Destinazione)

		Dim Filtro As String = Rec(Riga, StrutturaTabella.Filtro)
		Dim Sovrascrivi As String = Rec(Riga, StrutturaTabella.Sovrascrivi)
		Dim SottoDirectory As String = Rec(Riga, StrutturaTabella.Sottodirectory)

		Dim UtenzaOrigine As String = "" & Rec(Riga, StrutturaTabella.UtenzaOrigine)
		Dim PasswordOrigine As String = "" & Rec(Riga, StrutturaTabella.PasswordOrigine)
		Dim UtenzaDestinazione As String = "" & Rec(Riga, StrutturaTabella.UtenzaDestinazione)
		Dim Passworddestinazione As String = "" & Rec(Riga, StrutturaTabella.PasswordDestinazione)

		Dim gf As New GestioneFilesDirectory
		Dim opFile As New OperazioniSuFile

		If Rec(Riga, StrutturaTabella.Attivo) = "S" Then
			Dim Controlla As Boolean = True
			Dim Vai As Boolean = True

			If Rec(Riga, StrutturaTabella.idOperazione) = TipoOperazione.EsegueSQL Then
				' In caso di script sql non esegue il controllo sui dischi
				Controlla = False
			End If

			If Controlla Then
				Dim OrigineCompleta As String = Origine
				Dim DestinazioneCompleta As String = Destinazione

				If OrigineCompleta.Contains(".") Then
					OrigineCompleta = gf.TornaNomeDirectoryDaPath(OrigineCompleta)
				End If

				If DestinazioneCompleta.Contains(".") Then
					DestinazioneCompleta = gf.TornaNomeDirectoryDaPath(DestinazioneCompleta)
				End If

				Dim Origine2 As String = Mid(Origine, 1, 1)
				Dim Destinazione2 As String = Mid(Destinazione, 1, 1)

				If Not ControllaNomeDisco(Origine2, OrigineCompleta, opFile, clLog, "Origine") Then
					Vai = False
					log.Append("Disco di origine " & OrigineCompleta & " non valido")
				End If

				If Vai Then
					If Not ControllaNomeDisco(Destinazione2, DestinazioneCompleta, opFile, clLog, "Destinazione") Then
						Vai = False
						log.Append("Disco di destinazione " & DestinazioneCompleta & " non valido")
					End If
				End If
			End If

			If Vai Then
				log.Append(opeFileGlobale.EsegueOperazione(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, Me, idProc, ProgressivoInterno, Operazione, Origine, Destinazione, Filtro, Sovrascrivi, SottoDirectory, lblOperazione, lblContatore,
													   UtenzaOrigine, PasswordOrigine, UtenzaDestinazione, Passworddestinazione, False, clLog))
			End If
		Else
			log.Append("")
			log.Append("Operazione " & ProgressivoInterno & " non attiva")
			log.Append("")
		End If

		gf = Nothing
		opFile = Nothing

		opeFileGlobale.ChiudeDBLog()
		'opeFileGlobale = Nothing
		'Catch ex As Exception
		'    log.Append("")
		'    log.Append("Operazione " & ProgressivoInterno & ". ERRORE: " & ex.Message)
		'    log.Append("")
		'End Try

		If Blocca = True And Skippa = True Then
			Blocca = False
			Skippa = False
			'cmdPausa.Enabled = True
			'cmdStop.Enabled = True
			'cmdSkip.Enabled = True
		End If
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Timer1.Enabled = False

		If InPausa Then
			Timer1.Enabled = True
			Exit Sub
		End If

		If Blocca Then
			'Dim Gf As New GestioneFilesDirectory
			'Gf.CreaAggiornaFile(NomeFileDiLog.Replace("***", NomeProcedura), log.ToString)
			'Gf = Nothing

			cmdPausa.Enabled = False
			cmdStop.Enabled = False
			lblOperazione.Text = ""
			lblContatore.Text = ""
			Blocca = False
			InPausa = False

			MsgBox("Elaborazione bloccata", MsgBoxStyle.Information)

			If ModalitaEsecuzioneAutomatica Then
				Try
					File.Delete(PercorsoDBTemp)
				Catch ex As Exception

				End Try
				NotifyIcon1.Visible = False

				End
			End If

			Exit Sub
		End If

		Dim Progressivo As String = Rec(Riga, StrutturaTabella.Progressivo)

		lstOperazioni.SelectedIndex = -1
		For i As Integer = 0 To lstOperazioni.Items.Count - 1
			If Mid(lstOperazioni.Items(i), 1, 3).Trim = Progressivo Then
				lstOperazioni.SelectedIndex = i
				Exit For
			End If
		Next

		ProgressivoInterno = Progressivo
		tmrCheckFineThread.Enabled = True

		trd = New Thread(AddressOf EsegueOperazione)
		trd.IsBackground = True
		trd.Start()
	End Sub

	Private Sub cmdPausa_Click(sender As Object, e As EventArgs) Handles cmdPausa.Click
		If opeFileGlobale Is Nothing = False Then
			opeFileGlobale.ImpostaPausa(True)
			InPausa = True
			cmdRipristina.Visible = True
			cmdPausa.Visible = False
		End If
	End Sub

	Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
		Blocca = True
		Skippa = False

		Dim NomeFileUltimaOperazione As String = Application.StartupPath & "\UltimaOperazione.txt"
		Dim gf As New GestioneFilesDirectory
		gf.EliminaFileFisico(NomeFileUltimaOperazione)
		gf = Nothing

		If opeFileGlobale Is Nothing = False Then
			cmdPausa.Enabled = False
			cmdStop.Enabled = False
			cmdSkip.Enabled = False

			opeFileGlobale.ImpostaPausa(False)
			opeFileGlobale.ImpostaBlocco()
			opeFileGlobale.ImpostaSkippa(False)
		End If
	End Sub

	Private Sub cmdRipristina_Click(sender As Object, e As EventArgs) Handles cmdRipristina.Click
        If opeFileGlobale Is Nothing = False Then
            opeFileGlobale.ImpostaPausa(False)
            InPausa = False
            cmdRipristina.Visible = False
            cmdPausa.Visible = True
            cmdSkip.Enabled = False
        End If
    End Sub

    Private Sub cmdSkip_Click(sender As Object, e As EventArgs) Handles cmdSkip.Click
        Blocca = True
        Skippa = True

        If opeFileGlobale Is Nothing = False Then
            cmdPausa.Enabled = False
            cmdStop.Enabled = False
            cmdSkip.Enabled = False

            opeFileGlobale.ImpostaPausa(False)
            opeFileGlobale.ImpostaBlocco()
            opeFileGlobale.ImpostaSkippa(True)
        End If
    End Sub

    Private Function ControllaErroriSuFileLog() As String
        Dim Errori As Integer = 0
        Dim gf As New GestioneFilesDirectory
        Dim NomeFileErrori As String = NomeFileLog
        Dim Estensione As String = gf.TornaEstensioneFileDaPath(NomeFileErrori)
        NomeFileErrori = NomeFileErrori.Replace(Estensione, "") & "_ERR_" & Estensione
        Dim gf2 As New GestioneFilesDirectory
        gf.ApreFilePerLettura(NomeFileLog)
        Dim sLine As String = ""
        Do
            sLine = gf.RitornaRiga
            If Not sLine Is Nothing Then
                If sLine.ToUpper.Contains("ERROR") Or sLine.ToUpper.Contains("IMPOSSIBILE") Then
                    gf2.ApreFileDiTestoPerScrittura(NomeFileErrori)
                    gf2.ScriveTestoSuFileAperto(sLine)
                    gf2.ChiudeFileDiTestoDopoScrittura()
                    Errori += 1
                End If
            End If
        Loop Until sLine Is Nothing
        gf.ChiudeFile()
        gf = Nothing
        gf2 = Nothing
        If Errori = 0 Then
            Return ""
        Else
            Return NomeFileErrori
        End If
    End Function

    Private Sub tmrCheckFineThread_Tick(sender As Object, e As EventArgs) Handles tmrCheckFineThread.Tick
        If Not trd.IsAlive Then
            tmrCheckFineThread.Enabled = False

            Dim Esci As Boolean = False

            If Rec(Riga + 1, StrutturaTabella.idProc) = "***" Then
                Esci = True
            Else
                Riga += 1
            End If

            Dim DataOra As String = Now.Year.ToString.Trim & Format(Now.Month, "00") & Format(Now.Day, "00") & "_" & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00")

            Dim NomeFileErrori As String = ControllaErroriSuFileLog()
			EliminaFilesVecchi(Me)

			If Esci = True Then
                'Dim Gf As New GestioneFilesDirectory
                'Gf.CreaAggiornaFile(NomeFileDiLog.Replace("***", NomeProcedura), log.ToString)
                'Gf = Nothing

                If InvioMail = "S" Then
                    Dim a As New GestioneMAIL
                    a.InvioMAIL(UtenzaMail, PasswordMail, "Backup effettuato: " & NomeProcedura, "Operazione conclusa alle ore " & Now, clLog.RitornaFileDiLog, NomeFileErrori)
                    a = Nothing
                End If

                lblOperazione.Text = ""
                lblContatore.Text = ""
                InEsecuzione = False

                cmdPausa.Enabled = False
                cmdStop.Enabled = False
                cmdSkip.Enabled = False

                If ModalitaEsecuzioneAutomatica Then
                    Try
                        File.Delete(PercorsoDBTemp)
                    Catch ex As Exception

                    End Try
                    'NotifyIcon1.Visible = False

                    End
                Else
                    MsgBox("Elaborazione effettuata", MsgBoxStyle.Information)
                End If
            Else
                If Not Blocca Then
                    If Not InPausa Then
                        Timer1.Enabled = True
                    End If
                Else
                    'Dim Gf As New GestioneFilesDirectory
                    'Gf.CreaAggiornaFile(NomeFileDiLog.Replace("***", NomeProcedura), log.ToString)
                    'Gf = Nothing

                    If InvioMail = "S" Then
                        Dim a As New GestioneMAIL
                        a.InvioMAIL(UtenzaMail, PasswordMail, "Backup effettuato: " & NomeProcedura, "Operazione bloccata alle ore " & Now, clLog.RitornaFileDiLog(), NomeFileErrori)
                        a = Nothing
                    End If

                    lblOperazione.Text = ""
                    lblContatore.Text = ""
                    InEsecuzione = False

                    If ModalitaEsecuzioneAutomatica Then
                        Try
                            File.Delete(PercorsoDBTemp)
                        Catch ex As Exception

                        End Try
                        'NotifyIcon1.Visible = False

                        End
                    Else
                        MsgBox("Elaborazione bloccata", MsgBoxStyle.Information)
                    End If
                    Exit Sub
                End If
            End If
        End If
    End Sub
End Class