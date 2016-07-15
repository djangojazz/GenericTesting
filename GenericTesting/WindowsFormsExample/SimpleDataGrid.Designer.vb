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
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.lbl = New System.Windows.Forms.Label()
    Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TestDropDown = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.ds = New System.Data.DataSet()
    Me.tProduct = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Value, Me.TestDropDown})
    Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
    Me.dgv.Location = New System.Drawing.Point(26, 12)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(340, 150)
    Me.dgv.TabIndex = 0
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
    Me.TestToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
    Me.TestToolStripMenuItem.Text = "Test"
    '
    'lbl
    '
    Me.lbl.AutoSize = True
    Me.lbl.Location = New System.Drawing.Point(23, 195)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(0, 13)
    Me.lbl.TabIndex = 1
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
    '
    'TestDropDown
    '
    Me.TestDropDown.HeaderText = "TestDropDown"
    Me.TestDropDown.Name = "TestDropDown"
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tProduct})
    '
    'tProduct
    '
    Me.tProduct.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
    Me.tProduct.TableName = "tProduct"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "ProductId"
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "ProductDescription"
    '
    'SimpleDataGrid
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(392, 261)
    Me.Controls.Add(Me.lbl)
    Me.Controls.Add(Me.dgv)
    Me.Name = "SimpleDataGrid"
    Me.Text = "SimpleDataGrid"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lbl As Label
  Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
  Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ID As DataGridViewTextBoxColumn
  Friend WithEvents Value As DataGridViewTextBoxColumn
  Friend WithEvents TestDropDown As DataGridViewComboBoxColumn
  Friend WithEvents ds As DataSet
  Friend WithEvents tProduct As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
End Class
