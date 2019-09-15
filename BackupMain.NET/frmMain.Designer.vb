<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
	'Non modificarla mediante l'editor del codice.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.cmdRoutine = New System.Windows.Forms.Button()
		Me.lblTitolo = New System.Windows.Forms.Label()
		Me.lblPathDB = New System.Windows.Forms.Label()
		Me.lstProcedure = New System.Windows.Forms.ListBox()
		Me.cmdSetup = New System.Windows.Forms.Button()
		Me.cmdUscita = New System.Windows.Forms.Button()
		Me.cmdElimina = New System.Windows.Forms.Button()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'cmdRoutine
		'
		Me.cmdRoutine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRoutine.Image = CType(resources.GetObject("cmdRoutine.Image"), System.Drawing.Image)
		Me.cmdRoutine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdRoutine.Location = New System.Drawing.Point(3, 316)
		Me.cmdRoutine.Name = "cmdRoutine"
		Me.cmdRoutine.Size = New System.Drawing.Size(93, 39)
		Me.cmdRoutine.TabIndex = 0
		Me.cmdRoutine.Text = "Nuova"
		Me.cmdRoutine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdRoutine.UseVisualStyleBackColor = True
		'
		'lblTitolo
		'
		Me.lblTitolo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblTitolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitolo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitolo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.lblTitolo.Location = New System.Drawing.Point(3, 9)
		Me.lblTitolo.Name = "lblTitolo"
		Me.lblTitolo.Size = New System.Drawing.Size(449, 23)
		Me.lblTitolo.TabIndex = 2
		Me.lblTitolo.Text = "Lista procedure"
		Me.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblPathDB
		'
		Me.lblPathDB.AutoSize = True
		Me.lblPathDB.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPathDB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblPathDB.Location = New System.Drawing.Point(111, 336)
		Me.lblPathDB.Name = "lblPathDB"
		Me.lblPathDB.Size = New System.Drawing.Size(34, 15)
		Me.lblPathDB.TabIndex = 3
		Me.lblPathDB.Text = "Label2"
		Me.lblPathDB.Visible = False
		'
		'lstProcedure
		'
		Me.lstProcedure.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstProcedure.FormattingEnabled = True
		Me.lstProcedure.ItemHeight = 18
		Me.lstProcedure.Location = New System.Drawing.Point(3, 36)
		Me.lstProcedure.Name = "lstProcedure"
		Me.lstProcedure.Size = New System.Drawing.Size(449, 274)
		Me.lstProcedure.TabIndex = 4
		'
		'cmdSetup
		'
		Me.cmdSetup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSetup.Image = CType(resources.GetObject("cmdSetup.Image"), System.Drawing.Image)
		Me.cmdSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdSetup.Location = New System.Drawing.Point(247, 316)
		Me.cmdSetup.Name = "cmdSetup"
		Me.cmdSetup.Size = New System.Drawing.Size(106, 39)
		Me.cmdSetup.TabIndex = 5
		Me.cmdSetup.Text = "Impostazioni"
		Me.cmdSetup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdSetup.UseVisualStyleBackColor = True
		'
		'cmdUscita
		'
		Me.cmdUscita.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUscita.Image = CType(resources.GetObject("cmdUscita.Image"), System.Drawing.Image)
		Me.cmdUscita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdUscita.Location = New System.Drawing.Point(359, 316)
		Me.cmdUscita.Name = "cmdUscita"
		Me.cmdUscita.Size = New System.Drawing.Size(93, 39)
		Me.cmdUscita.TabIndex = 6
		Me.cmdUscita.Text = "Uscita"
		Me.cmdUscita.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdUscita.UseVisualStyleBackColor = True
		'
		'cmdElimina
		'
		Me.cmdElimina.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdElimina.Image = CType(resources.GetObject("cmdElimina.Image"), System.Drawing.Image)
		Me.cmdElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cmdElimina.Location = New System.Drawing.Point(102, 316)
		Me.cmdElimina.Name = "cmdElimina"
		Me.cmdElimina.Size = New System.Drawing.Size(93, 39)
		Me.cmdElimina.TabIndex = 7
		Me.cmdElimina.Text = "Elimina"
		Me.cmdElimina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cmdElimina.UseVisualStyleBackColor = True
		Me.cmdElimina.Visible = False
		'
		'Timer1
		'
		Me.Timer1.Interval = 30000
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(454, 358)
		Me.Controls.Add(Me.cmdElimina)
		Me.Controls.Add(Me.cmdUscita)
		Me.Controls.Add(Me.cmdSetup)
		Me.Controls.Add(Me.lstProcedure)
		Me.Controls.Add(Me.lblPathDB)
		Me.Controls.Add(Me.lblTitolo)
		Me.Controls.Add(Me.cmdRoutine)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Backup"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents cmdRoutine As System.Windows.Forms.Button
	Friend WithEvents lblTitolo As System.Windows.Forms.Label
	Friend WithEvents lblPathDB As System.Windows.Forms.Label
	Friend WithEvents lstProcedure As System.Windows.Forms.ListBox
	Friend WithEvents cmdSetup As System.Windows.Forms.Button
	Friend WithEvents cmdUscita As System.Windows.Forms.Button
	Friend WithEvents cmdElimina As Button
	Friend WithEvents Timer1 As Timer
End Class
