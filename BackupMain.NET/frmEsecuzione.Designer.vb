<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEsecuzione
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEsecuzione))
        Me.lblNomeProc = New System.Windows.Forms.Label()
        Me.lstOperazioni = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblOperazione = New System.Windows.Forms.Label()
        Me.lblContatore = New System.Windows.Forms.Label()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdRipristina = New System.Windows.Forms.Button()
        Me.cmdSkip = New System.Windows.Forms.Button()
        Me.tmrCheckFineThread = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblNomeProc
        '
        Me.lblNomeProc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNomeProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNomeProc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeProc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNomeProc.Location = New System.Drawing.Point(5, 14)
        Me.lblNomeProc.Name = "lblNomeProc"
        Me.lblNomeProc.Size = New System.Drawing.Size(668, 21)
        Me.lblNomeProc.TabIndex = 15
        Me.lblNomeProc.Text = "Tipo operazione"
        Me.lblNomeProc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstOperazioni
        '
        Me.lstOperazioni.Enabled = False
        Me.lstOperazioni.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOperazioni.FormattingEnabled = True
        Me.lstOperazioni.ItemHeight = 15
        Me.lstOperazioni.Location = New System.Drawing.Point(6, 58)
        Me.lstOperazioni.Name = "lstOperazioni"
        Me.lstOperazioni.Size = New System.Drawing.Size(833, 244)
        Me.lstOperazioni.TabIndex = 14
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lblOperazione
        '
        Me.lblOperazione.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOperazione.Location = New System.Drawing.Point(3, 305)
        Me.lblOperazione.Name = "lblOperazione"
        Me.lblOperazione.Size = New System.Drawing.Size(492, 59)
        Me.lblOperazione.TabIndex = 16
        Me.lblOperazione.Text = "Tipo operazione"
        Me.lblOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContatore
        '
        Me.lblContatore.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblContatore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblContatore.Location = New System.Drawing.Point(489, 305)
        Me.lblContatore.Name = "lblContatore"
        Me.lblContatore.Size = New System.Drawing.Size(349, 59)
        Me.lblContatore.TabIndex = 17
        Me.lblContatore.Text = "Tipo operazione"
        Me.lblContatore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdPausa
        '
        Me.cmdPausa.Image = CType(resources.GetObject("cmdPausa.Image"), System.Drawing.Image)
        Me.cmdPausa.Location = New System.Drawing.Point(789, 1)
        Me.cmdPausa.Name = "cmdPausa"
        Me.cmdPausa.Size = New System.Drawing.Size(49, 49)
        Me.cmdPausa.TabIndex = 18
        Me.cmdPausa.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Image = CType(resources.GetObject("cmdStop.Image"), System.Drawing.Image)
        Me.cmdStop.Location = New System.Drawing.Point(734, 1)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(49, 49)
        Me.cmdStop.TabIndex = 19
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdRipristina
        '
        Me.cmdRipristina.Image = CType(resources.GetObject("cmdRipristina.Image"), System.Drawing.Image)
        Me.cmdRipristina.Location = New System.Drawing.Point(789, 1)
        Me.cmdRipristina.Name = "cmdRipristina"
        Me.cmdRipristina.Size = New System.Drawing.Size(49, 49)
        Me.cmdRipristina.TabIndex = 20
        Me.cmdRipristina.UseVisualStyleBackColor = True
        Me.cmdRipristina.Visible = False
        '
        'cmdSkip
        '
        Me.cmdSkip.Image = CType(resources.GetObject("cmdSkip.Image"), System.Drawing.Image)
        Me.cmdSkip.Location = New System.Drawing.Point(679, 1)
        Me.cmdSkip.Name = "cmdSkip"
        Me.cmdSkip.Size = New System.Drawing.Size(49, 49)
        Me.cmdSkip.TabIndex = 21
        Me.cmdSkip.UseVisualStyleBackColor = True
        '
        'tmrCheckFineThread
        '
        Me.tmrCheckFineThread.Interval = 1000
        '
        'frmEsecuzione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 369)
        Me.Controls.Add(Me.cmdSkip)
        Me.Controls.Add(Me.cmdRipristina)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdPausa)
        Me.Controls.Add(Me.lblContatore)
        Me.Controls.Add(Me.lblOperazione)
        Me.Controls.Add(Me.lblNomeProc)
        Me.Controls.Add(Me.lstOperazioni)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEsecuzione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Esecuzione"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNomeProc As System.Windows.Forms.Label
    Friend WithEvents lstOperazioni As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblOperazione As System.Windows.Forms.Label
    Friend WithEvents lblContatore As System.Windows.Forms.Label
    Friend WithEvents cmdPausa As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdRipristina As System.Windows.Forms.Button
    Friend WithEvents cmdSkip As System.Windows.Forms.Button
    Friend WithEvents tmrCheckFineThread As System.Windows.Forms.Timer
End Class
