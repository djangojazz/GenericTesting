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
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.ds = New System.Data.DataSet()
    Me.tProduct = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.tBase = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.DataColumn7 = New System.Data.DataColumn()
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.lblx = New System.Windows.Forms.Label()
    Me.btnGetValues = New System.Windows.Forms.Button()
    Me.lbly = New System.Windows.Forms.Label()
    Me.lblz = New System.Windows.Forms.Label()
    Me.txtTest = New System.Windows.Forms.TextBox()
    Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Computed = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TestDropDown = New System.Windows.Forms.DataGridViewComboBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tBase, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Computed, Me.TestDropDown})
    Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
    Me.dgv.Dock = System.Windows.Forms.DockStyle.Top
    Me.dgv.Location = New System.Drawing.Point(0, 0)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(622, 150)
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
    'tBase
    '
    Me.tBase.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn3, Me.DataColumn4, Me.DataColumn6, Me.DataColumn5, Me.DataColumn7})
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
    Me.DataColumn4.DataType = GetType(Integer)
    '
    'DataColumn6
    '
    Me.DataColumn6.Caption = "Percent"
    Me.DataColumn6.ColumnName = "Percent"
    Me.DataColumn6.DataType = GetType(Double)
    '
    'DataColumn5
    '
    Me.DataColumn5.Caption = "ProductId"
    Me.DataColumn5.ColumnName = "ProductId"
    '
    'DataColumn7
    '
    Me.DataColumn7.ColumnName = "Computed"
    Me.DataColumn7.DataType = GetType(Double)
    Me.DataColumn7.Expression = "Value * (Percent / 100)"
    Me.DataColumn7.ReadOnly = True
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
    'lblx
    '
    Me.lblx.AutoSize = True
    Me.lblx.Location = New System.Drawing.Point(12, 177)
    Me.lblx.Name = "lblx"
    Me.lblx.Size = New System.Drawing.Size(35, 13)
    Me.lblx.TabIndex = 1
    Me.lblx.Text = "TEST"
    '
    'btnGetValues
    '
    Me.btnGetValues.Location = New System.Drawing.Point(487, 172)
    Me.btnGetValues.Name = "btnGetValues"
    Me.btnGetValues.Size = New System.Drawing.Size(75, 23)
    Me.btnGetValues.TabIndex = 2
    Me.btnGetValues.Text = "GetData"
    Me.btnGetValues.UseVisualStyleBackColor = True
    '
    'lbly
    '
    Me.lbly.AutoSize = True
    Me.lbly.Location = New System.Drawing.Point(12, 201)
    Me.lbly.Name = "lbly"
    Me.lbly.Size = New System.Drawing.Size(41, 13)
    Me.lbly.TabIndex = 3
    Me.lbly.Text = "TEST2"
    '
    'lblz
    '
    Me.lblz.AutoSize = True
    Me.lblz.Location = New System.Drawing.Point(12, 227)
    Me.lblz.Name = "lblz"
    Me.lblz.Size = New System.Drawing.Size(41, 13)
    Me.lblz.TabIndex = 4
    Me.lblz.Text = "TEST3"
    '
    'txtTest
    '
    Me.txtTest.Location = New System.Drawing.Point(371, 177)
    Me.txtTest.Name = "txtTest"
    Me.txtTest.Size = New System.Drawing.Size(100, 20)
    Me.txtTest.TabIndex = 5
    Me.txtTest.Text = "1"
    '
    'Id
    '
    Me.Id.DataPropertyName = "Id"
    Me.Id.HeaderText = "Id"
    Me.Id.Name = "Id"
    '
    'Computed
    '
    Me.Computed.DataPropertyName = "Computed"
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
    Me.Computed.DefaultCellStyle = DataGridViewCellStyle2
    Me.Computed.HeaderText = "Computed"
    Me.Computed.Name = "Computed"
    Me.Computed.ReadOnly = True
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
    Me.ClientSize = New System.Drawing.Size(622, 261)
    Me.Controls.Add(Me.txtTest)
    Me.Controls.Add(Me.lblz)
    Me.Controls.Add(Me.lbly)
    Me.Controls.Add(Me.btnGetValues)
    Me.Controls.Add(Me.lblx)
    Me.Controls.Add(Me.dgv)
    Me.Name = "SimpleDataGrid"
    Me.Text = "SimpleDataGrid"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tProduct, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tBase, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lblx As Label
  Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
  Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ds As DataSet
  Friend WithEvents tProduct As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents tBase As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn6 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents btnGetValues As Button
  Friend WithEvents lbly As Label
  Friend WithEvents lblz As Label
  Friend WithEvents DataColumn7 As DataColumn
  Friend WithEvents txtTest As TextBox
  Friend WithEvents Id As DataGridViewTextBoxColumn
  Friend WithEvents Computed As DataGridViewTextBoxColumn
  Friend WithEvents TestDropDown As DataGridViewComboBoxColumn
End Class
