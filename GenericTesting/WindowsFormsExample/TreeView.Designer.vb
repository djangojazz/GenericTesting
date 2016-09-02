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
    Me.components = New System.ComponentModel.Container()
    Me.treeProductFormatChanges = New System.Windows.Forms.TreeView()
    Me.cmnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.mnuNewChildProductFormatChange = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuMaintainProductFormatChange = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuDeleteProductFormatChange = New System.Windows.Forms.ToolStripMenuItem()
    Me.cmnu.SuspendLayout()
    Me.SuspendLayout()
    '
    'treeProductFormatChanges
    '
    Me.treeProductFormatChanges.ContextMenuStrip = Me.cmnu
    Me.treeProductFormatChanges.Dock = System.Windows.Forms.DockStyle.Fill
    Me.treeProductFormatChanges.Location = New System.Drawing.Point(0, 0)
    Me.treeProductFormatChanges.Name = "treeProductFormatChanges"
    Me.treeProductFormatChanges.Size = New System.Drawing.Size(384, 761)
    Me.treeProductFormatChanges.TabIndex = 1
    '
    'cmnu
    '
    Me.cmnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewChildProductFormatChange, Me.mnuMaintainProductFormatChange, Me.mnuDeleteProductFormatChange})
    Me.cmnu.Name = "cmnu"
    Me.cmnu.Size = New System.Drawing.Size(153, 92)
    '
    'mnuNewChildProductFormatChange
    '
    Me.mnuNewChildProductFormatChange.Name = "mnuNewChildProductFormatChange"
    Me.mnuNewChildProductFormatChange.Size = New System.Drawing.Size(152, 22)
    Me.mnuNewChildProductFormatChange.Text = "New"
    '
    'mnuMaintainProductFormatChange
    '
    Me.mnuMaintainProductFormatChange.Name = "mnuMaintainProductFormatChange"
    Me.mnuMaintainProductFormatChange.Size = New System.Drawing.Size(152, 22)
    Me.mnuMaintainProductFormatChange.Text = "Maintain"
    '
    'mnuDeleteProductFormatChange
    '
    Me.mnuDeleteProductFormatChange.Name = "mnuDeleteProductFormatChange"
    Me.mnuDeleteProductFormatChange.Size = New System.Drawing.Size(152, 22)
    Me.mnuDeleteProductFormatChange.Text = "Delete"
    '
    'TreeView
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(384, 761)
    Me.Controls.Add(Me.treeProductFormatChanges)
    Me.Name = "TreeView"
    Me.Text = "TreeView"
    Me.cmnu.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents treeProductFormatChanges As System.Windows.Forms.TreeView
  Friend WithEvents cmnu As ContextMenuStrip
  Friend WithEvents mnuNewChildProductFormatChange As ToolStripMenuItem
  Friend WithEvents mnuMaintainProductFormatChange As ToolStripMenuItem
  Friend WithEvents mnuDeleteProductFormatChange As ToolStripMenuItem
End Class
