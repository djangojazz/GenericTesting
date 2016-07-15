<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleDataGrid
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
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.lbl = New System.Windows.Forms.Label()
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Value})
    Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
    Me.dgv.Location = New System.Drawing.Point(12, 12)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(240, 150)
    Me.dgv.TabIndex = 0
    '
    'ID
    '
    Me.ID.HeaderText = "ID"
    Me.ID.Name = "ID"
    Me.ID.Width = 30
    '
    'Value
    '
    Me.Value.HeaderText = "Value"
    Me.Value.Name = "Value"
    Me.Value.Width = 300
    '
    'lbl
    '
    Me.lbl.AutoSize = True
    Me.lbl.Location = New System.Drawing.Point(23, 195)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(0, 13)
    Me.lbl.TabIndex = 1
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(96, 26)
    '
    'TestToolStripMenuItem
    '
    Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
    Me.TestToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.TestToolStripMenuItem.Text = "Test"
    '
    'SimpleDataGrid
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(290, 261)
    Me.Controls.Add(Me.lbl)
    Me.Controls.Add(Me.dgv)
    Me.Name = "SimpleDataGrid"
    Me.Text = "SimpleDataGrid"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lbl As Label
  Friend WithEvents ID As DataGridViewTextBoxColumn
  Friend WithEvents Value As DataGridViewTextBoxColumn
  Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
  Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
End Class
