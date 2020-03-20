Public Class frmSchedulazione
    Private NomeProcedura As String
    Private idMaschera As Integer
    Private idProc As Integer

    Private Sub frmSchedulazione_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmProcedura.ImpostaNomeProcedura(NomeProceduraScelta, idMaschera)
        frmProcedura.Show()
        ' frmProcedura.Show()
    End Sub

    Public Sub ImpostaNomeProcedura(Nome As String, id As Integer)
        idMaschera = id
        NomeProcedura = Nome
        lblNomeProc.Text = Nome

        Dim opFile As New OperazioniSuFile
        idProc = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, Nome)
        opFile = Nothing

        PulisceSchermata()

        CaricaDati()
    End Sub

    Private Sub CaricaDati()
        Dim DB As New GestioneACCESS

        If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(0, Nothing)
			Dim Rec As New ADODB.Recordset
			Dim Sql As String

			Sql = "Select * From Schedulazioni Where idProc=" & idProc
			Rec = DB.LeggeQuery(0, Sql, Nothing)
			If Rec.Eof = False Then
				Dim Giorni As String = Rec("Valore1").Value

				If Rec("TipoBackup").Value = "G" Then
					optGiorno.Checked = True
					optGiornoMese.Checked = False

					chkLunedi.Checked = False
					chkMartedi.Checked = False
					chkMercoledi.Checked = False
					chkGiovedi.Checked = False
					chkVenerdi.Checked = False
					chkSabato.Checked = False
					chkDomenica.Checked = False

					If Giorni.IndexOf("1") > -1 Then
						chkLunedi.Checked = True
					End If
					If Giorni.IndexOf("2") > -1 Then
						chkMartedi.Checked = True
					End If
					If Giorni.IndexOf("3") > -1 Then
						chkMercoledi.Checked = True
					End If
					If Giorni.IndexOf("4") > -1 Then
						chkGiovedi.Checked = True
					End If
					If Giorni.IndexOf("5") > -1 Then
						chkVenerdi.Checked = True
					End If
					If Giorni.IndexOf("6") > -1 Then
						chkSabato.Checked = True
					End If
					If Giorni.IndexOf("7") > -1 Then
						chkDomenica.Checked = True
					End If
				Else
					optGiorno.Checked = False
					optGiornoMese.Checked = True

					txtGiorni.Text = Giorni
				End If

				txtOrario.Text = Rec("Orario").Value
			Else
				optGiorno.Checked = False
				optGiornoMese.Checked = False
				optNulla.Checked = True
			End If
			Rec.Close()

			DB.ChiudeDB(True)

			ImpostaSchermata()
		End If

		DB = Nothing
	End Sub

	Private Sub PulisceSchermata()
		optGiorno.Checked = True
		optGiornoMese.Checked = False

		ImpostaSchermata()

		chkLunedi.Checked = True
		chkMartedi.Checked = True
		chkMercoledi.Checked = True
		chkGiovedi.Checked = True
		chkVenerdi.Checked = True
		chkSabato.Checked = False
		chkDomenica.Checked = False

		txtGiorni.Text = ""
		txtOrario.Text = ""
	End Sub

	Private Sub ImpostaSchermata()
		If optGiorno.Checked Then
			pnlGiorni.Enabled = True
			pnlMese.Enabled = False
			txtOrario.Enabled = True
		End If
		If optGiornoMese.Checked Then
			pnlGiorni.Enabled = False
			pnlMese.Enabled = True
			txtOrario.Enabled = True
		End If
		If optNulla.Checked Then
			pnlGiorni.Enabled = False
			pnlMese.Enabled = False
			txtOrario.Enabled = False
		End If
	End Sub

	Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
		Dim sGiorni As String = ""
		Dim sOrario As String = ""
		Dim sTipo As String = ""

		If optGiorno.Checked = True Then
			sTipo = "G"
			If chkLunedi.Checked = False And chkMartedi.Checked = False And chkMercoledi.Checked = False And
				chkGiovedi.Checked = False And chkVenerdi.Checked = False And chkSabato.Checked = False And chkDomenica.Checked = False Then
				MsgBox("Selezionare almeno un giorno di backup", vbInformation)
				Exit Sub
			Else
				If chkLunedi.Checked = True Then
					sGiorni += "1;"
				End If
				If chkMartedi.Checked = True Then
					sGiorni += "2;"
				End If
				If chkMercoledi.Checked = True Then
					sGiorni += "3;"
				End If
				If chkGiovedi.Checked = True Then
					sGiorni += "4;"
				End If
				If chkVenerdi.Checked = True Then
					sGiorni += "5;"
				End If
				If chkSabato.Checked = True Then
					sGiorni += "6;"
				End If
				If chkDomenica.Checked = True Then
					sGiorni += "7;"
				End If
			End If
		End If
		If optGiornoMese.Checked Then
			sTipo = "M"
			If txtGiorni.Text = "" Then
				MsgBox("Inserire il oppure i giorni di backup", vbInformation)
				Exit Sub
			Else
				If txtGiorni.Text.IndexOf(";") = -1 Then
					If IsNumeric(txtGiorni.Text) = False Then
						MsgBox("Giorni di backup non validi", vbInformation)
						Exit Sub
					End If
				End If
				Dim Giorni() As String = txtGiorni.Text.Split(";")
				For i As Integer = 0 To Giorni.Length - 1
					If IsNumeric(Giorni(i)) = False Then
						MsgBox("Giorni di backup non validi", vbInformation)
						Exit Sub
					Else
						If Giorni(i) < 1 Or Giorni(i) > 31 Then
							MsgBox("Giorni di backup non validi", vbInformation)
							Exit Sub
						End If
					End If
					Giorni(i) = Format(Val(Giorni(i)), "00")
				Next

				Dim Appoggio As Integer

				For i As Integer = 0 To Giorni.Length - 1
					For k As Integer = i + 1 To Giorni.Length - 1
						If Val(Giorni(i)) > Val(Giorni(k)) Then
							Appoggio = Giorni(i)
							Giorni(i) = Giorni(k)
							Giorni(k) = Appoggio
						End If
					Next
				Next

				sGiorni = ""
				For i As Integer = 0 To Giorni.Length - 1
					sGiorni += Giorni(i) & ";"
				Next

				txtGiorni.Text = sGiorni
			End If
		End If

		If Not optNulla.Checked Then
			If txtOrario.Text = "" Then
				MsgBox("Inserire l'orario di backup", vbInformation)
				Exit Sub
			Else
				Dim sControllo As Date

				Try
					sControllo = "26/02/1972 " & txtOrario.Text
				Catch ex As Exception
					MsgBox("Orario di backup non valido", vbInformation)
					Exit Sub
				End Try

				If IsDate(sControllo) = False Then
					MsgBox("Orario di backup non valido", vbInformation)
					Exit Sub
				Else
					sOrario = Format(sControllo.Hour, "00") & ":" & Format(sControllo.Minute, "00")
				End If
			End If
		End If

		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			DB.ApreDB(idProc, Nothing)
			Dim Sql As String

			Sql = "Delete From Schedulazioni Where idProc=" & idProc
			DB.EsegueSql(idProc, Sql, Nothing)

			If Not optNulla.Checked Then
				Sql = "Insert Into Schedulazioni Values (" &
					" " & idProc & ", " &
					"'" & sTipo & "', " &
					"'" & sGiorni & "', " &
					"'" & sOrario & "' " &
					")"
				DB.EsegueSql(idProc, Sql, Nothing)
			End If

			DB.ChiudeDB(True)

			MsgBox("Dati salvati", vbInformation)
        End If

        DB = Nothing
    End Sub

    Private Sub optGiorno_Click(sender As Object, e As EventArgs) Handles optGiorno.Click
        ImpostaSchermata()
    End Sub

    Private Sub optGiornoMese_Click(sender As Object, e As EventArgs) Handles optGiornoMese.Click
        ImpostaSchermata()
    End Sub

    Private Sub optNulla_CheckedChanged(sender As Object, e As EventArgs) Handles optNulla.CheckedChanged
        ImpostaSchermata()
    End Sub
End Class