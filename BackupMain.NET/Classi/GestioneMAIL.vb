Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime

Public Class GestioneMAIL
    Public Sub InvioMAIL(Utenza As String, Password As String, Oggetto As String, Testo As String, Optional sAttachment As String = "", Optional sAttachment2 As String = "")
        Dim errore As Boolean = False
        If Utenza <> "" Then
            ' Dim campiUtenza() As String = Utenza.Split(";")

            Dim CasellaDiPosta As String = ""
            Dim PasswordCasellaDiPosta As String = ""

            Dim PercorsoFile As String = "C:\AAA-SettaggiPerApp\Posta.txt"

            Dim gf As New GestioneFilesDirectory
            Dim Cartella As String = gf.TornaNomeDirectoryDaPath(PercorsoFile) & "\"
            gf.CreaDirectoryDaPercorso(Cartella)
            Dim NomeFile As String = PercorsoFile
            Dim riga As String = ""
            If File.Exists(NomeFile) Then
                riga = gf.LeggeFileIntero(NomeFile)
            Else
                riga = "UTENTE:looigi@gmail.com;PASSWORD:pippuzzetto227!"
                gf.CreaAggiornaFile(PercorsoFile, riga)
                If Not File.Exists(NomeFile) Then
                    ' MsgBox("Problemi nella scrittura del file di posta.<br /><br />" & NomeFile)
                End If
            End If
            If riga.Contains(";") Then
                Dim campi() As String = riga.Split(";")

                If campi.Length > 1 Then
                    If campi(0).Contains("UTENTE:") Then
                        CasellaDiPosta = campi(0).Replace("UTENTE:", "")
                    Else
                        ' MsgBox("Il primo campo del file di configurazione della posta<br /><br />" & NomeFile & "<br /><br />deve contenere la stringa 'UTENTE:'<br /><br />Contenuto: " & riga)
                    End If
                    If campi(1).Contains("PASSWORD:") Then
                        PasswordCasellaDiPosta = campi(1).Replace("PASSWORD:", "")
                    Else
                        ' MsgBox("Il secondo campo del file di configurazione della posta<br /><br />" & NomeFile & "<br /><br />deve contenere la stringa 'PASSWORD:'<br /><br />Contenuto: " & riga)
                    End If
                Else
                    ' MsgBox("Problemi nella lettura del file di posta.<br /><br />" & NomeFile & "<br /><br />Campi non validi: " & riga & "<br />Dovrebbero essere nel formato: UTENTE:looigi@gmail.com;PASSWORD:xxxxx")
                End If
            Else
                ' MsgBox("Problemi nella lettura del file di posta.<br /><br />" & NomeFile & "<br /><br />Campi non validi: " & riga & "<br />Dovrebbero essere nel formato: UTENTE:looigi@gmail.com;PASSWORD:xxxxx")
            End If

            Try
                Dim Mail As New MailMessage

                Mail.Subject = Oggetto
                Mail.From = New MailAddress(CasellaDiPosta)
                Mail.To.Add(CasellaDiPosta)
                Mail.Body = Testo 'Message Here
                If sAttachment <> "" Then
                    Dim data As Attachment = New Attachment(sAttachment, MediaTypeNames.Application.Octet)

                    Mail.Attachments.Add(data)
                End If
                If sAttachment2 <> "" Then
                    Dim data As Attachment = New Attachment(sAttachment2, MediaTypeNames.Application.Octet)

                    Mail.Attachments.Add(data)
                End If

                System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf RemoteServerCertificateValidationCallback)

                Dim SMTP As New SmtpClient("smtp.gmail.com")

                SMTP.Credentials = New System.Net.NetworkCredential(CasellaDiPosta, PasswordCasellaDiPosta)
                SMTP.Port = "587"
                SMTP.EnableSsl = True

                SMTP.Send(Mail)

                ScriveLogPosta(" OK")
            Catch ex As SmtpException
                ScriveLogPosta("Errore " & ex.Message)
                errore = True
            Catch ex As Exception
                ScriveLogPosta("Errore " & ex.Message)
                errore = True
            End Try
            gf = Nothing

            If Not errore Then
                If sAttachment <> "" Then
                    Try
                        Kill(sAttachment)
                    Catch ex As Exception

                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub ScriveLogPosta(Messaggio As String)
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
        Dim df As String = d.Year & "-" & m & "-" & g & " " & h & ":" & mm & ":" & s

        Dim gf As New GestioneFilesDirectory
        gf.CreaAggiornaFile("C:\BackupLog\MAIL.log", df & " -> " & Messaggio)
        gf = Nothing
    End Sub

    Private Function RemoteServerCertificateValidationCallback(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Console.WriteLine(certificate)
        Return True
    End Function
End Class
