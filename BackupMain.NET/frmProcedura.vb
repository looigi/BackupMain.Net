Imports System.IO
Imports OperazioniSuFile
Imports System.Text
Imports OperazioniSuFile

Public Class frmProcedura
    Private NomeProcedura As String
    Private idProc As Integer
    Private idMaschera As Integer

    Private Sub frmProcedura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'MascheraProcedura(idMaschera) = Nothing
    End Sub

    Private Sub frmProcedura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmMain.CaricaProcedure(Nothing)

		'NotifyIcon1.Visible = True
	End Sub

    Private Sub frmProcedura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProgressivo.Text = ""

        Dim op As New OperazioniSuFile

        Dim Operazioni() As String = op.TornaListaOperazioni

        cmbOperazioni.Items.Clear()
        For i As Integer = 0 To Operazioni.Length - 1
            cmbOperazioni.Items.Add(Operazioni(i))
        Next

        cmdSopraSotto.Visible = False

        If ModalitaEsecuzioneAutomatica Then
            Call cmdEsegue_Click_1(sender, e)
        End If
    End Sub

    Private Sub ControllaSeCeLog()
		'Dim DB As New GestioneACCESS

		'If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp , "ConnDB") = True Then
		'    Db.ApreDB(idProc)
		'    Dim Rec As new ADODB.Recordset
		'    Dim Sql As String

		'    Sql = "Select * From LogOperazioni Where idProc=" & idProc
		'    Rec = DB.LeggeQuery(idProc, Sql)
		'    If Rec.Eof = False Then
		'        cmdLog.Visible = True
		'    Else
		'        cmdLog.Visible = False
		'    End If
		'    Rec.Close()

		'    DB.ChiudeDB(True, ConnSQL)
		'End If

		'DB = Nothing
	End Sub

	Public Sub ImpostaNomeProcedura(Nome As String, NumeroMaschera As Integer)
		idMaschera = NumeroMaschera

		If Nome = "" Then
			lblTitNomeProc.Visible = True
			txtNomeProcedura.Visible = True
			lblNomeProc.Visible = False

			txtNomeProcedura.Text = ""
			cmdRinomina.Visible = False
			cmdSu.Visible = False
			cmdGiu.Visible = False
			cmdLog.Visible = False

			idProc = -1
		Else
			lblTitNomeProc.Visible = False
			txtNomeProcedura.Visible = False

			NomeProcedura = Nome
			txtNomeProcedura.Text = Nome
			lblNomeProc.Text = Nome
			lblNomeProc.Visible = True
			cmdRinomina.Visible = True

			Dim opFile As New OperazioniSuFile
			idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, Nome, lstOperazioni)
			Dim Campi As String = opFile.CaricaDatiProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, idProc, Nothing)
			If Campi.Contains(";") Then
				Dim CampiInterni() As String = Campi.Split(";")
				chkinviaMail.Checked = IIf(Campi(0) = "S", True, False)
			End If
			opFile = Nothing

			ControllaSeCeLog()
		End If

		PulisceCampi()
	End Sub

	Private Sub PulisceCampi()
		lblProgressivo.Text = ""
		cmbOperazioni.Text = ""
		lblOrigine.Text = ""
		lblDestinazione.Text = ""
		chkSottodirectory.Checked = True
		chkSovrascrivi.Checked = False
		txtFiltro.Text = ""
		cmdPulisce.Visible = False
		cmdElimina.Visible = False
		cmdCopia.Visible = False
		cmdSu.Visible = False
		cmdGiu.Visible = False
		pnlOrigine.Visible = False
		pnlDestinazione.Visible = False
		cmdSopraSotto.Visible = False
		chkAttivo.Visible = False
		cmdAttivaTutti.Visible = False
		cmdDisattivaTutti.Visible = False

		lblOrigine.Visible = False
		cmdSceltaOrig.Visible = False
		lblTitOrig.Visible = False

		lblDestinazione.Visible = False
		cmdSceltaDest.Visible = False
		lblTitDest.Visible = False

		lblTitFiltro.Visible = False
		txtFiltro.Visible = False

		cmdCopia.Visible = False

		chkSottodirectory.Visible = False
		chkSovrascrivi.Visible = False

		cmdSalva.Visible = False
		lblTitOperazione.Visible = False

		pnlOperazioni.Visible = False
		pnlAttivazione.Visible = False

		cmdEliminaDatiSincInt.Visible = False
		cmdEliminaTutti.Visible = False
		pnlRigheSI.Visible = False
	End Sub

	Private Sub lstOperazioni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOperazioni.SelectedIndexChanged
		If lstOperazioni.Text = "" Then
			Exit Sub
		End If

		Dim Riga As String = lstOperazioni.Text
		Dim Progressivo As String = Mid(Riga, 1, 2).Trim
		Dim Operazione As String = Mid(Riga, 4, 23).Trim

		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Rec As New ADODB.Recordset
			Dim Sql As String

			Sql = "Select * From DettaglioProcedure Where idProc=" & idProc & " And Progressivo=" & Progressivo
			Rec = DB.LeggeQuery(idProc, Sql, Nothing)
			lblProgressivo.Text = Progressivo
			cmbOperazioni.Text = Operazione
			lblOrigine.Text = Rec("Origine").Value.ToString.Trim
			lblDestinazione.Text = Rec("Destinazione").Value.ToString.Trim
			If Rec("Sovrascrivi").Value.ToString.Trim = "S" Then
				chkSovrascrivi.Checked = True
			Else
				chkSovrascrivi.Checked = False
			End If
			If Rec("Sottodirectory").Value.ToString.Trim = "S" Then
				chkSottodirectory.Checked = True
			Else
				chkSottodirectory.Checked = False
			End If
			txtFiltro.Text = Rec("Filtro").Value.ToString.Trim

			txtUtenzaOrigine.Text = "" & Rec("UtenzaOrigine").Value.ToString.Trim
			txtPasswordOrigine.Text = "" & Rec("PasswordOrigine").Value.ToString.Trim

			txtUtenzaDestinazione.Text = "" & Rec("UtenzaDestinazione").Value.ToString.Trim
			txtPasswordDestinazione.Text = "" & Rec("PasswordDestinazione").Value.ToString.Trim

			chkAttivo.Checked = IIf(Rec("Attivo").Value = "S", True, False)

			Rec.Close()

			If Operazione.Contains("Intelligente") Then
				Sql = "Select Count(*) From FileDestinazioneIntelligente Where idProc=" & idProc & " And Operazione=" & Progressivo
				Rec = DB.LeggeQuery(idProc, Sql, Nothing)
				If Rec(0).Value Is DBNull.Value Then
					lblRighe.Text = 0
				Else
					lblRighe.Text = Rec(0).Value
				End If
				Rec.Close()
				pnlRigheSI.Visible = True
			Else
				pnlRigheSI.Visible = False
			End If

			If lblOrigine.Text <> "" Then
				If Mid(lblOrigine.Text, 1, 2) = "\\" Then
					pnlOrigine.Visible = True
				Else
					pnlOrigine.Visible = False
				End If
			End If

			If lblDestinazione.Text <> "" Then
				If Mid(lblDestinazione.Text, 1, 2) = "\\" Then
					pnlDestinazione.Visible = True
				Else
					pnlDestinazione.Visible = False
				End If
			End If

			If lblOrigine.Visible = True And lblDestinazione.Visible = True Then
				cmdSopraSotto.Visible = True
			Else
				cmdSopraSotto.Visible = False
			End If

			DB.ChiudeDB(True)
		End If

		DB = Nothing

		cmdElimina.Visible = True
		cmdPulisce.Visible = True

		cmdSu.Visible = True
		cmdGiu.Visible = True

		cmdCopia.Visible = True

		ImpostaVisualizzazione(Operazione)
	End Sub

	Private Sub cmdSceltaOrig_Click(sender As Object, e As EventArgs) Handles cmdSceltaOrig.Click
		Dim sMyDir As String = ""

		Try
			sMyDir = CreateObject("Shell.Application").BrowseForFolder(0, "Percorso di origine", 0, 0).Self.Path
			lblOrigine.Text = sMyDir
		Catch ex As Exception

		End Try
	End Sub

	Private Sub cmdSceltaDest_Click(sender As Object, e As EventArgs) Handles cmdSceltaDest.Click
		Dim sMyDir As String = ""

		Try
			sMyDir = CreateObject("Shell.Application").BrowseForFolder(0, "Percorso di destinazione", 0, 0).Self.Path
			lblDestinazione.Text = sMyDir
		Catch ex As Exception

		End Try
	End Sub

	Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Rec As New ADODB.Recordset
			Dim Sql As String
			Dim Riga As Integer = lstOperazioni.SelectedIndex

			Sql = "Delete From DettaglioProcedure Where idProc=" & idProc & " And Progressivo=" & lblProgressivo.Text
			DB.EsegueSql(idProc, Sql, Nothing)

			Dim opFile As New OperazioniSuFile
			idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lblNomeProc.Text, lstOperazioni)
			opFile = Nothing

			PulisceCampi()

			Try
				lstOperazioni.SelectedIndex = Riga
			Catch ex As Exception

			End Try

			DB.ChiudeDB(True)
		End If

		DB = Nothing
	End Sub

	Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
		If txtNomeProcedura.Text = "" Then
			MsgBox("Inserire il nome della procedura", MsgBoxStyle.Information)
			Exit Sub
		End If
		If cmbOperazioni.Text = "" Then
			MsgBox("Selezionare l'operazione da eseguire", MsgBoxStyle.Information)
			Exit Sub
		End If

		SalvaOperazione()
	End Sub

	Private Sub SalvaOperazione()
		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Rec As New ADODB.Recordset
			Dim Sql As String
			Dim Progressivo As Integer
			Dim Operazione As Integer
			Dim Op As New OperazioniSuFile

			Select Case cmbOperazioni.Text
				Case "Copia"
					Operazione = OperazioniSuFile.TipoOperazione.Copia
				Case "Crea dir"
					Operazione = OperazioniSuFile.TipoOperazione.CreaDirectory
				Case "Elimina dir"
					Operazione = OperazioniSuFile.TipoOperazione.EliminaDirectory
				Case "Elimina Files"
					Operazione = OperazioniSuFile.TipoOperazione.Eliminazione
				Case "Sincronizza"
					Operazione = OperazioniSuFile.TipoOperazione.Sincronizzazione
				Case "Sincronia Intelligente"
					Operazione = OperazioniSuFile.TipoOperazione.SincroniaIntelligente
				Case "Sposta"
					Operazione = OperazioniSuFile.TipoOperazione.Spostamento
				Case "Riavvio PC"
					Operazione = OperazioniSuFile.TipoOperazione.RiavvioPC
				Case "Avvia Servizio"
					Operazione = OperazioniSuFile.TipoOperazione.AvvioServizio
				Case "Ferma Servizio"
					Operazione = OperazioniSuFile.TipoOperazione.FermaServizio
				Case "Avvia EXE"
					Operazione = OperazioniSuFile.TipoOperazione.AvviaEseguibile
				Case "Ferma EXE"
					Operazione = OperazioniSuFile.TipoOperazione.FermaEseguibile
				Case "Attendi"
					Operazione = OperazioniSuFile.TipoOperazione.Attendi
				Case "Zip", "Lista Files"
					If cmbOperazioni.Text = "Zip" Then
						Operazione = OperazioniSuFile.TipoOperazione.Zip
					Else
						Operazione = OperazioniSuFile.TipoOperazione.ListaFiles
					End If
					Dim Esisteva As Boolean = True

					Dim isDir As Boolean

					If Directory.Exists(lblDestinazione.Text) Then
						isDir = True
					Else
						If Not File.Exists(lblDestinazione.Text) Then
							Dim gf As New GestioneFilesDirectory
							Dim cart As String = gf.TornaNomeDirectoryDaPath(lblDestinazione.Text) & "\"
							gf.CreaDirectoryDaPercorso(cart)
							gf.CreaAggiornaFile(lblDestinazione.Text, "")
							gf = Nothing
							Esisteva = False
						End If
					End If

					If Directory.Exists(lblDestinazione.Text) Then
						isDir = True
					ElseIf File.Exists(lblDestinazione.Text) Then
						isDir = False
					End If

					If Not Esisteva Then
						File.Delete(lblDestinazione.Text)
					End If

					If isDir Then
						MsgBox("Il percorso immesso punta ad una directory", vbExclamation)
						Exit Sub
					Else
						If cmbOperazioni.Text = "Zip" Then
							If Not lblDestinazione.Text.ToUpper.Contains(".ZIP") Then
								MsgBox("Estensione file non valida." & vbCrLf & "Il file deve essere .ZIP", vbExclamation)
								Exit Sub
							End If
						Else
							If Not lblDestinazione.Text.ToUpper.Contains(".TXT") Then
								MsgBox("Estensione file non valida." & vbCrLf & "Il file deve essere .TXT", vbExclamation)
								Exit Sub
							End If
						End If
					End If
				Case "Messaggio"
					Operazione = OperazioniSuFile.TipoOperazione.Messaggio
				Case "Esegue SQL Server"
					Operazione = OperazioniSuFile.TipoOperazione.EsegueSQL
				Case Else
					Operazione = OperazioniSuFile.TipoOperazione.Nulla
			End Select

			If idProc = -1 Then
				Sql = "Select Max(idProc) From NomiProcedure"
				Rec = DB.LeggeQuery(idProc, Sql, Nothing)
				If Rec(0).Value Is DBNull.Value = True Then
					Progressivo = 1
				Else
					Progressivo = Rec(0).Value + 1
				End If
				Rec.Close()

				Dim InvioMail As String = IIf(chkinviaMail.Checked, "S", "N")

				Sql = "Insert Into NomiProcedure Values (" &
						" " & Progressivo & ", " &
						"'', " &
						"'" & txtNomeProcedura.Text.Replace("'", "''") & "', " &
						"'N', " &
						"'N', " &
						"'', " &
						"'" & InvioMail & "' " &
						")"
				DB.EsegueSql(idProc, Sql, Nothing)

				lblNomeProc.Text = txtNomeProcedura.Text
				lblTitNomeProc.Visible = False
				txtNomeProcedura.Visible = False
				lblNomeProc.Visible = True

				idProc = Progressivo
			End If

			Dim Sovrascrivi As String = IIf(chkSovrascrivi.Checked = True, "S", "N")
			Dim SottoDirectory As String = IIf(chkSottodirectory.Checked = True, "S", "N")

			Dim Attivo As String = IIf(chkAttivo.Checked, "S", "N")

			If Strings.Right(lblOrigine.Text, 1) = "\" Then
				lblOrigine.Text = Mid(lblOrigine.Text, 1, lblOrigine.Text.Length - 1)
			End If

			If Strings.Right(lblDestinazione.Text, 1) = "\" Then
				lblDestinazione.Text = Mid(lblDestinazione.Text, 1, lblDestinazione.Text.Length - 1)
			End If

			If lblProgressivo.Text = "" Then
				Sql = "Select Max(Progressivo) From DettaglioProcedure Where idProc=" & idProc
				Rec = DB.LeggeQuery(idProc, Sql, Nothing)
				If Rec(0).Value Is DBNull.Value = True Then
					Progressivo = 1
				Else
					Progressivo = Rec(0).Value + 1
				End If
				Rec.Close()

				Sql = "Insert Into DettaglioProcedure Values (" &
					" " & idProc & ", " &
					" " & Progressivo & ", " &
					" " & Operazione & ", " &
					"'" & lblOrigine.Text.Replace("'", "''") & "', " &
					"'" & lblDestinazione.Text.Replace("'", "''") & "', " &
					"'" & Sovrascrivi & "', " &
					"'" & SottoDirectory & "', " &
					"'" & txtFiltro.Text.Replace("'", "''").Trim & "', " &
					"''," &
					"'" & txtUtenzaOrigine.Text.Replace("'", "''") & "', " &
					"'" & txtPasswordOrigine.Text.Replace("'", "''") & "', " &
					"'" & txtUtenzaDestinazione.Text.Replace("'", "''") & "', " &
					"'" & txtPasswordDestinazione.Text.Replace("'", "''") & "', " &
					"'" & Attivo & "' " &
					")"
			Else
				Sql = "Update DettaglioProcedure Set " &
					"idOperazione=" & Operazione & ", " &
					"Origine='" & lblOrigine.Text.Replace("'", "''") & "', " &
					"Destinazione='" & lblDestinazione.Text.Replace("'", "''") & "', " &
					"Sovrascrivi='" & Sovrascrivi & "', " &
					"Sottodirectory='" & SottoDirectory & "', " &
					"UtenzaOrigine='" & txtUtenzaOrigine.Text.Replace("'", "''") & "', " &
					"PasswordOrigine='" & txtPasswordOrigine.Text.Replace("'", "''") & "', " &
					"UtenzaDestinazione='" & txtUtenzaDestinazione.Text.Replace("'", "''") & "', " &
					"PasswordDestinazione='" & txtPasswordDestinazione.Text.Replace("'", "''") & "', " &
					"Filtro='" & txtFiltro.Text.Replace("'", "''").Trim & "', " &
					"Attivo='" & Attivo & "' " &
					"Where idProc=" & idProc & " And Progressivo=" & lblProgressivo.Text
			End If

			DB.EsegueSql(idProc, Sql, Nothing)

			OrdinaOperazioni(idProc, DB)

			PulisceCampi()

			DB.ChiudeDB(True)

			Dim opFile As New OperazioniSuFile
			idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lblNomeProc.Text, lstOperazioni)
			opFile = Nothing
		End If

		DB = Nothing
	End Sub

	Private Sub OrdinaOperazioni(idProc As Integer, DB As GestioneACCESS)
		Dim Sql As String = "Drop Table Appoggio"
		DB.EsegueSql(idProc, Sql, Nothing)

		Sql = "SELECT idProc, (SELECT Count(*) FROM DettaglioProcedure T2 WHERE t2.Origine+str(t2.Progressivo) < DettaglioProcedure.Origine+str(DettaglioProcedure.Progressivo)) As Progressivo, " &
			"idOperazione, Origine, Destinazione, Sovrascrivi, Sottodirectory, Filtro, Parametro, UtenzaOrigine, PasswordOrigine, UtenzaDestinazione, PasswordDestinazione, Attivo " &
			"Into Appoggio " &
			"FROM DettaglioProcedure " &
			"WHERE idProc = " & idProc & " " &
			"ORDER BY DettaglioProcedure.Origine, DettaglioProcedure.Destinazione"
		DB.EsegueSql(idProc, Sql, Nothing)

		Sql = "Delete * From DettaglioProcedure Where idProc = " & idProc
		DB.EsegueSql(idProc, Sql, Nothing)

		Sql = "Insert Into DettaglioProcedure Select * From Appoggio"
		DB.EsegueSql(idProc, Sql, Nothing)
	End Sub

	Private Sub cmbOperazioni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperazioni.SelectedIndexChanged
		ImpostaVisualizzazione(cmbOperazioni.Text)
		chkAttivo.Checked = True
	End Sub

	Private Sub ImpostaVisualizzazione(Cosa As String)
		lblOrigine.Visible = True
		cmdSceltaOrig.Visible = True
		lblTitOrig.Visible = True

		lblDestinazione.Visible = True
		cmdSceltaDest.Visible = True
		lblTitDest.Visible = True

		lblTitFiltro.Visible = True
		txtFiltro.Visible = True

		chkSottodirectory.Visible = True
		chkSovrascrivi.Visible = True

		cmdEliminaDatiSincInt.Visible = False
		cmdEliminaTutti.Visible = False

		lblTitOrig.Text = "Origine"
		lblTitDest.Text = "Destinazione"
		lblTitFiltro.Text = "Parametri"

		cmdSopraSotto.Visible = True

		Select Case Cosa
			Case "Copia"
			Case "Crea dir"
				lblDestinazione.Visible = False
				cmdSceltaDest.Visible = False
				lblTitDest.Visible = False

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case "Elimina dir"
				lblDestinazione.Visible = False
				cmdSceltaDest.Visible = False
				lblTitDest.Visible = False

				lblTitFiltro.Visible = False
				txtFiltro.Visible = False

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case "Elimina Files"
				lblDestinazione.Visible = False
				cmdSceltaDest.Visible = False
				lblTitDest.Visible = False

				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case "Messaggio"
				lblOrigine.Visible = False
				lblTitOrig.Visible = False
				cmdSceltaOrig.Visible = False
				lblDestinazione.Visible = False
				lblTitDest.Visible = False
				cmdSceltaDest.Visible = False
				lblTitFiltro.Visible = True
				txtFiltro.Visible = True

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case "Sincronizza", "Sincronia Intelligente", "Zip", "Lista Files"
				lblTitFiltro.Text = "Esclusioni"
				lblTitFiltro.Visible = True
				txtFiltro.Visible = True

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False
			Case "Sposta"
			Case "Riavvio PC"
				lblOrigine.Visible = False
				cmdSceltaOrig.Visible = False
				lblTitOrig.Visible = False

				lblDestinazione.Visible = False
				cmdSceltaDest.Visible = False
				lblTitDest.Visible = False

				lblTitFiltro.Visible = False
				txtFiltro.Visible = False

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case "Avvia Servizio", "Ferma Servizio", "Avvia EXE", "Ferma EXE", "Attendi"
				lblDestinazione.Visible = False
				cmdSceltaDest.Visible = False
				lblTitDest.Visible = False

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSceltaOrig.Visible = False

				If Cosa = "Avvia Servizio" Or Cosa = "Avvia EXE" Then
					lblTitFiltro.Visible = True
					txtFiltro.Visible = True
				Else
					lblTitFiltro.Visible = False
					txtFiltro.Visible = False
				End If

				cmdSopraSotto.Visible = False
			Case "Esegue SQL Server"
				lblOrigine.Visible = True
				cmdSceltaOrig.Visible = False
				lblTitOrig.Visible = True
				lblTitOrig.Text = "Connessione"

				lblDestinazione.Visible = True
				cmdSceltaDest.Visible = True
				lblTitDest.Visible = True
				lblTitDest.Text = "File SQL"

				lblTitFiltro.Visible = False
				txtFiltro.Visible = False

				chkSottodirectory.Visible = False
				chkSovrascrivi.Visible = False

				cmdSopraSotto.Visible = False
			Case Else
		End Select

		If Cosa.ToString.IndexOf("Intelligente") > -1 Then
			cmdEliminaDatiSincInt.Visible = True
			cmdEliminaTutti.Visible = True
		End If

		chkAttivo.Visible = True
		cmdAttivaTutti.Visible = True
		cmdDisattivaTutti.Visible = True
		cmdSalva.Visible = True
		lblTitOperazione.Visible = True
		pnlOperazioni.Visible = True
		pnlAttivazione.Visible = True
	End Sub

	Private Sub cmdEsegue_Click(sender As Object, e As EventArgs)
		Dim opeFileGlobale = New OperazioniSuFile
		Dim clLog = New LogCasareccio.LogCasareccio.Logger

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
		Dim NomeFileLog As String = "C:\BackupLog\" & txtNomeProcedura.Text & "_" & df & ".txt"
		clLog.ImpostaFileDiLog(NomeFileLog)

		'If Not ControllaDischi(idProc, Nothing, txtNomeProcedura, lstOperazioni) Then
		If ModalitaEsecuzioneAutomatica Then
			Dim a As New GestioneMAIL
			a.InvioMAIL(UtenzaMail, PasswordMail, "Backup effettuato: " & NomeProcedura, "Operazione conclusa alle ore " & Now, clLog.RitornaFileDiLog)
			a = Nothing
			End
			'Else
			'    Exit Sub
		End If
		'End If

		frmEsecuzione.ImpostaNomeProcedura(NomeFileLog, lblNomeProc.Text, idMaschera, opeFileGlobale, clLog)

		' Me.Hide()
	End Sub

	Private Sub cmdPulisce_Click(sender As Object, e As EventArgs) Handles cmdPulisce.Click
		PulisceCampi()
	End Sub

	Private Sub cmdSchedulazione_Click(sender As Object, e As EventArgs)
		If txtNomeProcedura.Text = "" Then
			MsgBox("Inserire il nome della procedura", MsgBoxStyle.Information)
			Exit Sub
		End If

		frmSchedulazione.ImpostaNomeProcedura(lblNomeProc.Text, idMaschera)
		frmSchedulazione.Show()

		Me.Hide()
	End Sub

	Private Sub cmdCancella_Click(sender As Object, e As EventArgs) Handles cmdCancella.Click
		If MsgBox("Si è sicuri di voler eliminare la procedura '" & lblNomeProc.Text & "'", vbYesNo + vbInformation + vbDefaultButton2) = vbNo Then
			Exit Sub
		End If

		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Sql As String

			Sql = "Delete From NomiProcedure Where idProc=" & idProc
			DB.EsegueSql(idProc, Sql, Nothing)

			Sql = "Delete From Schedulazioni Where idProc=" & idProc
			DB.EsegueSql(idProc, Sql, Nothing)

			Sql = "Delete From DettaglioProcedure Where idProc=" & idProc
			DB.EsegueSql(idProc, Sql, Nothing)

			DB.CompattazioneDb()

			DB.ChiudeDB(True)
		End If

		DB = Nothing

		MsgBox("Procedura eliminata", vbInformation)

		Me.Hide()

		frmMain.CaricaProcedure(Nothing)
		frmMain.Show()
	End Sub

	Private Sub cmdRinomina_Click(sender As Object, e As EventArgs) Handles cmdRinomina.Click
		Dim NuovoNome As String = InputBox(lblNomeProc.Text, "Nuovo nome procedura")

		If NuovoNome <> "" Then
			Dim DB As New GestioneACCESS

			If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
				DB.ApreDB(idProc, Nothing)
				Dim Sql As String

				Sql = "Update NomiProcedure Set NomeProcedura ='" & NuovoNome.Trim.Replace("'", "''") & "' Where idProc=" & idProc
				DB.EsegueSql(idProc, Sql, Nothing)

				DB.ChiudeDB(True)
			End If

			DB = Nothing

			lblNomeProc.Text = NuovoNome.Trim

			frmMain.CaricaProcedure(Nothing)

			MsgBox("Procedura rinominata", vbInformation)
		End If
	End Sub

	Private Sub cmdGiu_Click(sender As Object, e As EventArgs) Handles cmdGiu.Click
		Dim DB As New GestioneACCESS
		Dim numRiga As Integer = lstOperazioni.SelectedIndex

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Sql As String
			Dim Riga As String = lstOperazioni.Text
			Dim Rec As New ADODB.Recordset
			Dim Progressivo As Integer = Mid(Riga, 1, 3).Trim
			Dim Successivo As Integer = -1

			Sql = "Select Top 1 * From DettaglioProcedure Where idProc=" & idProc & " And Progressivo>" & Progressivo & " Order By Progressivo"
			Rec = DB.LeggeQuery(idProc, Sql, Nothing)
			If Rec.EOF = False Then
				Successivo = Rec("Progressivo").Value
			End If
			Rec.Close()

			If Successivo > -1 Then
				Sql = "Update DettaglioProcedure Set Progressivo=999 Where idProc=" & idProc & " And Progressivo=" & Progressivo
				DB.EsegueSql(idProc, Sql, Nothing)

				Sql = "Update DettaglioProcedure Set Progressivo=" & Progressivo & " Where idProc=" & idProc & " And Progressivo=" & Successivo
				DB.EsegueSql(idProc, Sql, Nothing)

				Sql = "Update DettaglioProcedure Set Progressivo=" & Successivo & " Where idProc=" & idProc & " And Progressivo=999"
				DB.EsegueSql(idProc, Sql, Nothing)
			End If

			DB.ChiudeDB(True)
		End If

		DB = Nothing

		Dim opFile As New OperazioniSuFile
		idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lblNomeProc.Text, lstOperazioni)
		opFile = Nothing

		PulisceCampi()

		Try
			lstOperazioni.SelectedIndex = numRiga + 1
		Catch ex As Exception

		End Try
	End Sub

	Private Sub cmdSu_Click(sender As Object, e As EventArgs) Handles cmdSu.Click
		Dim DB As New GestioneACCESS
		Dim numRiga As Integer = lstOperazioni.SelectedIndex

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Sql As String
			Dim Riga As String = lstOperazioni.Text
			Dim Rec As New ADODB.Recordset
			Dim Progressivo As Integer = Mid(Riga, 1, 3).Trim
			Dim Successivo As Integer = -1

			Sql = "Select Top 1 * From DettaglioProcedure Where idProc=" & idProc & " And Progressivo<" & Progressivo & " Order By Progressivo Desc"
			Rec = DB.LeggeQuery(idProc, Sql, Nothing)
			If Rec.Eof = False Then
				Successivo = Rec("Progressivo").Value
			End If
			Rec.Close()

			If Successivo > -1 Then
				Sql = "Update DettaglioProcedure Set Progressivo=999 Where idProc=" & idProc & " And Progressivo=" & Progressivo
				DB.EsegueSql(idProc, Sql, Nothing)

				Sql = "Update DettaglioProcedure Set Progressivo=" & Progressivo & " Where idProc=" & idProc & " And Progressivo=" & Successivo
				DB.EsegueSql(idProc, Sql, Nothing)

				Sql = "Update DettaglioProcedure Set Progressivo=" & Successivo & " Where idProc=" & idProc & " And Progressivo=999"
				DB.EsegueSql(idProc, Sql, Nothing)
			End If

			DB.ChiudeDB(True)
		End If

		DB = Nothing

		Dim opFile As New OperazioniSuFile
		idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lblNomeProc.Text, lstOperazioni)
		opFile = Nothing

		PulisceCampi()

		Try
			lstOperazioni.SelectedIndex = numRiga - 1
		Catch ex As Exception

		End Try
	End Sub

	Private Sub lblOrigine_TextChanged(sender As Object, e As EventArgs) Handles lblOrigine.TextChanged
		If lblOrigine.Text <> "" Then
			If Mid(lblOrigine.Text, 1, 2) = "\\" Then
				pnlOrigine.Visible = True
			Else
				pnlOrigine.Visible = False
			End If
		End If
	End Sub

	Private Sub lblDestinazione_TextChanged(sender As Object, e As EventArgs) Handles lblDestinazione.TextChanged
		If lblDestinazione.Text <> "" Then
			If Mid(lblDestinazione.Text, 1, 2) = "\\" Then
				pnlDestinazione.Visible = True
			Else
				pnlDestinazione.Visible = False
			End If
		End If
	End Sub

	Private Sub cmdSopraSotto_Click(sender As Object, e As EventArgs) Handles cmdSopraSotto.Click
		Dim u As String = txtUtenzaDestinazione.Text
		Dim p As String = txtPasswordDestinazione.Text
		Dim d As String = lblDestinazione.Text

		lblDestinazione.Text = lblOrigine.Text
		txtUtenzaDestinazione.Text = txtUtenzaOrigine.Text
		txtPasswordDestinazione.Text = txtPasswordOrigine.Text

		lblOrigine.Text = d
		txtUtenzaOrigine.Text = u
		txtPasswordOrigine.Text = p
	End Sub

	Private Sub CheckConnessione(Cartella As String, Utenza As String, Password As String)
		If Mid(Cartella, 1, 2) = "\\" Then
			Dim Messaggio As String = ""
			Dim mud As New MapUnMapDrives

			Dim opFiles As New OperazioniSuFile
			Dim LetteraLibera As String = opFiles.PrendeLetteraDiscoLibero
			Dim LetteraDisco As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", "")
			If LetteraDisco = "" Then
				My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", LetteraLibera)
				LetteraDisco = LetteraLibera
			End If
			opFiles = Nothing

			Try
				mud.MappaDiscoDiRete(Cartella, Utenza, Password)
			Catch ex As Exception
				Messaggio = ex.Message
			End Try

			If Messaggio = "" Then
				Try
					Dim gf As New GestioneFilesDirectory
					gf.CreaAggiornaFile(Cartella & "\Buttami.txt", "Prova map")
					gf = Nothing

					File.Delete(Cartella & "\Buttami.txt")
				Catch ex As Exception
					Messaggio = ex.Message
				End Try
			End If

			If Messaggio = "" Then
				Try
					mud.SMappaDiscoDiRete(LetteraDisco, False)
				Catch ex As Exception
					Messaggio = ex.Message
				End Try
			End If

			mud = Nothing

			If Messaggio = "" Then
				Messaggio = "Test OK"
			End If

			MsgBox(Messaggio)
		Else
			MsgBox("La cartella da controllare non è di rete")
		End If
	End Sub

	Private Sub cmdTestO_Click(sender As Object, e As EventArgs) Handles cmdTestO.Click
		CheckConnessione(lblOrigine.Text, txtUtenzaOrigine.Text, txtPasswordOrigine.Text)
	End Sub

	Private Sub cmdTestD_Click(sender As Object, e As EventArgs) Handles cmdTestD.Click
		CheckConnessione(lblDestinazione.Text, txtUtenzaDestinazione.Text, txtPasswordDestinazione.Text)
	End Sub

	Private Sub cmdLog_Click(sender As Object, e As EventArgs)
		'frmLog.setIdProc(idProc, idMaschera)
		'frmLog.Show()

		'Me.Hide()
	End Sub

	Private Sub cmdCopia_Click(sender As Object, e As EventArgs) Handles cmdCopia.Click
		If txtNomeProcedura.Text = "" Then
			MsgBox("Inserire il nome della procedura", MsgBoxStyle.Information)
			Exit Sub
		End If
		If cmbOperazioni.Text = "" Then
			MsgBox("Selezionare l'operazione da eseguire", MsgBoxStyle.Information)
			Exit Sub
		End If

		lblProgressivo.Text = ""
		SalvaOperazione()
	End Sub

	Private Sub AttivaDisattivaRighe(Come As String)
		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Sql As String = "Update DettaglioProcedure Set Attivo='N' Where idProc=" & idProc

			DB.EsegueSql(idProc, Sql, Nothing)

			DB.ChiudeDB(True)
		End If

		DB = Nothing

		Dim opFile As New OperazioniSuFile
		idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lblNomeProc.Text, lstOperazioni)
		opFile = Nothing

		PulisceCampi()
	End Sub

	Private Sub cmdAttivaTutti_Click(sender As Object, e As EventArgs) Handles cmdAttivaTutti.Click
		AttivaDisattivaRighe("S")
		MsgBox("Righe attivate", MsgBoxStyle.Information)
	End Sub

	Private Sub cmdDisattivaTutti_Click(sender As Object, e As EventArgs) Handles cmdDisattivaTutti.Click
		AttivaDisattivaRighe("N")
		MsgBox("Righe disattivate", MsgBoxStyle.Information)
	End Sub

	Private Sub cmdSchedulazione_Click_1(sender As Object, e As EventArgs) Handles cmdSchedulazione.Click
		If txtNomeProcedura.Text = "" Then
			MsgBox("Inserire il nome della procedura", MsgBoxStyle.Information)
			Exit Sub
		End If

		frmSchedulazione.ImpostaNomeProcedura(lblNomeProc.Text, idMaschera)
		frmSchedulazione.Show()

		Me.Hide()
	End Sub

	Private Sub cmdLog_Click_1(sender As Object, e As EventArgs) Handles cmdLog.Click
		'frmLog.setIdProc(idProc, idMaschera)
		'frmLog.Show()

		'Me.Hide()
	End Sub

	Private Sub cmdEsegue_Click_1(sender As Object, e As EventArgs) Handles cmdEsegue.Click
		If txtNomeProcedura.Text = "" Then
			MsgBox("Inserire il nome della procedura", MsgBoxStyle.Information)
			Exit Sub
		End If

		Dim opeFileGlobale = New OperazioniSuFile
		Dim clLog = New LogCasareccio.LogCasareccio.Logger

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
		Dim NomeFileLog As String = "C:\BackupLog\" & txtNomeProcedura.Text & "_" & df & ".txt"
		clLog.ImpostaFileDiLog(NomeFileLog)

		' clLog.ScriveLogServizio("Controllo esistenza dischi")

		'If Not ControllaDischi(idProc, clLog, txtNomeProcedura, lstOperazioni) Then
		'If ModalitaEsecuzioneAutomatica Then
		'        Dim a As New GestioneMAIL
		'        a.InvioMAIL(UtenzaMail, PasswordMail, "Backup effettuato: " & NomeProcedura, "Operazione conclusa alle ore " & Now, clLog.RitornaFileDiLog)
		'        a = Nothing
		'        End
		'    'Else
		'    '    Exit Sub
		'End If
		'End If

		'Dim Ok As Boolean = True
		'Dim Quale As Integer

		'For i As Integer = 0 To qMaschereEsecuzione
		'    Try
		'        If MascheraEsecuzione(i) Is Nothing Then
		'            Quale = i
		'            Ok = False
		'            Exit For
		'        End If
		'    Catch ex As Exception
		'        Quale = i
		'        Ok = False
		'        Exit For
		'    End Try
		'Next
		'If Ok Then
		'    qMaschereEsecuzione += 1
		'    ReDim Preserve MascheraEsecuzione(qMaschereEsecuzione)
		'    MascheraEsecuzione(qMaschereEsecuzione) = New frmEsecuzione
		'    Quale = qMaschereEsecuzione
		'Else
		'    ReDim Preserve MascheraEsecuzione(0)
		'    MascheraEsecuzione(Quale) = New frmEsecuzione
		'End If

		'MascheraEsecuzione(Quale).ImpostaNomeProcedura(lblNomeProc.Text, idMaschera, opeFileGlobale, clLog)
		'MascheraEsecuzione(Quale).Show()

		clLog.ScriveLogServizio("Impostazione nome procedura per maschera di esecuzione")
		frmEsecuzione.ImpostaNomeProcedura(NomeFileLog, lblNomeProc.Text, idMaschera, opeFileGlobale, clLog)
		frmEsecuzione.Show()

		If ModalitaEsecuzioneAutomatica Then
			Me.Top = -1000
			Me.ShowInTaskbar = False
		Else
			Me.Hide()
		End If
	End Sub

	Private Sub cmdEliminaDatiSincInt_Click(sender As Object, e As EventArgs) Handles cmdEliminaDatiSincInt.Click
		Dim Riga As String = lstOperazioni.Text
		Dim Progressivo As String = Mid(Riga, 1, 2).Trim
		Dim Operazione As String = Mid(Riga, 4, 23).Trim

		If Operazione.IndexOf("Intelligente") > -1 Then
			If MsgBox("Si vogliono eliminare i dati salvati della" & vbCrLf & "sincronia intelligente per l'operazione selezionata ?", vbYesNo + vbDefaultButton2 + vbInformation) = vbYes Then
				Me.Cursor = Cursors.WaitCursor
				Dim DB As New GestioneACCESS
				If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
					DB.ApreDB(idProc, Nothing)
					Dim Sql As String = "Delete From FileDestinazioneIntelligente Where idProc=" & idProc & " And Operazione=" & Progressivo

					DB.EsegueSql(idProc, Sql, Nothing)

					DB.CompattazioneDb()

					DB.ChiudeDB(True)
				End If

				DB = Nothing

				lblRighe.Text = "0"
				cmdEliminaDatiSincInt.Visible = False
				cmdEliminaTutti.Visible = False
				Me.Cursor = Cursors.Default
				MsgBox("Dati eliminati", vbInformation)
			End If
		End If
	End Sub

	Private Sub chkinviaMail_Click(sender As Object, e As EventArgs) Handles chkinviaMail.Click
		If idProc > 0 Then
			Dim DB As New GestioneACCESS
			If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
				DB.ApreDB(idProc, Nothing)
				Dim InvioMail As String = IIf(chkinviaMail.Checked, "S", "N")
				Dim Sql As String = "Update NomiProcedure Set InvioMail='" & InvioMail & "' Where idProc=" & idProc

				DB.EsegueSql(idProc, Sql, Nothing)

				DB.CompattazioneDb()

				DB.ChiudeDB(True)
			End If

			DB = Nothing
		End If
	End Sub

	Private Sub cmdEliminaTutti_Click(sender As Object, e As EventArgs) Handles cmdEliminaTutti.Click
		Dim Riga As String = lstOperazioni.Text
		Dim Progressivo As String = Mid(Riga, 1, 2).Trim
		Dim Operazione As String = Mid(Riga, 4, 23).Trim

		If Operazione.IndexOf("Intelligente") > -1 Then
			If MsgBox("Si vogliono eliminare i dati salvati della" & vbCrLf & "sincronia intelligente per la procedura ?", vbYesNo + vbDefaultButton2 + vbInformation) = vbYes Then
				Me.Cursor = Cursors.WaitCursor
				Dim DB As New GestioneACCESS
				If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
					DB.ApreDB(idProc, Nothing)
					Dim Sql As String = "Delete From FileDestinazioneIntelligente Where idProc=" & idProc

					DB.EsegueSql(idProc, Sql, Nothing)

					DB.CompattazioneDb()

					DB.ChiudeDB(True)
				End If

                DB = Nothing

                lblRighe.Text = "0"
                cmdEliminaDatiSincInt.Visible = False
                cmdEliminaTutti.Visible = False
                Me.Cursor = Cursors.Default
                MsgBox("Dati eliminati", vbInformation)
            End If
        End If
    End Sub

End Class