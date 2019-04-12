<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettaggi
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLettera = New System.Windows.Forms.TextBox()
        Me.cmdSalva = New System.Windows.Forms.Button()
        Me.cmdEliminaDatiSI = New System.Windows.Forms.Button()
        Me.btnEliminaVecchiFiles = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lettera disco da mappare"
        '
        'txtLettera
        '
        Me.txtLettera.Location = New System.Drawing.Point(183, 6)
        Me.txtLettera.MaxLength = 1
        Me.txtLettera.Name = "txtLettera"
        Me.txtLettera.Size = New System.Drawing.Size(37, 20)
        Me.txtLettera.TabIndex = 1
        '
        'cmdSalva
        '
        Me.cmdSalva.Location = New System.Drawing.Point(145, 87)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.Size = New System.Drawing.Size(75, 23)
        Me.cmdSalva.TabIndex = 2
        Me.cmdSalva.Text = "Salva"
        Me.cmdSalva.UseVisualStyleBackColor = True
        '
        'cmdEliminaDatiSI
        '
        Me.cmdEliminaDatiSI.Location = New System.Drawing.Point(12, 30)
        Me.cmdEliminaDatiSI.Name = "cmdEliminaDatiSI"
        Me.cmdEliminaDatiSI.Size = New System.Drawing.Size(208, 23)
        Me.cmdEliminaDatiSI.TabIndex = 3
        Me.cmdEliminaDatiSI.Text = "Elimina i dati di sincronia intelligente"
        Me.cmdEliminaDatiSI.UseVisualStyleBackColor = True
        '
        'btnEliminaVecchiFiles
        '
        Me.btnEliminaVecchiFiles.Location = New System.Drawing.Point(12, 58)
        Me.btnEliminaVecchiFiles.Name = "btnEliminaVecchiFiles"
        Me.btnEliminaVecchiFiles.Size = New System.Drawing.Size(208, 23)
        Me.btnEliminaVecchiFiles.TabIndex = 4
        Me.btnEliminaVecchiFiles.Text = "Elimina i files di log vecchi"
        Me.btnEliminaVecchiFiles.UseVisualStyleBackColor = True
        '
        'frmSettaggi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(229, 122)
        Me.Controls.Add(Me.btnEliminaVecchiFiles)
        Me.Controls.Add(Me.cmdEliminaDatiSI)
        Me.Controls.Add(Me.cmdSalva)
        Me.Controls.Add(Me.txtLettera)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSettaggi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settaggi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLettera As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents cmdEliminaDatiSI As System.Windows.Forms.Button
    Friend WithEvents btnEliminaVecchiFiles As Button
End Class
