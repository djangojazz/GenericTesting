<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DynamicComboBoxDoubleFillSO
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
    Me.ds = New System.Data.DataSet()
    Me.Population = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.DataColumn8 = New System.Data.DataColumn()
    Me.Country = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.State = New System.Data.DataTable()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.DataColumn7 = New System.Data.DataColumn()
    Me.lTest = New System.Windows.Forms.Label()
    Me.CountryId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.StateId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.cPopulation = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Population, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Country, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.State, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CountryId, Me.StateId, Me.cPopulation})
    Me.dgv.Location = New System.Drawing.Point(13, 13)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(523, 150)
    Me.dgv.TabIndex = 0
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.Population, Me.Country, Me.State})
    '
    'Population
    '
    Me.Population.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn8})
    Me.Population.TableName = "Population"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "CountryId"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "StateId"
    Me.DataColumn2.DataType = GetType(Integer)
    '
    'DataColumn8
    '
    Me.DataColumn8.ColumnName = "Population"
    Me.DataColumn8.DataType = GetType(Integer)
    '
    'Country
    '
    Me.Country.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn3, Me.DataColumn4})
    Me.Country.TableName = "Country"
    '
    'DataColumn3
    '
    Me.DataColumn3.ColumnName = "Id"
    Me.DataColumn3.DataType = GetType(Integer)
    '
    'DataColumn4
    '
    Me.DataColumn4.ColumnName = "Name"
    '
    'State
    '
    Me.State.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn5, Me.DataColumn6, Me.DataColumn7})
    Me.State.TableName = "State"
    '
    'DataColumn5
    '
    Me.DataColumn5.ColumnName = "Id"
    Me.DataColumn5.DataType = GetType(Integer)
    '
    'DataColumn6
    '
    Me.DataColumn6.ColumnName = "Name"
    '
    'DataColumn7
    '
    Me.DataColumn7.ColumnName = "CountryId"
    Me.DataColumn7.DataType = GetType(Integer)
    '
    'lTest
    '
    Me.lTest.AutoSize = True
    Me.lTest.Location = New System.Drawing.Point(42, 193)
    Me.lTest.Name = "lTest"
    Me.lTest.Size = New System.Drawing.Size(39, 13)
    Me.lTest.TabIndex = 1
    Me.lTest.Text = "Label1"
    '
    'CountryId
    '
    Me.CountryId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    Me.CountryId.DataPropertyName = "CountryId"
    Me.CountryId.DataSource = Me.ds
    Me.CountryId.DisplayMember = "Country.Name"
    Me.CountryId.HeaderText = "CountryId"
    Me.CountryId.MinimumWidth = 200
    Me.CountryId.Name = "CountryId"
    Me.CountryId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.CountryId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.CountryId.ValueMember = "Country.Id"
    Me.CountryId.Width = 200
    '
    'StateId
    '
    Me.StateId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    Me.StateId.DataPropertyName = "StateId"
    Me.StateId.DataSource = Me.ds
    Me.StateId.DisplayMember = "State.Name"
    Me.StateId.HeaderText = "StateId"
    Me.StateId.MinimumWidth = 200
    Me.StateId.Name = "StateId"
    Me.StateId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.StateId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.StateId.ValueMember = "State.Id"
    Me.StateId.Width = 200
    '
    'cPopulation
    '
    Me.cPopulation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    Me.cPopulation.DataPropertyName = "Population"
    Me.cPopulation.HeaderText = "Population"
    Me.cPopulation.MinimumWidth = 200
    Me.cPopulation.Name = "cPopulation"
    Me.cPopulation.Width = 200
    '
    'DynamicComboBoxDoubleFillSO
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(548, 273)
    Me.Controls.Add(Me.lTest)
    Me.Controls.Add(Me.dgv)
    Me.Name = "DynamicComboBoxDoubleFillSO"
    Me.Text = "DataGridDynamic"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Population, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Country, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.State, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents ds As DataSet
  Friend WithEvents Population As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents Country As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents lTest As Label
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents DataColumn8 As DataColumn
  Friend WithEvents State As DataTable
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents DataColumn6 As DataColumn
  Friend WithEvents DataColumn7 As DataColumn
  Friend WithEvents CountryId As DataGridViewComboBoxColumn
  Friend WithEvents StateId As DataGridViewComboBoxColumn
  Friend WithEvents cPopulation As DataGridViewTextBoxColumn
End Class
