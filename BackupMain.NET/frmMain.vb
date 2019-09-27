Imports Microsoft.Win32
Imports System.IO
Imports System.Net.Mail
Imports System.Runtime.InteropServices

Public Class frmMain
	'Private WithEvents lblNomeDisco As New System.Windows.Forms.Label
	'Private WithEvents lblLetteraDisco As New System.Windows.Forms.Label
	'Private WithEvents lblSerialeDisco As New System.Windows.Forms.Label
	'Private WithEvents imgDisco As New System.Windows.Forms.PictureBox
	'Private WithEvents cmdDisco As New System.Windows.Forms.Button
	'Private Dischi() As String
	'Private qDischi As Integer = -1

	Private contextMenu1 As System.Windows.Forms.ContextMenu = New System.Windows.Forms.ContextMenu

	Private mnuApri As New GestioneMenu
	Private mnuSeparatore As New GestioneMenu
	Private mnuUscita As New GestioneMenu

	Private Partenza As Boolean = True
	Private Chiusura As Boolean = False
	Private Minimizzato As Boolean = True

	Public Sub New()
		MyBase.New()

		InitializeComponent()

		mnuApri = New GestioneMenu("Verdana", 12, "Apre maschera", "Immagini\Apri.png", 24, New EventHandler(AddressOf ApreFinestra), Nothing)
		mnuUscita = New GestioneMenu("Verdana", 12, "Uscita", "Immagini\Uscita.png", 24, New EventHandler(AddressOf Uscita), Nothing)
		mnuSeparatore = New GestioneMenu("Verdana", 9, "-", "", 0, Nothing, Nothing)

		Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
							{mnuApri, mnuSeparatore, mnuUscita})

		NotifyIcon1.Icon = New Icon(Application.StartupPath & "\Immagini\la_va15.ico")
		NotifyIcon1.Text = "Backup"
		NotifyIcon1.ContextMenu = Me.contextMenu1
		NotifyIcon1.Visible = True

		Dim u As UpdateDB = New UpdateDB
		u.ControllaAggiornamentoDB(Nothing)

		Timer1.Enabled = True
	End Sub

	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		If Not Partenza Then
			' If Not Minimizzato Then
			Minimizzato = True
			Me.TopMost = False
			Me.WindowState = FormWindowState.Minimized
			Me.Hide()
			'NotifyIcon1.Visible = True
			'Else
			'Minimizzato = False
			'End If
		End If

		e.Cancel = True
		'Minimizzato = True
		'Me.TopMost = False
		'Me.WindowState = FormWindowState.Minimized
		'Me.Hide()
		''NotifyIcon1.Visible = True
	End Sub

	Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		If Partenza Then
			Me.WindowState = FormWindowState.Minimized
			Me.Hide()
			Minimizzato = True
		End If
	End Sub

	Private Sub ApreFinestra(Sender As Object, e As EventArgs) ' Handles menuItem1.Click
		Partenza = False
		Me.Show()
		Me.WindowState = FormWindowState.Normal
		Me.TopMost = True
		'NotifyIcon1.Visible = False
	End Sub

	Private Sub Uscita(Sender As Object, e As EventArgs) 'Handles menuItem2.Click
		If MsgBox("Si vuole uscire ?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
			NotifyIcon1.Visible = False
			Chiusura = True
			End
		End If
	End Sub

	Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
		'If Not Partenza Then
		'    If Not Minimizzato Then
		'        Minimizzato = True
		'        Me.TopMost = False
		'        Me.WindowState = FormWindowState.Minimized
		'        Me.Hide()
		'        'NotifyIcon1.Visible = True
		'    Else
		'        Minimizzato = False
		'    End If
		'End If
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim PercorsoDB As String

		Dim gf As New GestioneFilesDirectory
		Dim Config As String = ""
		If File.Exists("C:\BackupLog\Config\Config.dat") Then
			Config = gf.LeggeFileIntero("C:\BackupLog\Config\Config.dat")
		Else
			gf.CreaDirectoryDaPercorso("C:\BackupLog\Config\")
			gf.ApreFileDiTestoPerScrittura("C:\BackupLog\Config\Config.dat")
			Config = Application.StartupPath & "\BackupMain.NET.exe;looigi@gmail.com;pippuzzetto227!;"
			gf.ScriveTestoSuFileAperto(Config)
			gf.ChiudeFileDiTestoDopoScrittura()
		End If
		gf = Nothing

		Dim c() As String = Config.Split(";")
		If c.Length > 2 Then
			UtenzaMail = c(1)
			PasswordMail = c(2)
		Else
			UtenzaMail = "looigi@gmail.com"
			PasswordMail = "Pirpipacchio227!"
		End If

		PercorsoDB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\BackupNet", "PathDB", "")
		If Directory.Exists(PercorsoDB) = False Then
			PercorsoDB = ""
		End If
		If PercorsoDB = "" Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\BackupNet")
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\BackupNet", "PathDB", Application.StartupPath)
			PercorsoDB = Application.StartupPath
		End If

		lblPathDB.Text = PercorsoDB

		'ControllaPermessiDiScritturaSuCartellaDiLavoro(PercorsoDB)

		If File.Exists(PercorsoDB & "\DB\dbBackup.sdf") Then
			Dim g As New GestioneModificheDB
			g.ControllaDB(PercorsoDB, Nothing)
			g = Nothing
		End If

		Try
			CaricaProcedure(Nothing)
		Catch ex As Exception

		End Try

		' BUTTAMI
		'Dim Operazione2 As String = "Zippa Sorgenti"

		'Dim Ok As Boolean = False

		'For i As Integer = 0 To lstProcedure.Items.Count
		'    If lstProcedure.Items(i).ToString.ToUpper.Trim = Operazione2.ToUpper.Trim Then
		'        lstProcedure.SelectedIndex = i
		'        Ok = True
		'        Exit For
		'    End If
		'Next

		'If Ok Then
		'    Dim gf2 As New GestioneFilesDirectory
		'    gf2.CreaDirectoryDaPercorso("C:\BackupLog\Dati\")
		'    gf2 = Nothing

		'    Dim datella As String = Now.Year & Format(Now.Month, "00") & Format(Now.Day, "00") & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00")
		'    File.Copy(PercorsoDB & "\DB\dbBackup.mdb", "C:\BackupLog\Dati\Dbtemp" & datella & ".mdb")
		'    PercorsoDB = "C:\BackupLog\Dati\Dbtemp" & datella & ".mdb"
		'    PercorsoDBTemp = PercorsoDB

		'    ModalitaEsecuzioneAutomatica = True
		'    Call lstProcedure_DoubleClick(sender, e)
		'End If
		' BUTTAMI

		ControllaNuoveTabelle()

		Dim CommandLineArguments As String() = Environment.GetCommandLineArgs()

		If CommandLineArguments.Length > 2 Then
			If CommandLineArguments(1) = "/RUN" Then
				Dim Operazione As String = CommandLineArguments(2)

				Dim Ok2 As Boolean = False

				For i As Integer = 0 To lstProcedure.Items.Count
					If lstProcedure.Items(i).ToString.ToUpper.Trim = Operazione.ToUpper.Trim Then
						lstProcedure.SelectedIndex = i
						Ok2 = True
						Exit For
					End If
				Next

				If Ok2 Then
					Dim gf2 As New GestioneFilesDirectory
					gf2.CreaDirectoryDaPercorso("C:\BackupLog\Dati\")
					gf2 = Nothing

					Dim datella As String = Now.Year & Format(Now.Month, "00") & Format(Now.Day, "00") & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00")
					File.Copy(PercorsoDB & "\DB\dbBackup.mdb", "C:\BackupLog\Dati\Dbtemp" & datella & ".mdb")
					PercorsoDB = "C:\BackupLog\Dati\Dbtemp" & datella & ".mdb"
					PercorsoDBTemp = PercorsoDB

					Timer1.Enabled = False

					ModalitaEsecuzioneAutomatica = True
					Call lstProcedure_DoubleClick(sender, e)
				End If
			Else
				ModalitaEsecuzioneAutomatica = False
			End If
		Else
			ModalitaEsecuzioneAutomatica = False
		End If

	End Sub

	Private Sub ControllaNuoveTabelle()
		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			Dim ConnSQL As Object = DB.ApreDB(0, Nothing)
			Dim Rec As Object = CreateObject("ADODB.Recordset")
			Dim Sql As String

			Sql = "Select * From UltimeDirOrig"
			Rec = DB.LeggeQuery(0, ConnSQL, Sql, Nothing)
			If Rec Is Nothing Then
				Sql = "Create Table UltimeDirOrig (Dir Memo, PRIMARY KEY (Dir))"
				DB.EsegueSql(-1, ConnSQL, Sql, Nothing)
			Else
				Rec.Close
			End If

			'Sql = "Select * From UltimeDirDestin"
			'Rec = DB.LeggeQuery(0, ConnSQL, Sql, Nothing)
			'If Rec Is Nothing Then
			'	Sql = "Create Table UltimeDirDestin (Dir Memo, PRIMARY KEY (Dir))"
			'	DB.EsegueSql(-1, ConnSQL, Sql, Nothing)
			'Else
			'	Rec.Close
			'End If
		End If

		DB = Nothing
	End Sub
	'Private Sub ControllaPermessiDiScritturaSuCartellaDiLavoro(PercorsoDB As String)
	'    Dim gf As New GestioneFilesDirectory
	'    gf.EliminaFileFisico(PercorsoDB & "\Db\Buttami.txt")
	'    Try
	'        gf.CreaAggiornaFile(PercorsoDB & "\Db\Buttami.txt", "prova")
	'    Catch ex As Exception

	'    End Try
	'    If File.Exists(PercorsoDB & "\Db\Buttami.txt") = False Then
	'        Dim p As Process = New Process()
	'        Dim pi As ProcessStartInfo = New ProcessStartInfo()
	'        Dim permanent As Boolean = True
	'        Dim command As String = "icacls """ & PercorsoDB & "\Db"""
	'        Dim arguments As String = "/grant Users:(OI)(CI)F /t"

	'        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments
	'        pi.FileName = "cmd.exe"
	'        p.StartInfo.CreateNoWindow = True
	'        p.StartInfo = pi
	'        p.Start()
	'        p.WaitForExit()
	'    End If
	'    gf.EliminaFileFisico(PercorsoDB & "\Db\Buttami.txt")
	'    gf = Nothing
	'End Sub

	Public Sub CaricaProcedure(clLog As LogCasareccio.LogCasareccio.Logger)
		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			Dim ConnSQL As Object = DB.ApreDB(0, clLog)
			Dim Rec As Object = CreateObject("ADODB.Recordset")
			Dim Sql As String

			lstProcedure.Items.Clear()
			'cmbProcedure.Items.Add("")
			'cmbProcedure.Items.Add("NUOVA PROCEDURA")

			Sql = "Select * From NomiProcedure Order By NomeProcedura"
			Rec = DB.LeggeQuery(0, ConnSQL, Sql, clLog)
			Do Until Rec.Eof
				lstProcedure.Items.Add(Rec("NomeProcedura").Value)

				Rec.MoveNext()
			Loop
			Rec.Close()

			ConnSQL.close()
			ConnSQL = Nothing

			lstProcedure.Text = ""

			DB.ChiudeDB(True, ConnSQL)
		End If

		cmdElimina.Visible = True
		DB = Nothing
	End Sub

	Private Sub DisegnaDischi(Optional pDischi() As String = Nothing, Optional qDischi2 As Integer = -1)
		'If qDischi2 = -1 Then
		'    Dim gfd As New GestioneFilesDirectory
		'    Dischi = gfd.RitornaDischi
		'    qDischi = Dischi.Count - 1
		'    gfd = Nothing
		'Else
		'    Dischi = pDischi
		'    qDischi = qDischi2
		'End If

		'Dim y As Integer = 3
		'Dim x As Integer = 3
		'Dim Immagine As String = ""
		'Dim Campi() As String

		'For i As Integer = 0 To qDischi
		'    If Dischi(i) <> "" Then
		'        Campi = Dischi(i).Split(";")

		'        lblNomeDisco = New Label
		'        lblNomeDisco.Size = New Size(300, 20)
		'        lblNomeDisco.Location = New Point(x + 105, y + 15)
		'        lblNomeDisco.Font = New Font("Arial", "10", FontStyle.Bold, GraphicsUnit.Point)
		'        lblNomeDisco.Text = Campi(5)

		'        lblLetteraDisco = New Label
		'        lblLetteraDisco.Size = New Size(40, 20)
		'        lblLetteraDisco.Location = New Point(x + 60, y + 20)
		'        lblLetteraDisco.Font = New Font("Arial", "10", FontStyle.Bold, GraphicsUnit.Point)
		'        lblLetteraDisco.Text = Campi(7)

		'        lblSerialeDisco = New Label
		'        lblSerialeDisco.Size = New Size(300, 20)
		'        lblSerialeDisco.Location = New Point(x + 105, y + 35)
		'        lblSerialeDisco.Font = New Font("Arial", "7", FontStyle.Regular, GraphicsUnit.Point)
		'        lblSerialeDisco.Text = Campi(6)

		'        Select Case Campi(0)
		'            Case "CD-ROM"
		'                Immagine = "CD.jpg"
		'            Case "Disco Fisso"
		'                Immagine = "hd.jpg"
		'            Case "Rimuovibile"
		'                Immagine = "usb.jpg"
		'            Case "Sconosciuto"
		'                Immagine = "floppy.jpg"
		'        End Select

		'        imgDisco = New PictureBox
		'        imgDisco.Width = 55
		'        imgDisco.Height = 55
		'        imgDisco.ImageLocation = "Immagini\" & Immagine
		'        imgDisco.SizeMode = PictureBoxSizeMode.StretchImage
		'        imgDisco.BorderStyle = BorderStyle.FixedSingle
		'        imgDisco.Top = y
		'        imgDisco.Left = x

		'        cmdDisco = New Button
		'        cmdDisco.Size = New Size(40, 40)
		'        cmdDisco.Location = New Point(x + 405, y + 5)
		'        cmdDisco.Name = i
		'        cmdDisco.Text = "->"

		'        y += 60

		'        'AddHandler cmdDisco.Click, AddressOf cmdDisco_onClick

		'        'Me.Controls.Add(cmdDisco)
		'        Me.Controls.Add(lblNomeDisco)
		'        Me.Controls.Add(lblLetteraDisco)
		'        Me.Controls.Add(lblSerialeDisco)
		'        Me.Controls.Add(imgDisco)
		'    End If
		'Next

		'cmdRoutine.Top = y ' + 40
		'cmdRoutine.Visible = True

		'cmbProcedure.Top = y ' + 40
		'cmbProcedure.Visible = True

		'Dim sx As Integer = My.Computer.Screen.Bounds.Width
		'Dim sy As Integer = My.Computer.Screen.Bounds.Height

		'Me.Height = y + 70
		'Me.Top = (sy / 2) - (Me.Height / 2)
	End Sub

	'Private Sub cmdDisco_onClick(sender As Object, e As EventArgs)
	'    Dim b As Button = DirectCast(sender, Button)
	'    Dim nome As String = b.Name

	'    MsgBox(nome)
	'End Sub

	Private Sub cmdRoutine_Click(sender As Object, e As EventArgs) Handles cmdRoutine.Click
		'Dim NomeProc As String = cmbProcedure.Text

		'If NomeProc = "" Then
		'    MsgBox("Selezionare una procedura", MsgBoxStyle.Information)
		'    Exit Sub
		'End If

		'If NomeProc = "NUOVA PROCEDURA" Then
		'NomeProc = ""
		'End If

		NomeProceduraScelta = ""

		'Dim Ok As Boolean = True
		'Dim Quale As Integer

		'For i As Integer = 1 To qMaschereProcedura
		'    If MascheraProcedura(i) Is Nothing Then
		'        Quale = i
		'        Ok = False
		'        Exit For
		'    End If
		'Next
		'If Ok Then
		'    qMaschereProcedura += 1
		'    ReDim Preserve MascheraProcedura(qMaschereProcedura)
		'    MascheraProcedura(qMaschereProcedura) = New frmProcedura
		'    Quale = qMaschereProcedura
		'Else
		'    MascheraProcedura(Quale) = New frmProcedura
		'End If

		'MascheraProcedura(Quale).ImpostaNomeProcedura("", Quale)
		'MascheraProcedura(Quale).Show()

		frmProcedura.ImpostaNomeProcedura("", -1)
		frmProcedura.Show()

		Me.Hide()
	End Sub

	Private Sub lstProcedure_DoubleClick(sender As Object, e As EventArgs) Handles lstProcedure.DoubleClick
		Dim NomeProc As String = lstProcedure.Text

		If NomeProc = "" Then
			MsgBox("Selezionare una procedura", MsgBoxStyle.Information)
			Exit Sub
		End If

		NomeProceduraScelta = NomeProc

		'Dim Ok As Boolean = True
		'Dim Quale As Integer

		'For i As Integer = 0 To qMaschereProcedura - 1
		'    If MascheraProcedura(i) Is Nothing Then
		'        Quale = i
		'        Ok = False
		'        Exit For
		'    End If
		'Next
		'If Ok Then
		'    qMaschereProcedura += 1
		'    ReDim Preserve MascheraProcedura(qMaschereProcedura)
		'    MascheraProcedura(qMaschereProcedura) = New frmProcedura
		'    Quale = qMaschereProcedura
		'Else
		'    ReDim Preserve MascheraProcedura(0)
		'    MascheraProcedura(Quale) = New frmProcedura
		'End If

		'MascheraProcedura(Quale).ImpostaNomeProcedura(NomeProc, Quale)
		'MascheraProcedura(Quale).Show()

		frmProcedura.ImpostaNomeProcedura(NomeProc, -1)
		frmProcedura.Show()

		If ModalitaEsecuzioneAutomatica Then
			Me.Top = -1000
			Me.ShowInTaskbar = False
		Else
			Me.WindowState = FormWindowState.Minimized
			Me.Hide()
			Minimizzato = True
		End If
	End Sub

	Private Sub cmdSetup_Click(sender As Object, e As EventArgs) Handles cmdSetup.Click
		frmSettaggi.Show()

		Me.Hide()
	End Sub

	Private Sub cmdUscita_Click(sender As Object, e As EventArgs) Handles cmdUscita.Click
		If MsgBox("Si vuole uscire ?", vbYesNo + vbInformation + vbDefaultButton2) = vbYes Then
			NotifyIcon1.Visible = False
			Chiusura = True
			End
		End If
	End Sub

	Private Sub lstProcedure_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProcedure.SelectedIndexChanged
		cmdElimina.Visible = True
	End Sub

	Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
		If MsgBox("Si è sicuri di voler eliminare la procedura '" & lstProcedure.Text & "'", vbYesNo + vbInformation + vbDefaultButton2) = vbNo Then
			Exit Sub
		End If

		Dim opFile As New OperazioniSuFile
		Dim idProc As Integer = opFile.CaricaRigheProcedura(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, lstProcedure.Text)
		opFile = Nothing

		Dim DB As New GestioneACCESS

		If DB.LeggeImpostazioniDiBase(ModalitaEsecuzioneAutomatica, PercorsoDBTemp, "ConnDB") = True Then
			Dim ConnSQL As Object = DB.ApreDB(idProc, Nothing)
			Dim Sql As String

			Sql = "Delete From NomiProcedure Where idProc=" & idProc
			DB.EsegueSql(idProc, ConnSQL, Sql, Nothing)

			Sql = "Delete From Schedulazioni Where idProc=" & idProc
			DB.EsegueSql(idProc, ConnSQL, Sql, Nothing)

			Sql = "Delete From DettaglioProcedure Where idProc=" & idProc
			DB.EsegueSql(idProc, ConnSQL, Sql, Nothing)

			ConnSQL.close()
			ConnSQL = Nothing

			DB.CompattazioneDb()
			DB.ChiudeDB(True, ConnSQL)
		End If

		DB = Nothing

		MsgBox("Procedura eliminata", vbInformation)

		CaricaProcedure(Nothing)
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Timer1.Enabled = False

		Dim ope As New OperazioniDaEseguire
		ope.ControllaOperazioni(Application.StartupPath & "\")

		Timer1.Enabled = True
	End Sub


End Class