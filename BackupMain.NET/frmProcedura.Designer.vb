<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedura
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcedura))
		Me.lstOperazioni = New System.Windows.Forms.ListBox()
		Me.cmbOperazioni = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblTitOrig = New System.Windows.Forms.Label()
		Me.lblTitDest = New System.Windows.Forms.Label()
		Me.cmdSceltaOrig = New System.Windows.Forms.Button()
		Me.cmdSceltaDest = New System.Windows.Forms.Button()
		Me.lblTitFiltro = New System.Windows.Forms.Label()
		Me.txtFiltro = New System.Windows.Forms.TextBox()
		Me.chkSovrascrivi = New System.Windows.Forms.CheckBox()
		Me.chkSottodirectory = New System.Windows.Forms.CheckBox()
		Me.lblNomeProc = New System.Windows.Forms.Label()
		Me.cmdElimina = New System.Windows.Forms.Button()
		Me.cmdSalva = New System.Windows.Forms.Button()
		Me.lblProgressivo = New System.Windows.Forms.Label()
		Me.cmdPulisce = New System.Windows.Forms.Button()
		Me.txtNomeProcedura = New System.Windows.Forms.TextBox()
		Me.lblTitNomeProc = New System.Windows.Forms.Label()
		Me.cmdCancella = New System.Windows.Forms.Button()
		Me.cmdRinomina = New System.Windows.Forms.Button()
		Me.cmdSu = New System.Windows.Forms.Button()
		Me.cmdGiu = New System.Windows.Forms.Button()
		Me.lblDestinazione = New System.Windows.Forms.TextBox()
		Me.lblOrigine = New System.Windows.Forms.TextBox()
		Me.pnlOrigine = New System.Windows.Forms.Panel()
		Me.cmdTestO = New System.Windows.Forms.Button()
		Me.txtPasswordOrigine = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtUtenzaOrigine = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.pnlDestinazione = New System.Windows.Forms.Panel()
		Me.cmdTestD = New System.Windows.Forms.Button()
		Me.txtPasswordDestinazione = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtUtenzaDestinazione = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.cmdSopraSotto = New System.Windows.Forms.Button()
		Me.chkAttivo = New System.Windows.Forms.CheckBox()
		Me.cmdCopia = New System.Windows.Forms.Button()
		Me.cmdAttivaTutti = New System.Windows.Forms.Button()
		Me.cmdDisattivaTutti = New System.Windows.Forms.Button()
		Me.pnlOperazioni = New System.Windows.Forms.Panel()
		Me.cmdEliminaTutti = New System.Windows.Forms.Button()
		Me.cmdEliminaDatiSincInt = New System.Windows.Forms.Button()
		Me.lblTitOperazione = New System.Windows.Forms.Label()
		Me.pnlAttivazione = New System.Windows.Forms.Panel()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.pnlRigheSI = New System.Windows.Forms.Panel()
		Me.lblRighe = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.cmdLog = New System.Windows.Forms.Button()
		Me.cmdSchedulazione = New System.Windows.Forms.Button()
		Me.cmdEsegue = New System.Windows.Forms.Button()
		Me.chkinviaMail = New System.Windows.Forms.CheckBox()
		Me.pnlOrigine.SuspendLayout()
		Me.pnlDestinazione.SuspendLayout()
		Me.pnlOperazioni.SuspendLayout()
		Me.pnlAttivazione.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.pnlRigheSI.SuspendLayout()
		Me.SuspendLayout()
		'
		'lstOperazioni
		'
		Me.lstOperazioni.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstOperazioni.FormattingEnabled = True
		Me.lstOperazioni.HorizontalScrollbar = True
		Me.lstOperazioni.ItemHeight = 15
		Me.lstOperazioni.Location = New System.Drawing.Point(2, 33)
		Me.lstOperazioni.Name = "lstOperazioni"
		Me.lstOperazioni.Size = New System.Drawing.Size(1040, 184)
		Me.lstOperazioni.TabIndex = 0
		'
		'cmbOperazioni
		'
		Me.cmbOperazioni.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbOperazioni.FormattingEnabled = True
		Me.cmbOperazioni.Location = New System.Drawing.Point(160, 221)
		Me.cmbOperazioni.Name = "cmbOperazioni"
		Me.cmbOperazioni.Size = New System.Drawing.Size(208, 24)
		Me.cmbOperazioni.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(2, 221)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(152, 21)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Tipo operazione"
		'
		'lblTitOrig
		'
		Me.lblTitOrig.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitOrig.Location = New System.Drawing.Point(2, 253)
		Me.lblTitOrig.Name = "lblTitOrig"
		Me.lblTitOrig.Size = New System.Drawing.Size(152, 21)
		Me.lblTitOrig.TabIndex = 3
		Me.lblTitOrig.Text = "Origine"
		'
		'lblTitDest
		'
		Me.lblTitDest.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitDest.Location = New System.Drawing.Point(2, 320)
		Me.lblTitDest.Name = "lblTitDest"
		Me.lblTitDest.Size = New System.Drawing.Size(152, 21)
		Me.lblTitDest.TabIndex = 4
		Me.lblTitDest.Text = "Destinazione"
		'
		'cmdSceltaOrig
		'
		Me.cmdSceltaOrig.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdSceltaOrig.Location = New System.Drawing.Point(657, 252)
		Me.cmdSceltaOrig.Name = "cmdSceltaOrig"
		Me.cmdSceltaOrig.Size = New System.Drawing.Size(33, 25)
		Me.cmdSceltaOrig.TabIndex = 7
		Me.cmdSceltaOrig.Text = "..."
		Me.cmdSceltaOrig.UseVisualStyleBackColor = True
		'
		'cmdSceltaDest
		'
		Me.cmdSceltaDest.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdSceltaDest.Location = New System.Drawing.Point(657, 318)
		Me.cmdSceltaDest.Name = "cmdSceltaDest"
		Me.cmdSceltaDest.Size = New System.Drawing.Size(34, 25)
		Me.cmdSceltaDest.TabIndex = 8
		Me.cmdSceltaDest.Text = "..."
		Me.cmdSceltaDest.UseVisualStyleBackColor = True
		'
		'lblTitFiltro
		'
		Me.lblTitFiltro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitFiltro.Location = New System.Drawing.Point(2, 391)
		Me.lblTitFiltro.Name = "lblTitFiltro"
		Me.lblTitFiltro.Size = New System.Drawing.Size(152, 21)
		Me.lblTitFiltro.TabIndex = 9
		Me.lblTitFiltro.Text = "Parametro"
		'
		'txtFiltro
		'
		Me.txtFiltro.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFiltro.Location = New System.Drawing.Point(161, 391)
		Me.txtFiltro.MaxLength = 255
		Me.txtFiltro.Name = "txtFiltro"
		Me.txtFiltro.Size = New System.Drawing.Size(310, 23)
		Me.txtFiltro.TabIndex = 10
		'
		'chkSovrascrivi
		'
		Me.chkSovrascrivi.AutoSize = True
		Me.chkSovrascrivi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSovrascrivi.Location = New System.Drawing.Point(487, 394)
		Me.chkSovrascrivi.Name = "chkSovrascrivi"
		Me.chkSovrascrivi.Size = New System.Drawing.Size(85, 19)
		Me.chkSovrascrivi.TabIndex = 11
		Me.chkSovrascrivi.Text = "Sovrascrivi"
		Me.chkSovrascrivi.UseVisualStyleBackColor = True
		'
		'chkSottodirectory
		'
		Me.chkSottodirectory.AutoSize = True
		Me.chkSottodirectory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSottodirectory.Location = New System.Drawing.Point(587, 395)
		Me.chkSottodirectory.Name = "chkSottodirectory"
		Me.chkSottodirectory.Size = New System.Drawing.Size(103, 19)
		Me.chkSottodirectory.TabIndex = 12
		Me.chkSottodirectory.Text = "Sotto directory"
		Me.chkSottodirectory.UseVisualStyleBackColor = True
		'
		'lblNomeProc
		'
		Me.lblNomeProc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNomeProc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblNomeProc.Location = New System.Drawing.Point(2, 4)
		Me.lblNomeProc.Name = "lblNomeProc"
		Me.lblNomeProc.Size = New System.Drawing.Size(315, 21)
		Me.lblNomeProc.TabIndex = 13
		Me.lblNomeProc.Text = "Tipo operazione"
		Me.lblNomeProc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'cmdElimina
		'
		Me.cmdElimina.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdElimina.Image = CType(resources.GetObject("cmdElimina.Image"), System.Drawing.Image)
		Me.cmdElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdElimina.Location = New System.Drawing.Point(3, 27)
		Me.cmdElimina.Name = "cmdElimina"
		Me.cmdElimina.Size = New System.Drawing.Size(163, 25)
		Me.cmdElimina.TabIndex = 14
		Me.cmdElimina.Text = "Elimina"
		Me.cmdElimina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdElimina.UseVisualStyleBackColor = True
		Me.cmdElimina.Visible = False
		'
		'cmdSalva
		'
		Me.cmdSalva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSalva.Image = CType(resources.GetObject("cmdSalva.Image"), System.Drawing.Image)
		Me.cmdSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdSalva.Location = New System.Drawing.Point(4, 150)
		Me.cmdSalva.Name = "cmdSalva"
		Me.cmdSalva.Size = New System.Drawing.Size(163, 35)
		Me.cmdSalva.TabIndex = 15
		Me.cmdSalva.Text = "Salva"
		Me.cmdSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdSalva.UseVisualStyleBackColor = True
		'
		'lblProgressivo
		'
		Me.lblProgressivo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblProgressivo.Location = New System.Drawing.Point(904, 223)
		Me.lblProgressivo.Name = "lblProgressivo"
		Me.lblProgressivo.Size = New System.Drawing.Size(139, 21)
		Me.lblProgressivo.TabIndex = 16
		Me.lblProgressivo.Text = "Tipo operazione"
		Me.lblProgressivo.Visible = False
		'
		'cmdPulisce
		'
		Me.cmdPulisce.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPulisce.Image = CType(resources.GetObject("cmdPulisce.Image"), System.Drawing.Image)
		Me.cmdPulisce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdPulisce.Location = New System.Drawing.Point(4, 72)
		Me.cmdPulisce.Name = "cmdPulisce"
		Me.cmdPulisce.Size = New System.Drawing.Size(162, 25)
		Me.cmdPulisce.TabIndex = 18
		Me.cmdPulisce.Text = "Pulisce"
		Me.cmdPulisce.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdPulisce.UseVisualStyleBackColor = True
		Me.cmdPulisce.Visible = False
		'
		'txtNomeProcedura
		'
		Me.txtNomeProcedura.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNomeProcedura.Location = New System.Drawing.Point(639, 4)
		Me.txtNomeProcedura.MaxLength = 20
		Me.txtNomeProcedura.Name = "txtNomeProcedura"
		Me.txtNomeProcedura.Size = New System.Drawing.Size(228, 23)
		Me.txtNomeProcedura.TabIndex = 19
		'
		'lblTitNomeProc
		'
		Me.lblTitNomeProc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitNomeProc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblTitNomeProc.Location = New System.Drawing.Point(2, 4)
		Me.lblTitNomeProc.Name = "lblTitNomeProc"
		Me.lblTitNomeProc.Size = New System.Drawing.Size(524, 26)
		Me.lblTitNomeProc.TabIndex = 20
		Me.lblTitNomeProc.Text = "Nome Procedura"
		Me.lblTitNomeProc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'cmdCancella
		'
		Me.cmdCancella.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancella.Location = New System.Drawing.Point(907, 2)
		Me.cmdCancella.Name = "cmdCancella"
		Me.cmdCancella.Size = New System.Drawing.Size(135, 25)
		Me.cmdCancella.TabIndex = 22
		Me.cmdCancella.Text = "Elimina procedura"
		Me.cmdCancella.UseVisualStyleBackColor = True
		'
		'cmdRinomina
		'
		Me.cmdRinomina.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdRinomina.Location = New System.Drawing.Point(873, 2)
		Me.cmdRinomina.Name = "cmdRinomina"
		Me.cmdRinomina.Size = New System.Drawing.Size(33, 25)
		Me.cmdRinomina.TabIndex = 23
		Me.cmdRinomina.Text = "..."
		Me.cmdRinomina.UseVisualStyleBackColor = True
		'
		'cmdSu
		'
		Me.cmdSu.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdSu.Location = New System.Drawing.Point(1009, 32)
		Me.cmdSu.Name = "cmdSu"
		Me.cmdSu.Size = New System.Drawing.Size(33, 21)
		Me.cmdSu.TabIndex = 24
		Me.cmdSu.Text = "/\"
		Me.cmdSu.UseVisualStyleBackColor = True
		Me.cmdSu.Visible = False
		'
		'cmdGiu
		'
		Me.cmdGiu.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdGiu.Location = New System.Drawing.Point(1009, 195)
		Me.cmdGiu.Name = "cmdGiu"
		Me.cmdGiu.Size = New System.Drawing.Size(33, 21)
		Me.cmdGiu.TabIndex = 25
		Me.cmdGiu.Text = "\/"
		Me.cmdGiu.UseVisualStyleBackColor = True
		Me.cmdGiu.Visible = False
		'
		'lblDestinazione
		'
		Me.lblDestinazione.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDestinazione.Location = New System.Drawing.Point(161, 318)
		Me.lblDestinazione.MaxLength = 255
		Me.lblDestinazione.Name = "lblDestinazione"
		Me.lblDestinazione.Size = New System.Drawing.Size(490, 23)
		Me.lblDestinazione.TabIndex = 26
		'
		'lblOrigine
		'
		Me.lblOrigine.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblOrigine.Location = New System.Drawing.Point(161, 253)
		Me.lblOrigine.MaxLength = 255
		Me.lblOrigine.Name = "lblOrigine"
		Me.lblOrigine.Size = New System.Drawing.Size(490, 23)
		Me.lblOrigine.TabIndex = 27
		'
		'pnlOrigine
		'
		Me.pnlOrigine.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.pnlOrigine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlOrigine.Controls.Add(Me.cmdTestO)
		Me.pnlOrigine.Controls.Add(Me.txtPasswordOrigine)
		Me.pnlOrigine.Controls.Add(Me.Label3)
		Me.pnlOrigine.Controls.Add(Me.txtUtenzaOrigine)
		Me.pnlOrigine.Controls.Add(Me.Label2)
		Me.pnlOrigine.Location = New System.Drawing.Point(161, 282)
		Me.pnlOrigine.Name = "pnlOrigine"
		Me.pnlOrigine.Size = New System.Drawing.Size(529, 29)
		Me.pnlOrigine.TabIndex = 28
		'
		'cmdTestO
		'
		Me.cmdTestO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdTestO.Location = New System.Drawing.Point(238, 3)
		Me.cmdTestO.Name = "cmdTestO"
		Me.cmdTestO.Size = New System.Drawing.Size(47, 21)
		Me.cmdTestO.TabIndex = 14
		Me.cmdTestO.Text = "Check"
		Me.cmdTestO.UseVisualStyleBackColor = True
		Me.cmdTestO.Visible = False
		'
		'txtPasswordOrigine
		'
		Me.txtPasswordOrigine.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPasswordOrigine.Location = New System.Drawing.Point(362, 2)
		Me.txtPasswordOrigine.MaxLength = 100
		Me.txtPasswordOrigine.Name = "txtPasswordOrigine"
		Me.txtPasswordOrigine.Size = New System.Drawing.Size(162, 23)
		Me.txtPasswordOrigine.TabIndex = 13
		Me.txtPasswordOrigine.UseSystemPasswordChar = True
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(252, 3)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(81, 21)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "Password"
		'
		'txtUtenzaOrigine
		'
		Me.txtUtenzaOrigine.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtUtenzaOrigine.Location = New System.Drawing.Point(68, 3)
		Me.txtUtenzaOrigine.MaxLength = 100
		Me.txtUtenzaOrigine.Name = "txtUtenzaOrigine"
		Me.txtUtenzaOrigine.Size = New System.Drawing.Size(161, 23)
		Me.txtUtenzaOrigine.TabIndex = 11
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(7, 4)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(103, 21)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Utenza"
		'
		'pnlDestinazione
		'
		Me.pnlDestinazione.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.pnlDestinazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlDestinazione.Controls.Add(Me.cmdTestD)
		Me.pnlDestinazione.Controls.Add(Me.txtPasswordDestinazione)
		Me.pnlDestinazione.Controls.Add(Me.Label4)
		Me.pnlDestinazione.Controls.Add(Me.txtUtenzaDestinazione)
		Me.pnlDestinazione.Controls.Add(Me.Label5)
		Me.pnlDestinazione.Location = New System.Drawing.Point(161, 349)
		Me.pnlDestinazione.Name = "pnlDestinazione"
		Me.pnlDestinazione.Size = New System.Drawing.Size(530, 29)
		Me.pnlDestinazione.TabIndex = 29
		'
		'cmdTestD
		'
		Me.cmdTestD.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdTestD.Location = New System.Drawing.Point(238, 3)
		Me.cmdTestD.Name = "cmdTestD"
		Me.cmdTestD.Size = New System.Drawing.Size(47, 21)
		Me.cmdTestD.TabIndex = 15
		Me.cmdTestD.Text = "Check"
		Me.cmdTestD.UseVisualStyleBackColor = True
		Me.cmdTestD.Visible = False
		'
		'txtPasswordDestinazione
		'
		Me.txtPasswordDestinazione.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPasswordDestinazione.Location = New System.Drawing.Point(362, 3)
		Me.txtPasswordDestinazione.MaxLength = 100
		Me.txtPasswordDestinazione.Name = "txtPasswordDestinazione"
		Me.txtPasswordDestinazione.Size = New System.Drawing.Size(162, 23)
		Me.txtPasswordDestinazione.TabIndex = 13
		Me.txtPasswordDestinazione.UseSystemPasswordChar = True
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(252, 4)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(81, 21)
		Me.Label4.TabIndex = 12
		Me.Label4.Text = "Password"
		'
		'txtUtenzaDestinazione
		'
		Me.txtUtenzaDestinazione.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtUtenzaDestinazione.Location = New System.Drawing.Point(69, 1)
		Me.txtUtenzaDestinazione.MaxLength = 100
		Me.txtUtenzaDestinazione.Name = "txtUtenzaDestinazione"
		Me.txtUtenzaDestinazione.Size = New System.Drawing.Size(160, 23)
		Me.txtUtenzaDestinazione.TabIndex = 11
		'
		'Label5
		'
		Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(3, 4)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(107, 21)
		Me.Label5.TabIndex = 4
		Me.Label5.Text = "Utenza"
		'
		'cmdSopraSotto
		'
		Me.cmdSopraSotto.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
		Me.cmdSopraSotto.Location = New System.Drawing.Point(5, 283)
		Me.cmdSopraSotto.Name = "cmdSopraSotto"
		Me.cmdSopraSotto.Size = New System.Drawing.Size(93, 25)
		Me.cmdSopraSotto.TabIndex = 30
		Me.cmdSopraSotto.Text = "\/               /\"
		Me.cmdSopraSotto.UseVisualStyleBackColor = True
		'
		'chkAttivo
		'
		Me.chkAttivo.AutoSize = True
		Me.chkAttivo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkAttivo.Location = New System.Drawing.Point(17, 5)
		Me.chkAttivo.Name = "chkAttivo"
		Me.chkAttivo.Size = New System.Drawing.Size(54, 19)
		Me.chkAttivo.TabIndex = 32
		Me.chkAttivo.Text = "Attiva"
		Me.chkAttivo.UseVisualStyleBackColor = True
		'
		'cmdCopia
		'
		Me.cmdCopia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCopia.Image = CType(resources.GetObject("cmdCopia.Image"), System.Drawing.Image)
		Me.cmdCopia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdCopia.Location = New System.Drawing.Point(4, 50)
		Me.cmdCopia.Name = "cmdCopia"
		Me.cmdCopia.Size = New System.Drawing.Size(162, 25)
		Me.cmdCopia.TabIndex = 33
		Me.cmdCopia.Text = "Copia"
		Me.cmdCopia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdCopia.UseVisualStyleBackColor = True
		Me.cmdCopia.Visible = False
		'
		'cmdAttivaTutti
		'
		Me.cmdAttivaTutti.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAttivaTutti.Location = New System.Drawing.Point(99, 1)
		Me.cmdAttivaTutti.Name = "cmdAttivaTutti"
		Me.cmdAttivaTutti.Size = New System.Drawing.Size(99, 25)
		Me.cmdAttivaTutti.TabIndex = 34
		Me.cmdAttivaTutti.Text = "Attiva tutti"
		Me.cmdAttivaTutti.UseVisualStyleBackColor = True
		Me.cmdAttivaTutti.Visible = False
		'
		'cmdDisattivaTutti
		'
		Me.cmdDisattivaTutti.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDisattivaTutti.Location = New System.Drawing.Point(211, 1)
		Me.cmdDisattivaTutti.Name = "cmdDisattivaTutti"
		Me.cmdDisattivaTutti.Size = New System.Drawing.Size(101, 25)
		Me.cmdDisattivaTutti.TabIndex = 35
		Me.cmdDisattivaTutti.Text = "Disattiva tutti"
		Me.cmdDisattivaTutti.UseVisualStyleBackColor = True
		Me.cmdDisattivaTutti.Visible = False
		'
		'pnlOperazioni
		'
		Me.pnlOperazioni.BackColor = System.Drawing.Color.Silver
		Me.pnlOperazioni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlOperazioni.Controls.Add(Me.cmdEliminaTutti)
		Me.pnlOperazioni.Controls.Add(Me.cmdEliminaDatiSincInt)
		Me.pnlOperazioni.Controls.Add(Me.lblTitOperazione)
		Me.pnlOperazioni.Controls.Add(Me.cmdElimina)
		Me.pnlOperazioni.Controls.Add(Me.cmdCopia)
		Me.pnlOperazioni.Controls.Add(Me.cmdPulisce)
		Me.pnlOperazioni.Controls.Add(Me.cmdSalva)
		Me.pnlOperazioni.Location = New System.Drawing.Point(697, 221)
		Me.pnlOperazioni.Name = "pnlOperazioni"
		Me.pnlOperazioni.Size = New System.Drawing.Size(170, 190)
		Me.pnlOperazioni.TabIndex = 36
		'
		'cmdEliminaTutti
		'
		Me.cmdEliminaTutti.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaTutti.Image = CType(resources.GetObject("cmdEliminaTutti.Image"), System.Drawing.Image)
		Me.cmdEliminaTutti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdEliminaTutti.Location = New System.Drawing.Point(3, 118)
		Me.cmdEliminaTutti.Name = "cmdEliminaTutti"
		Me.cmdEliminaTutti.Size = New System.Drawing.Size(163, 25)
		Me.cmdEliminaTutti.TabIndex = 36
		Me.cmdEliminaTutti.Text = "Elimina tutti i dati"
		Me.cmdEliminaTutti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdEliminaTutti.UseVisualStyleBackColor = True
		Me.cmdEliminaTutti.Visible = False
		'
		'cmdEliminaDatiSincInt
		'
		Me.cmdEliminaDatiSincInt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEliminaDatiSincInt.Image = CType(resources.GetObject("cmdEliminaDatiSincInt.Image"), System.Drawing.Image)
		Me.cmdEliminaDatiSincInt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdEliminaDatiSincInt.Location = New System.Drawing.Point(3, 95)
		Me.cmdEliminaDatiSincInt.Name = "cmdEliminaDatiSincInt"
		Me.cmdEliminaDatiSincInt.Size = New System.Drawing.Size(163, 25)
		Me.cmdEliminaDatiSincInt.TabIndex = 35
		Me.cmdEliminaDatiSincInt.Text = "Elimina dati"
		Me.cmdEliminaDatiSincInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdEliminaDatiSincInt.UseVisualStyleBackColor = True
		Me.cmdEliminaDatiSincInt.Visible = False
		'
		'lblTitOperazione
		'
		Me.lblTitOperazione.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblTitOperazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitOperazione.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitOperazione.ForeColor = System.Drawing.Color.Green
		Me.lblTitOperazione.Location = New System.Drawing.Point(3, 3)
		Me.lblTitOperazione.Name = "lblTitOperazione"
		Me.lblTitOperazione.Size = New System.Drawing.Size(164, 21)
		Me.lblTitOperazione.TabIndex = 34
		Me.lblTitOperazione.Text = "Operazione"
		Me.lblTitOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'pnlAttivazione
		'
		Me.pnlAttivazione.BackColor = System.Drawing.Color.Silver
		Me.pnlAttivazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlAttivazione.Controls.Add(Me.chkAttivo)
		Me.pnlAttivazione.Controls.Add(Me.cmdAttivaTutti)
		Me.pnlAttivazione.Controls.Add(Me.cmdDisattivaTutti)
		Me.pnlAttivazione.Location = New System.Drawing.Point(374, 221)
		Me.pnlAttivazione.Name = "pnlAttivazione"
		Me.pnlAttivazione.Size = New System.Drawing.Size(317, 29)
		Me.pnlAttivazione.TabIndex = 37
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.Silver
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.pnlRigheSI)
		Me.Panel1.Controls.Add(Me.cmdLog)
		Me.Panel1.Controls.Add(Me.cmdSchedulazione)
		Me.Panel1.Controls.Add(Me.cmdEsegue)
		Me.Panel1.Location = New System.Drawing.Point(875, 221)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(167, 190)
		Me.Panel1.TabIndex = 38
		'
		'pnlRigheSI
		'
		Me.pnlRigheSI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.pnlRigheSI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlRigheSI.Controls.Add(Me.lblRighe)
		Me.pnlRigheSI.Controls.Add(Me.Label6)
		Me.pnlRigheSI.Location = New System.Drawing.Point(3, 49)
		Me.pnlRigheSI.Name = "pnlRigheSI"
		Me.pnlRigheSI.Size = New System.Drawing.Size(159, 52)
		Me.pnlRigheSI.TabIndex = 41
		'
		'lblRighe
		'
		Me.lblRighe.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRighe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblRighe.Location = New System.Drawing.Point(3, 25)
		Me.lblRighe.Name = "lblRighe"
		Me.lblRighe.Size = New System.Drawing.Size(150, 21)
		Me.lblRighe.TabIndex = 6
		Me.lblRighe.Text = "Utenza"
		Me.lblRighe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(3, 5)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(150, 21)
		Me.Label6.TabIndex = 5
		Me.Label6.Text = "Righe S.I."
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmdLog
		'
		Me.cmdLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdLog.Image = CType(resources.GetObject("cmdLog.Image"), System.Drawing.Image)
		Me.cmdLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdLog.Location = New System.Drawing.Point(3, 107)
		Me.cmdLog.Name = "cmdLog"
		Me.cmdLog.Size = New System.Drawing.Size(161, 39)
		Me.cmdLog.TabIndex = 34
		Me.cmdLog.Text = "Ultimo Log"
		Me.cmdLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdLog.UseVisualStyleBackColor = True
		'
		'cmdSchedulazione
		'
		Me.cmdSchedulazione.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSchedulazione.Image = CType(resources.GetObject("cmdSchedulazione.Image"), System.Drawing.Image)
		Me.cmdSchedulazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdSchedulazione.Location = New System.Drawing.Point(3, 3)
		Me.cmdSchedulazione.Name = "cmdSchedulazione"
		Me.cmdSchedulazione.Size = New System.Drawing.Size(161, 41)
		Me.cmdSchedulazione.TabIndex = 33
		Me.cmdSchedulazione.Text = "Schedulazione"
		Me.cmdSchedulazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdSchedulazione.UseVisualStyleBackColor = True
		'
		'cmdEsegue
		'
		Me.cmdEsegue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEsegue.Image = CType(resources.GetObject("cmdEsegue.Image"), System.Drawing.Image)
		Me.cmdEsegue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdEsegue.Location = New System.Drawing.Point(3, 150)
		Me.cmdEsegue.Name = "cmdEsegue"
		Me.cmdEsegue.Size = New System.Drawing.Size(161, 35)
		Me.cmdEsegue.TabIndex = 32
		Me.cmdEsegue.Text = "Esegue"
		Me.cmdEsegue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdEsegue.UseVisualStyleBackColor = True
		'
		'chkinviaMail
		'
		Me.chkinviaMail.AutoSize = True
		Me.chkinviaMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkinviaMail.Location = New System.Drawing.Point(540, 8)
		Me.chkinviaMail.Name = "chkinviaMail"
		Me.chkinviaMail.Size = New System.Drawing.Size(76, 19)
		Me.chkinviaMail.TabIndex = 40
		Me.chkinviaMail.Text = "Invia Mail"
		Me.chkinviaMail.UseVisualStyleBackColor = True
		'
		'frmProcedura
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1044, 423)
		Me.Controls.Add(Me.chkinviaMail)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.pnlAttivazione)
		Me.Controls.Add(Me.pnlOperazioni)
		Me.Controls.Add(Me.cmdSopraSotto)
		Me.Controls.Add(Me.pnlDestinazione)
		Me.Controls.Add(Me.pnlOrigine)
		Me.Controls.Add(Me.lblOrigine)
		Me.Controls.Add(Me.lblDestinazione)
		Me.Controls.Add(Me.cmdGiu)
		Me.Controls.Add(Me.cmdSu)
		Me.Controls.Add(Me.cmdRinomina)
		Me.Controls.Add(Me.cmdCancella)
		Me.Controls.Add(Me.lblTitNomeProc)
		Me.Controls.Add(Me.txtNomeProcedura)
		Me.Controls.Add(Me.lblProgressivo)
		Me.Controls.Add(Me.lblNomeProc)
		Me.Controls.Add(Me.chkSottodirectory)
		Me.Controls.Add(Me.chkSovrascrivi)
		Me.Controls.Add(Me.txtFiltro)
		Me.Controls.Add(Me.lblTitFiltro)
		Me.Controls.Add(Me.cmdSceltaDest)
		Me.Controls.Add(Me.cmdSceltaOrig)
		Me.Controls.Add(Me.lblTitDest)
		Me.Controls.Add(Me.lblTitOrig)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.cmbOperazioni)
		Me.Controls.Add(Me.lstOperazioni)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmProcedura"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Procedura"
		Me.pnlOrigine.ResumeLayout(False)
		Me.pnlOrigine.PerformLayout()
		Me.pnlDestinazione.ResumeLayout(False)
		Me.pnlDestinazione.PerformLayout()
		Me.pnlOperazioni.ResumeLayout(False)
		Me.pnlAttivazione.ResumeLayout(False)
		Me.pnlAttivazione.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.pnlRigheSI.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lstOperazioni As System.Windows.Forms.ListBox
    Friend WithEvents cmbOperazioni As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTitOrig As System.Windows.Forms.Label
    Friend WithEvents lblTitDest As System.Windows.Forms.Label
    Friend WithEvents cmdSceltaOrig As System.Windows.Forms.Button
    Friend WithEvents cmdSceltaDest As System.Windows.Forms.Button
    Friend WithEvents lblTitFiltro As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents chkSovrascrivi As System.Windows.Forms.CheckBox
    Friend WithEvents chkSottodirectory As System.Windows.Forms.CheckBox
    Friend WithEvents lblNomeProc As System.Windows.Forms.Label
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents lblProgressivo As System.Windows.Forms.Label
    Friend WithEvents cmdPulisce As System.Windows.Forms.Button
    Friend WithEvents txtNomeProcedura As System.Windows.Forms.TextBox
    Friend WithEvents lblTitNomeProc As System.Windows.Forms.Label
    Friend WithEvents cmdCancella As System.Windows.Forms.Button
    Friend WithEvents cmdRinomina As System.Windows.Forms.Button
    Friend WithEvents cmdSu As System.Windows.Forms.Button
    Friend WithEvents cmdGiu As System.Windows.Forms.Button
    Friend WithEvents lblDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblOrigine As System.Windows.Forms.TextBox
    Friend WithEvents pnlOrigine As System.Windows.Forms.Panel
    Friend WithEvents txtPasswordOrigine As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUtenzaOrigine As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlDestinazione As System.Windows.Forms.Panel
    Friend WithEvents txtPasswordDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUtenzaDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdSopraSotto As System.Windows.Forms.Button
    Friend WithEvents cmdTestO As System.Windows.Forms.Button
    Friend WithEvents cmdTestD As System.Windows.Forms.Button
    Friend WithEvents chkAttivo As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCopia As System.Windows.Forms.Button
    Friend WithEvents cmdAttivaTutti As System.Windows.Forms.Button
    Friend WithEvents cmdDisattivaTutti As System.Windows.Forms.Button
    Friend WithEvents pnlOperazioni As System.Windows.Forms.Panel
    Friend WithEvents pnlAttivazione As System.Windows.Forms.Panel
    Friend WithEvents lblTitOperazione As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdLog As System.Windows.Forms.Button
    Friend WithEvents cmdSchedulazione As System.Windows.Forms.Button
    Friend WithEvents cmdEsegue As System.Windows.Forms.Button
    Friend WithEvents cmdEliminaDatiSincInt As System.Windows.Forms.Button
    Friend WithEvents chkinviaMail As System.Windows.Forms.CheckBox
    Friend WithEvents pnlRigheSI As System.Windows.Forms.Panel
    Friend WithEvents lblRighe As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdEliminaTutti As System.Windows.Forms.Button
End Class
