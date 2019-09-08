Imports System.Collections.Specialized
Imports System.IO
Imports Ionic.Zip

Public Class frmSettaggi

    Private Sub frmSettaggi_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        frmMain.Show()
    End Sub

    Private Sub frmSettaggi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim opFiles As New OperazioniSuFile
        Dim LetteraLibera As String = opFiles.PrendeLetteraDiscoLibero
        Dim LetteraDisco As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", "")
        If LetteraDisco = "" Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", LetteraLibera)
        End If
        txtLettera.Text = LetteraDisco
        opFiles = Nothing
    End Sub

    Private Sub txtLettera_LostFocus(sender As Object, e As EventArgs) Handles txtLettera.LostFocus
        'If txtLettera.Text = "" Then
        '    MsgBox("Impostare una lettera", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        'Dim Lettera As String = txtLettera.Text
        'Dim opFiles As New OperazioniSuFile

        'If opFiles.EsisteLetteraDisco(Lettera) Then
        '    MsgBox("La lettera del disco esiste già.", MsgBoxStyle.Exclamation)
        '    txtLettera.Text = ""
        'End If

        'opFiles = Nothing
    End Sub

    Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
        If txtLettera.Text = "" Then
            MsgBox("Impostare una lettera", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim Lettera As String = txtLettera.Text
        Dim opFiles As New OperazioniSuFile

        If opFiles.EsisteLetteraDisco(Lettera) Then
            MsgBox("La lettera del disco esiste già.", MsgBoxStyle.Exclamation)
            txtLettera.Text = ""
        End If

        opFiles = Nothing

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", txtLettera.Text)
    End Sub

    Private Sub cmdEliminaDatiSI_Click(sender As Object, e As EventArgs) Handles cmdEliminaDatiSI.Click
        If MsgBox("Si è sicuri di voler eliminare tutti i dati della sincronia intelligente ?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
            Dim DB As New GestioneACCESS

            If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
                Dim ConnSQL As Object = DB.ApreDB(0, Nothing)
                Dim Rec As Object = CreateObject("ADODB.Recordset")
                Dim Sql As String

                Sql = "Delete From FilesOrigine"
                DB.EsegueSql(0, ConnSQL, Sql, Nothing)

                Sql = "Delete From FilesOrigine"
                DB.EsegueSql(0, ConnSQL, Sql, Nothing)

                Sql = "Delete From FileDestinazioneIntelligente"
                DB.EsegueSql(0, ConnSQL, Sql, Nothing)

                DB.ChiudeDB(True, ConnSQL)
            End If

            DB = Nothing

            Dim opFiles As New GestioneACCESS
            opFiles.CompattazioneDb()
            opFiles = Nothing

            MsgBox("Dati eliminati", vbInformation)
        End If
    End Sub

    Private Sub btnEliminaVecchiFiles_Click(sender As Object, e As EventArgs) Handles btnEliminaVecchiFiles.Click
		Dim q As Integer = EliminaFilesVecchi(Me)
		MsgBox("Files eliminati: " & q, vbInformation)
    End Sub
End Class