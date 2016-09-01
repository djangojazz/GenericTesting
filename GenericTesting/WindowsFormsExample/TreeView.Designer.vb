<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TreeView
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
    Me.lbl = New System.Windows.Forms.Label()
    Me.treeProductFormatChanges = New System.Windows.Forms.TreeView()
    Me.SuspendLayout()
    '
    'lbl
    '
    Me.lbl.AutoSize = True
    Me.lbl.Location = New System.Drawing.Point(13, 13)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(28, 13)
    Me.lbl.TabIndex = 0
    Me.lbl.Text = "Test"
    '
    'treeProductFormatChanges
    '
    Me.treeProductFormatChanges.Location = New System.Drawing.Point(13, 52)
    Me.treeProductFormatChanges.Name = "treeProductFormatChanges"
    Me.treeProductFormatChanges.Size = New System.Drawing.Size(384, 271)
    Me.treeProductFormatChanges.TabIndex = 1
    '
    'TreeView
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(417, 344)
    Me.Controls.Add(Me.treeProductFormatChanges)
    Me.Controls.Add(Me.lbl)
    Me.Name = "TreeView"
    Me.Text = "TreeView"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents lbl As Label
  Friend WithEvents treeProductFormatChanges As System.Windows.Forms.TreeView
End Class
