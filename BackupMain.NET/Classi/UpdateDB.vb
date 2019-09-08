Public Class UpdateDB
    Public VersioneDBApplicazione As Integer = 1

    Public Sub ControllaAggiornamentoDB(clLog As LogCasareccio.LogCasareccio.Logger)
        Dim DB As New GestioneACCESS

        If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp , "ConnDB") = True Then
            Dim ConnSQL As Object = DB.ApreDB(0, clLog)
            Dim Rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String

            Sql = "Select * From VersioneDB"
            Rec = DB.LeggeQuery(0, ConnSQL, Sql, clLog)
            If Rec Is Nothing = True Then
                Sql = "Create Table VersioneDB (Versione int)"
            Else
                Sql = ""
            End If
            Try
                Rec.Close()
            Catch ex As Exception

            End Try

            If Sql <> "" Then
                DB.EsegueSql(0, ConnSQL, Sql, clLog)

                Sql = "Insert Into VersioneDB Values(-1)"
                DB.EsegueSql(0, ConnSQL, Sql, clLog)
            End If

            EsegueAggiornamentoDB(DB, ConnSQL, clLog)

            ConnSQL.Close()
            DB = Nothing
        End If
    End Sub

    Private Sub EsegueAggiornamentoDB(DB As GestioneACCESS, Conn As Object, clLog As LogCasareccio.LogCasareccio.Logger)
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        Dim VersioneDB As Integer = 0

        Sql = "Select Versione From VersioneDB"
        rec = DB.LeggeQuery(0, Conn, Sql, clLog)
        If Not rec Is Nothing Then
            If rec.eof Then
                VersioneDB = 0
            Else
                VersioneDB = rec(0).value
            End If
            rec.close()
        End If

        If VersioneDB < VersioneDBApplicazione Then
            If VersioneDB = -1 Then
                Sql = "Alter Table DettaglioProcedure Alter Column Filtro Text(255)"
                DB.EsegueSql(0, Conn, Sql, clLog)
            End If

            Sql = "Update VersioneDB Set Versione=" & VersioneDBApplicazione
            DB.EsegueSql(0, Conn, Sql, clLog)
        End If
    End Sub
End Class
