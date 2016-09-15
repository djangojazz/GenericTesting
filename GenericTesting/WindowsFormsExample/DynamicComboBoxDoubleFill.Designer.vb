<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DynamicComboBoxDoubleFill
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
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.ProductId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.ds = New System.Data.DataSet()
    Me.tProducts = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.tPeople = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.DataColumn7 = New System.Data.DataColumn()
    Me.PersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SKU = New System.Windows.Forms.DataGridViewComboBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tProducts, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductId, Me.PersonId, Me.FirstName, Me.LastName, Me.SKU})
    Me.dgv.Location = New System.Drawing.Point(13, 13)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(523, 150)
    Me.dgv.TabIndex = 0
    '
    'ProductId
    '
    Me.ProductId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.ProductId.DataPropertyName = "ProductId"
    Me.ProductId.DataSource = Me.ds
    Me.ProductId.DisplayMember = "tProducts.Description"
    Me.ProductId.FillWeight = 30.0!
    Me.ProductId.HeaderText = "PRODUCT"
    Me.ProductId.Name = "ProductId"
    Me.ProductId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.ProductId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.ProductId.ValueMember = "tProducts.ProductId"
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tProducts, Me.tPeople})
    '
    'tProducts
    '
    Me.tProducts.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
    Me.tProducts.TableName = "tProducts"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "ProductId"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "Description"
    '
    'tPeople
    '
    Me.tPeople.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7})
    Me.tPeople.TableName = "tPeople"
    '
    'DataColumn3
    '
    Me.DataColumn3.ColumnName = "ProductId"
    Me.DataColumn3.DataType = GetType(Integer)
    '
    'DataColumn4
    '
    Me.DataColumn4.ColumnName = "PersonId"
    '
    'DataColumn5
    '
    Me.DataColumn5.ColumnName = "FirstName"
    '
    'DataColumn6
    '
    Me.DataColumn6.ColumnName = "LastName"
    '
    'DataColumn7
    '
    Me.DataColumn7.ColumnName = "SkuId"
    '
    'PersonId
    '
    Me.PersonId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.PersonId.DataPropertyName = "PersonID"
    Me.PersonId.FillWeight = 20.0!
    Me.PersonId.HeaderText = "PersonID"
    Me.PersonId.Name = "PersonId"
    '
    'FirstName
    '
    Me.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.FirstName.DataPropertyName = "FirstName"
    Me.FirstName.FillWeight = 25.0!
    Me.FirstName.HeaderText = "FirstName"
    Me.FirstName.Name = "FirstName"
    '
    'LastName
    '
    Me.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.LastName.DataPropertyName = "LastName"
    Me.LastName.FillWeight = 25.0!
    Me.LastName.HeaderText = "LastName"
    Me.LastName.Name = "LastName"
    '
    'SKU
    '
    Me.SKU.DataPropertyName = "SKU"
    Me.SKU.HeaderText = "SKU"
    Me.SKU.Name = "SKU"
    Me.SKU.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.SKU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'DynamicComboBoxDoubleFill
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(548, 273)
    Me.Controls.Add(Me.dgv)
    Me.Name = "DynamicComboBoxDoubleFill"
    Me.Text = "DataGridDynamic"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tProducts, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents ds As DataSet
  Friend WithEvents tProducts As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents tPeople As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents DataColumn6 As DataColumn
  Friend WithEvents DataColumn7 As DataColumn
  Friend WithEvents ProductId As DataGridViewComboBoxColumn
  Friend WithEvents PersonId As DataGridViewTextBoxColumn
  Friend WithEvents FirstName As DataGridViewTextBoxColumn
  Friend WithEvents LastName As DataGridViewTextBoxColumn
  Friend WithEvents SKU As DataGridViewComboBoxColumn
End Class
