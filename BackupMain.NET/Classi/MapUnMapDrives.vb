Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class MapUnMapDrives
    Private Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer
    Public Const RESOURCETYPE_DISK As Long = &H1
    Private Const ERROR_BAD_NETPATH = 53&
    Private Const ERROR_NETWORK_ACCESS_DENIED = 65&
    Private Const ERROR_INVALID_PASSWORD = 86&
    Private Const ERROR_NETWORK_BUSY = 54&

    Private Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure

    Public Function RitornaLetteraLibera() As String
        Dim LetteraDisco As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", "")
        If LetteraDisco = "" Then
            Dim LetteraLibera As String = FindNextAvailableDriveLetter()
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\BackupNet", "LetteraDisco", LetteraLibera)
        End If

        Return LetteraDisco
    End Function

    Private Declare Function WNetCancelConnection Lib "mpr.dll" Alias "WNetCancelConnectionA" (ByVal lpszName As String, ByVal bForce As Long) As Long 'do we force the disconnect or not

    Private Sub Attendi(Secondi As Integer)
        Dim a As Single = Now.Second

        Do While Now.Second - a < Secondi Or a > Now.Second
            Application.DoEvents()
        Loop
    End Sub

    Public Function MappaDiscoDiRete(Lettera As String, Percorso As String, sUtente As String, sPassword As String) As Boolean
        ' Dim Lettera As String = RitornaLetteraLibera()
        Dim sPercorso As String = Percorso

        If Mid(sPercorso, sPercorso.Length, 1) = "\" Then
            sPercorso = Mid(sPercorso, 1, sPercorso.Length - 1)
        End If

        'SMappaDiscoDiRete(Percorso, True)
        'SMappaDiscoDiRete(Lettera, False)

        Dim nr As NETRESOURCE
        Dim strUsername As String
        Dim strPassword As String

        nr = New NETRESOURCE
        nr.lpRemoteName = Percorso
        nr.lpLocalName = Lettera & ":"
        strUsername = sUtente
        strPassword = sPassword
        nr.dwType = RESOURCETYPE_DISK

        Dim result As Integer
        result = WNetAddConnection2(nr, strPassword, strUsername, 0)

        If result = 0 Then
            Return True
        Else
            Select Case result
                Case ERROR_BAD_NETPATH
                    'statusBarMsg("QA4001I", "Bad path could not connect to Star Directory")
                    Return "Bad path could not connect to Star Directory"
                Case ERROR_INVALID_PASSWORD
                    'statusBarMsg("QA4002I", "Invalid password could not connect to Star Directory")
                    Return "Invalid password could not connect to Star Directory"
                Case ERROR_NETWORK_ACCESS_DENIED
                    'statusBarMsg("QA4003I", "Network access denied could not connect to Star Directory")
                    Return "Network access denied could not connect to Star Directory"
                Case ERROR_NETWORK_BUSY
                    'statusBarMsg("QA4004I", "Network busy could not connect to Star Directory")
                    Return "Network busy could not connect to Star Directory"
            End Select
            Return False
        End If

        'If result = 0 Then
        '    Return True
        'Else
        '    Return False
        'End If

        Attendi(2)
    End Function

    <DllImport("mpr.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub SMappaDiscoDiRete()

    End Sub

    Public Function SMappaDiscoDiRete(Cosa As String, Percorso As Boolean) As Boolean
        Dim lngCancel As Long = 0
        Dim Altro As String = ":"

        If Percorso Then
            Altro = ""
        End If

        Try
            lngCancel = WNetCancelConnection(Cosa & altro, True)
        Catch ex As Exception

        End Try

        If lngCancel = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
