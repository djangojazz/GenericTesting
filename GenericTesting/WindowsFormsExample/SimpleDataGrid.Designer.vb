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
    Me.ds = New System.Data.DataSet()
    Me.tProduct = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.lbl = New System.Windows.Forms.Label()
    Me.btnGetValues = New System.Windows.Forms.Button()
    Me.tBase = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TestDropDown = New System.Windows.Forms.DataGridViewComboBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    CType(Me.tBase, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.AutoGenerateColumns = False
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn, Me.TestDropDown})
    Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
    Me.dgv.DataMember = "tBase"
    Me.dgv.DataSource = Me.ds
    Me.dgv.Location = New System.Drawing.Point(26, 12)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(340, 150)
    Me.dgv.TabIndex = 0
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tProduct, Me.tBase})
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
    Me.DataColumn2.ColumnName = "Whatevs"
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
    'btnGetValues
    '
    Me.btnGetValues.Location = New System.Drawing.Point(291, 185)
    Me.btnGetValues.Name = "btnGetValues"
    Me.btnGetValues.Size = New System.Drawing.Size(75, 23)
    Me.btnGetValues.TabIndex = 2
    Me.btnGetValues.Text = "GetData"
    Me.btnGetValues.UseVisualStyleBackColor = True
    '
    'tBase
    '
    Me.tBase.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn3, Me.DataColumn4, Me.DataColumn5})
    Me.tBase.TableName = "tBase"
    '
    'DataColumn3
    '
    Me.DataColumn3.ColumnName = "Id"
    Me.DataColumn3.DataType = GetType(Integer)
    '
    'DataColumn4
    '
    Me.DataColumn4.ColumnName = "Value"
    '
    'DataColumn5
    '
    Me.DataColumn5.ColumnName = "ProductId"
    '
    'IdDataGridViewTextBoxColumn
    '
    Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
    Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
    Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
    '
    'ValueDataGridViewTextBoxColumn
    '
    Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
    Me.ValueDataGridViewTextBoxColumn.HeaderText = "Value"
    Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
    '
    'TestDropDown
    '
    Me.TestDropDown.DataPropertyName = "ProductId"
    Me.TestDropDown.DataSource = Me.ds
    Me.TestDropDown.DisplayMember = "tProduct.Whatevs"
    Me.TestDropDown.HeaderText = "TestDropDown"
    Me.TestDropDown.Name = "TestDropDown"
    Me.TestDropDown.ValueMember = "tProduct.ProductId"
    '
    'SimpleDataGrid
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(392, 261)
    Me.Controls.Add(Me.btnGetValues)
    Me.Controls.Add(Me.lbl)
    Me.Controls.Add(Me.dgv)
    Me.Name = "SimpleDataGrid"
    Me.Text = "SimpleDataGrid"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    CType(Me.tBase, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lbl As Label
  Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
  Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ds As DataSet
  Friend WithEvents tProduct As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents btnGetValues As Button
  Friend WithEvents tBase As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents ValueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
  Friend WithEvents TestDropDown As DataGridViewComboBoxColumn
End Class
