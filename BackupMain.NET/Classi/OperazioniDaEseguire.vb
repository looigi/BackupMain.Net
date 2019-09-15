Public Class OperazioniDaEseguire
	Private MinutoElaborazione As Integer = -1
	Private idProceduraDaEseguire() As String = {}
	Private qId As Integer = 0

	Public Sub ControllaOperazioni(Path As String)
		Dim opFiles As RoutineVarie = New RoutineVarie
		'opFiles.PulisceNomeFileLog()

		If MinutoElaborazione <> Now.Minute Then
			MinutoElaborazione = Now.Minute

			TornaOperazioniDaEseguire(opFiles)

			If Not idProceduraDaEseguire Is Nothing Then
				If idProceduraDaEseguire.Length - 1 > -1 Then
					For i As Integer = 1 To idProceduraDaEseguire.Length - 1
						If idProceduraDaEseguire(i) <> "" Then
							opFiles.ScriveLogServizio(1, "")
							opFiles.ScriveLogServizio(1, "-----------------------------------------------------------")
							opFiles.ScriveLogServizio(1, "Eseguo procedura: " & idProceduraDaEseguire(i))

							EsegueProcedura(Path, idProceduraDaEseguire(i), opFiles)

							opFiles.ScriveLogServizio(1, "-----------------------------------------------------------")
							opFiles.ScriveLogServizio(1, "")
						End If
					Next
				End If
			End If
		End If
		opFiles = Nothing
	End Sub

	Private Sub TornaOperazioniDaEseguire(opFiles As RoutineVarie)
		Try
			qId = 0
			Erase idProceduraDaEseguire

			Dim DB As GestioneACCESS = New GestioneACCESS

			If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
				Dim ConnSQL As Object = DB.ApreDB(qId, Nothing)

				Dim Rec As Object = CreateObject("ADODB.Recordset")
				Dim Sql As String

				' Controlla se esistono backup per l'ora e il giorno della settimana
				Sql = "Select B.NomeProcedura From Schedulazioni A Left Join NomiProcedure B On A.idProc=B.idProc " &
					"Where " &
					"TipoBackup='G' And " &
					"Instr(Valore1, '" & TornaNumeroGiornoSettimana() & ";')>0 And " &
					"Orario='" & TornaOrario() & "'"

				'opFiles.ScriveLogServizio(idProc, "Controlla se esistono backup per l'ora e il giorno della settimana")
				'opFiles.ScriveLogServizio(idProc, Sql)

				Rec = DB.LeggeQuery(0, ConnSQL, Sql, Nothing)
				Do Until Rec.Eof
					qId += 1
					ReDim Preserve idProceduraDaEseguire(qId)
					idProceduraDaEseguire(qId) = Rec("NomeProcedura").Value

					Rec.MoveNext()
				Loop
				Rec.Close()

				' Controlla se esistono backup per l'ora e il giorno del mese
				Sql = "Select B.NomeProcedura From Schedulazioni A Left Join NomiProcedure B On A.idProc=B.idProc " &
					"Where " &
					"TipoBackup='M' And " &
					"Instr(Valore1, '" & TornaNumeroGiornoMese() & ";')>0 And " &
					"Orario='" & TornaOrario() & "'"

				'opFiles.ScriveLogServizio(idProc, "Controlla se esistono backup per l'ora e il giorno del mese")
				'opFiles.ScriveLogServizio(idProc, Sql)

				Rec = DB.LeggeQuery(0, ConnSQL, Sql, Nothing)
				Do Until Rec.Eof
					qId += 1
					ReDim Preserve idProceduraDaEseguire(qId)
					idProceduraDaEseguire(qId) = Rec("NomeProcedura").Value

					Rec.MoveNext()
				Loop
				Rec.Close()

				ConnSQL.close()
				ConnSQL = Nothing
			Else
				opFiles.ScriveLogServizio(1, "ERRORE SU APERTURA DB")
			End If

			DB = Nothing
		Catch ex As Exception
			opFiles.ScriveLogServizio(1, "ERRORE PROCEDURALE: " & ex.Message)
		End Try
	End Sub

	Private Function TornaOrario() As String
		Dim Ora As String = Format(Now.Hour, "00") & ":" & Format(Now.Minute, "00")

		Return Ora
	End Function

	Private Function TornaNumeroGiornoMese() As String
		Dim Giorno As String = Format(Now.Day, "00")

		Return Giorno
	End Function

	Private Function TornaNumeroGiornoSettimana() As String
		Dim numGiorno As Integer = Now.DayOfWeek
		Dim Ritorno As String = ""

		Select Case numGiorno
			Case DayOfWeek.Monday
				Ritorno = "1"
			Case DayOfWeek.Tuesday
				Ritorno = "2"
			Case DayOfWeek.Wednesday
				Ritorno = "3"
			Case DayOfWeek.Thursday
				Ritorno = "4"
			Case DayOfWeek.Friday
				Ritorno = "5"
			Case DayOfWeek.Saturday
				Ritorno = "6"
			Case DayOfWeek.Sunday
				Ritorno = "7"
		End Select

		Return Ritorno
	End Function

	Private Sub EsegueProcedura(PercorsoApplicazione As String, NomeProcedura As String, opFiles As RoutineVarie)
		Dim p As Process = New Process()
		p.StartInfo.FileName = PercorsoApplicazione & "BackupMain.NET.exe"
		p.StartInfo.Arguments = "/RUN " & Chr(34) & NomeProcedura & Chr(34)
		p.StartInfo.UseShellExecute = False
		p.StartInfo.RedirectStandardOutput = True
		p.Start()

		Dim output As String = p.StandardOutput.ReadToEnd()
		p.WaitForExit()
	End Sub
End Class
