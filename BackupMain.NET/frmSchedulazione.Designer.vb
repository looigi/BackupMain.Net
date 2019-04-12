<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchedulazione
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchedulazione))
        Me.lblNomeProc = New System.Windows.Forms.Label()
        Me.pnlGiorni = New System.Windows.Forms.Panel()
        Me.chkDomenica = New System.Windows.Forms.CheckBox()
        Me.chkSabato = New System.Windows.Forms.CheckBox()
        Me.chkVenerdi = New System.Windows.Forms.CheckBox()
        Me.chkGiovedi = New System.Windows.Forms.CheckBox()
        Me.chkMercoledi = New System.Windows.Forms.CheckBox()
        Me.chkMartedi = New System.Windows.Forms.CheckBox()
        Me.chkLunedi = New System.Windows.Forms.CheckBox()
        Me.optGiorno = New System.Windows.Forms.RadioButton()
        Me.optGiornoMese = New System.Windows.Forms.RadioButton()
        Me.pnlMese = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGiorni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSalva = New System.Windows.Forms.Button()
        Me.optNulla = New System.Windows.Forms.RadioButton()
        Me.pnlGiorni.SuspendLayout()
        Me.pnlMese.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNomeProc
        '
        Me.lblNomeProc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeProc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNomeProc.Location = New System.Drawing.Point(1, 9)
        Me.lblNomeProc.Name = "lblNomeProc"
        Me.lblNomeProc.Size = New System.Drawing.Size(261, 21)
        Me.lblNomeProc.TabIndex = 21
        Me.lblNomeProc.Text = "Nome Procedura"
        Me.lblNomeProc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlGiorni
        '
        Me.pnlGiorni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGiorni.Controls.Add(Me.chkDomenica)
        Me.pnlGiorni.Controls.Add(Me.chkSabato)
        Me.pnlGiorni.Controls.Add(Me.chkVenerdi)
        Me.pnlGiorni.Controls.Add(Me.chkGiovedi)
        Me.pnlGiorni.Controls.Add(Me.chkMercoledi)
        Me.pnlGiorni.Controls.Add(Me.chkMartedi)
        Me.pnlGiorni.Controls.Add(Me.chkLunedi)
        Me.pnlGiorni.Location = New System.Drawing.Point(4, 80)
        Me.pnlGiorni.Name = "pnlGiorni"
        Me.pnlGiorni.Size = New System.Drawing.Size(258, 75)
        Me.pnlGiorni.TabIndex = 29
        '
        'chkDomenica
        '
        Me.chkDomenica.AutoSize = True
        Me.chkDomenica.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDomenica.Location = New System.Drawing.Point(8, 53)
        Me.chkDomenica.Name = "chkDomenica"
        Me.chkDomenica.Size = New System.Drawing.Size(83, 19)
        Me.chkDomenica.TabIndex = 35
        Me.chkDomenica.Text = "Domenica"
        Me.chkDomenica.UseVisualStyleBackColor = True
        '
        'chkSabato
        '
        Me.chkSabato.AutoSize = True
        Me.chkSabato.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSabato.Location = New System.Drawing.Point(148, 28)
        Me.chkSabato.Name = "chkSabato"
        Me.chkSabato.Size = New System.Drawing.Size(65, 19)
        Me.chkSabato.TabIndex = 34
        Me.chkSabato.Text = "Sabato"
        Me.chkSabato.UseVisualStyleBackColor = True
        '
        'chkVenerdi
        '
        Me.chkVenerdi.AutoSize = True
        Me.chkVenerdi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVenerdi.Location = New System.Drawing.Point(78, 28)
        Me.chkVenerdi.Name = "chkVenerdi"
        Me.chkVenerdi.Size = New System.Drawing.Size(67, 19)
        Me.chkVenerdi.TabIndex = 33
        Me.chkVenerdi.Text = "Venerdì"
        Me.chkVenerdi.UseVisualStyleBackColor = True
        '
        'chkGiovedi
        '
        Me.chkGiovedi.AutoSize = True
        Me.chkGiovedi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGiovedi.Location = New System.Drawing.Point(8, 28)
        Me.chkGiovedi.Name = "chkGiovedi"
        Me.chkGiovedi.Size = New System.Drawing.Size(67, 19)
        Me.chkGiovedi.TabIndex = 32
        Me.chkGiovedi.Text = "Giovedì"
        Me.chkGiovedi.UseVisualStyleBackColor = True
        '
        'chkMercoledi
        '
        Me.chkMercoledi.AutoSize = True
        Me.chkMercoledi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMercoledi.Location = New System.Drawing.Point(148, 3)
        Me.chkMercoledi.Name = "chkMercoledi"
        Me.chkMercoledi.Size = New System.Drawing.Size(79, 19)
        Me.chkMercoledi.TabIndex = 31
        Me.chkMercoledi.Text = "Mercoledì"
        Me.chkMercoledi.UseVisualStyleBackColor = True
        '
        'chkMartedi
        '
        Me.chkMartedi.AutoSize = True
        Me.chkMartedi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMartedi.Location = New System.Drawing.Point(78, 3)
        Me.chkMartedi.Name = "chkMartedi"
        Me.chkMartedi.Size = New System.Drawing.Size(66, 19)
        Me.chkMartedi.TabIndex = 30
        Me.chkMartedi.Text = "Martedì"
        Me.chkMartedi.UseVisualStyleBackColor = True
        '
        'chkLunedi
        '
        Me.chkLunedi.AutoSize = True
        Me.chkLunedi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLunedi.Location = New System.Drawing.Point(8, 3)
        Me.chkLunedi.Name = "chkLunedi"
        Me.chkLunedi.Size = New System.Drawing.Size(64, 19)
        Me.chkLunedi.TabIndex = 29
        Me.chkLunedi.Text = "Lunedì"
        Me.chkLunedi.UseVisualStyleBackColor = True
        '
        'optGiorno
        '
        Me.optGiorno.AutoSize = True
        Me.optGiorno.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optGiorno.Location = New System.Drawing.Point(4, 57)
        Me.optGiorno.Name = "optGiorno"
        Me.optGiorno.Size = New System.Drawing.Size(144, 20)
        Me.optGiorno.TabIndex = 30
        Me.optGiorno.TabStop = True
        Me.optGiorno.Text = "Giorno della settimana"
        Me.optGiorno.UseVisualStyleBackColor = True
        '
        'optGiornoMese
        '
        Me.optGiornoMese.AutoSize = True
        Me.optGiornoMese.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optGiornoMese.Location = New System.Drawing.Point(4, 161)
        Me.optGiornoMese.Name = "optGiornoMese"
        Me.optGiornoMese.Size = New System.Drawing.Size(111, 20)
        Me.optGiornoMese.TabIndex = 31
        Me.optGiornoMese.TabStop = True
        Me.optGiornoMese.Text = "Giorno del mese"
        Me.optGiornoMese.UseVisualStyleBackColor = True
        '
        'pnlMese
        '
        Me.pnlMese.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMese.Controls.Add(Me.Label2)
        Me.pnlMese.Controls.Add(Me.txtGiorni)
        Me.pnlMese.Controls.Add(Me.Label1)
        Me.pnlMese.Location = New System.Drawing.Point(4, 188)
        Me.pnlMese.Name = "pnlMese"
        Me.pnlMese.Size = New System.Drawing.Size(258, 44)
        Me.pnlMese.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 11)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inserire i numeri dei giorni separati da punti e virgola"
        '
        'txtGiorni
        '
        Me.txtGiorni.Location = New System.Drawing.Point(66, 4)
        Me.txtGiorni.Name = "txtGiorni"
        Me.txtGiorni.Size = New System.Drawing.Size(185, 20)
        Me.txtGiorni.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Giorno(i)"
        '
        'txtOrario
        '
        Me.txtOrario.Location = New System.Drawing.Point(71, 249)
        Me.txtOrario.Name = "txtOrario"
        Me.txtOrario.Size = New System.Drawing.Size(185, 20)
        Me.txtOrario.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Orario"
        '
        'cmdSalva
        '
        Me.cmdSalva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalva.Location = New System.Drawing.Point(196, 275)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.Size = New System.Drawing.Size(66, 21)
        Me.cmdSalva.TabIndex = 35
        Me.cmdSalva.Text = "Salva"
        Me.cmdSalva.UseVisualStyleBackColor = True
        '
        'optNulla
        '
        Me.optNulla.AutoSize = True
        Me.optNulla.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optNulla.Location = New System.Drawing.Point(4, 33)
        Me.optNulla.Name = "optNulla"
        Me.optNulla.Size = New System.Drawing.Size(151, 20)
        Me.optNulla.TabIndex = 36
        Me.optNulla.TabStop = True
        Me.optNulla.Text = "Nessuna schedulazione"
        Me.optNulla.UseVisualStyleBackColor = True
        '
        'frmSchedulazione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 308)
        Me.Controls.Add(Me.optNulla)
        Me.Controls.Add(Me.cmdSalva)
        Me.Controls.Add(Me.txtOrario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlMese)
        Me.Controls.Add(Me.optGiornoMese)
        Me.Controls.Add(Me.optGiorno)
        Me.Controls.Add(Me.pnlGiorni)
        Me.Controls.Add(Me.lblNomeProc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSchedulazione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schedulazione"
        Me.pnlGiorni.ResumeLayout(False)
        Me.pnlGiorni.PerformLayout()
        Me.pnlMese.ResumeLayout(False)
        Me.pnlMese.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNomeProc As System.Windows.Forms.Label
    Friend WithEvents pnlGiorni As System.Windows.Forms.Panel
    Friend WithEvents chkDomenica As System.Windows.Forms.CheckBox
    Friend WithEvents chkSabato As System.Windows.Forms.CheckBox
    Friend WithEvents chkVenerdi As System.Windows.Forms.CheckBox
    Friend WithEvents chkGiovedi As System.Windows.Forms.CheckBox
    Friend WithEvents chkMercoledi As System.Windows.Forms.CheckBox
    Friend WithEvents chkMartedi As System.Windows.Forms.CheckBox
    Friend WithEvents chkLunedi As System.Windows.Forms.CheckBox
    Friend WithEvents optGiorno As System.Windows.Forms.RadioButton
    Friend WithEvents optGiornoMese As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMese As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGiorni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents optNulla As System.Windows.Forms.RadioButton
End Class
