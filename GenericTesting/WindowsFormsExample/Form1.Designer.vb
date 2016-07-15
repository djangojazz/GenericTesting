<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.OpenDataGridViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SimpleDataGridViewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
    Me.SimpleErrorCheckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDataGridViewToolStripMenuItem, Me.SimpleDataGridViewToolStripMenuItem1, Me.SimpleErrorCheckingToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(658, 24)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'OpenDataGridViewToolStripMenuItem
    '
    Me.OpenDataGridViewToolStripMenuItem.Name = "OpenDataGridViewToolStripMenuItem"
    Me.OpenDataGridViewToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
    Me.OpenDataGridViewToolStripMenuItem.Text = "OpenDataGridView"
    '
    'SimpleDataGridViewToolStripMenuItem1
    '
    Me.SimpleDataGridViewToolStripMenuItem1.Name = "SimpleDataGridViewToolStripMenuItem1"
    Me.SimpleDataGridViewToolStripMenuItem1.Size = New System.Drawing.Size(126, 20)
    Me.SimpleDataGridViewToolStripMenuItem1.Text = "SimpleDataGridView"
    '
    'SimpleErrorCheckingToolStripMenuItem
    '
    Me.SimpleErrorCheckingToolStripMenuItem.Name = "SimpleErrorCheckingToolStripMenuItem"
    Me.SimpleErrorCheckingToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
    Me.SimpleErrorCheckingToolStripMenuItem.Text = "SimpleErrorChecking"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(658, 394)
    Me.Controls.Add(Me.MenuStrip1)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents OpenDataGridViewToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SimpleDataGridViewToolStripMenuItem1 As ToolStripMenuItem
  Friend WithEvents SimpleErrorCheckingToolStripMenuItem As ToolStripMenuItem
End Class
