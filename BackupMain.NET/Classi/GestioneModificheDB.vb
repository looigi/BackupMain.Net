Public Class GestioneModificheDB
    Public Sub ControllaDB(PercorsoDb As String, clLog As LogCasareccio.LogCasareccio.Logger)
        Dim DBSQLCE As New GestioneACCESS
        Dim DBAccess As New GestioneACCESS
        Dim CopiateTabelle As Boolean = False

        If DBSQLCE.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB", 2) = True Then
            Dim ConnSQLCE As Object = DBSQLCE.ApreDB(0, clLog)
            Dim Rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String = ""

            If DBAccess.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB", 1) = True Then
                Dim ConnAccess As Object = DBAccess.ApreDB(0, clLog)

                If Not CopiateTabelle Then
                    Dim NomiTabelle() As String = {"DettaglioProcedure", "FileDestinazioneIntelligente", "FilesDestinazione", "NomiProcedure", "Schedulazioni"}
                    Dim Campi() As Integer = {13, 5, 2, 6, 3}
                    Dim Riga As Long

                    For i As Integer = 0 To NomiTabelle.Length - 1
                        Riga = 0

                        Sql = "Delete From " & NomiTabelle(i)
                        DBAccess.EsegueSql(0, ConnAccess, Sql, clLog)

                        Sql = "Select * From " & NomiTabelle(i)
                        Rec = DBSQLCE.LeggeQuery(0, ConnSQLCE, Sql, clLog)
                        Do Until Rec.Eof
                            Sql = "Insert Into " & NomiTabelle(i) & " Values ("
                            For k As Integer = 0 To Campi(i)
                                Sql &= "'" & Rec(k).Value.ToString.Replace("'", "''") & "', "
                            Next
                            Sql = Mid(Sql, 1, Sql.Length - 2)
                            Sql &= ")"
                            DBAccess.EsegueSql(0, ConnAccess, Sql, clLog)

                            Riga += 1
                            If Riga / 50 = Int(Riga / 50) Then
                                frmMain.lblTitolo.Text = NomiTabelle(i) & ": " & Riga
                                Application.DoEvents()
                            End If
                            Rec.MoveNext()
                        Loop
                        Rec.Close()
                    Next

                    frmMain.lblTitolo.Text = "Lista procedure"
                    Application.DoEvents()
                End If
            End If
        End If

        DBSQLCE = Nothing
        DBAccess = Nothing

        Rename(PercorsoDb & "\db\dbBackup.sdf", PercorsoDb & "\db\dbBackup.old.sdf")
    End Sub
End Class
