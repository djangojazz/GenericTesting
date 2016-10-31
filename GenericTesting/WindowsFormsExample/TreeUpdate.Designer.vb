<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TreeUpdate
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.txt = New System.Windows.Forms.TextBox()
    Me.btn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'txt
    '
    Me.txt.Location = New System.Drawing.Point(23, 29)
    Me.txt.Name = "txt"
    Me.txt.Size = New System.Drawing.Size(179, 20)
    Me.txt.TabIndex = 0
    '
    'btn
    '
    Me.btn.Location = New System.Drawing.Point(23, 70)
    Me.btn.Name = "btn"
    Me.btn.Size = New System.Drawing.Size(75, 23)
    Me.btn.TabIndex = 1
    Me.btn.Text = "Update"
    Me.btn.UseVisualStyleBackColor = True
    '
    'TreeUpdate
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(213, 111)
    Me.Controls.Add(Me.btn)
    Me.Controls.Add(Me.txt)
    Me.Name = "TreeUpdate"
    Me.Text = "TreeUpdate"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txt As TextBox
  Friend WithEvents btn As Button
End Class
