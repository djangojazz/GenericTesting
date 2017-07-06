<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataGridDynamic
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
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.lTest = New System.Windows.Forms.Label()
    Me.tTest = New System.Windows.Forms.TextBox()
    Me.bDoIt = New System.Windows.Forms.Button()
    Me.btnGetIt = New System.Windows.Forms.Button()
    Me.PersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.dgvHail = New System.Windows.Forms.DataGridView()
    Me.data = New System.Data.DataSet()
    Me.tHail = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.tCountries = New System.Data.DataTable()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.DataColumn7 = New System.Data.DataColumn()
    Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.OrderId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.HailDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.CatchDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Harvested = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Processed = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvHail, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.data, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tHail, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tCountries, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderId, Me.PersonId, Me.FirstName, Me.LastName})
    Me.dgv.Location = New System.Drawing.Point(12, 235)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(548, 83)
    Me.dgv.TabIndex = 0
    '
    'lTest
    '
    Me.lTest.AutoSize = True
    Me.lTest.Location = New System.Drawing.Point(11, 344)
    Me.lTest.Name = "lTest"
    Me.lTest.Size = New System.Drawing.Size(96, 13)
    Me.lTest.TabIndex = 1
    Me.lTest.Text = "TEST For the label"
    '
    'tTest
    '
    Me.tTest.Location = New System.Drawing.Point(113, 337)
    Me.tTest.Name = "tTest"
    Me.tTest.Size = New System.Drawing.Size(100, 20)
    Me.tTest.TabIndex = 2
    Me.tTest.Text = "1"
    '
    'bDoIt
    '
    Me.bDoIt.Location = New System.Drawing.Point(234, 335)
    Me.bDoIt.Name = "bDoIt"
    Me.bDoIt.Size = New System.Drawing.Size(75, 23)
    Me.bDoIt.TabIndex = 3
    Me.bDoIt.Text = "Do It"
    Me.bDoIt.UseVisualStyleBackColor = True
    '
    'btnGetIt
    '
    Me.btnGetIt.Location = New System.Drawing.Point(327, 334)
    Me.btnGetIt.Name = "btnGetIt"
    Me.btnGetIt.Size = New System.Drawing.Size(75, 23)
    Me.btnGetIt.TabIndex = 4
    Me.btnGetIt.Text = "GetIt"
    Me.btnGetIt.UseVisualStyleBackColor = True
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
    'dgvHail
    '
    Me.dgvHail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvHail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HailDetailId, Me.CatchDate, Me.Harvested, Me.Processed, Me.Weight})
    Me.dgvHail.Location = New System.Drawing.Point(13, 13)
    Me.dgvHail.Name = "dgvHail"
    Me.dgvHail.Size = New System.Drawing.Size(547, 177)
    Me.dgvHail.TabIndex = 5
    '
    'data
    '
    Me.data.DataSetName = "data"
    Me.data.Tables.AddRange(New System.Data.DataTable() {Me.tHail, Me.tCountries})
    '
    'tHail
    '
    Me.tHail.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5})
    Me.tHail.TableName = "tHail"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "HailDetailId"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "Weight"
    Me.DataColumn2.DataType = GetType(Double)
    '
    'DataColumn3
    '
    Me.DataColumn3.ColumnName = "Harvested"
    Me.DataColumn3.DataType = GetType(Integer)
    '
    'DataColumn4
    '
    Me.DataColumn4.ColumnName = "Processed"
    Me.DataColumn4.DataType = GetType(Integer)
    '
    'DataColumn5
    '
    Me.DataColumn5.ColumnName = "CatchDate"
    Me.DataColumn5.DataType = GetType(Date)
    '
    'tCountries
    '
    Me.tCountries.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn6, Me.DataColumn7})
    Me.tCountries.TableName = "tCountries"
    '
    'DataColumn6
    '
    Me.DataColumn6.ColumnName = "CountryId"
    Me.DataColumn6.DataType = GetType(Integer)
    '
    'DataColumn7
    '
    Me.DataColumn7.ColumnName = "Country"
    '
    'DataGridViewComboBoxColumn1
    '
    Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.DataGridViewComboBoxColumn1.DataPropertyName = "OrderId"
    DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
    DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
    Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
    Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.DataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = True
    Me.DataGridViewComboBoxColumn1.FillWeight = 30.0!
    Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.DataGridViewComboBoxColumn1.HeaderText = "ORDER"
    Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
    Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'DataGridViewComboBoxColumn2
    '
    Me.DataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.DataGridViewComboBoxColumn2.DataPropertyName = "Harvested"
    Me.DataGridViewComboBoxColumn2.DataSource = Me.data
    Me.DataGridViewComboBoxColumn2.DisplayMember = "tCountries.Country"
    Me.DataGridViewComboBoxColumn2.FillWeight = 10.0!
    Me.DataGridViewComboBoxColumn2.HeaderText = "Harvested"
    Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
    Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.DataGridViewComboBoxColumn2.ValueMember = "tCountries.CountryId"
    '
    'DataGridViewComboBoxColumn3
    '
    Me.DataGridViewComboBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.DataGridViewComboBoxColumn3.DataPropertyName = "Processed"
    Me.DataGridViewComboBoxColumn3.DataSource = Me.data
    Me.DataGridViewComboBoxColumn3.DisplayMember = "tCountries.CountryId"
    Me.DataGridViewComboBoxColumn3.FillWeight = 10.0!
    Me.DataGridViewComboBoxColumn3.HeaderText = "Processed"
    Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
    Me.DataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.DataGridViewComboBoxColumn3.ValueMember = "tCountries.Country"
    '
    'OrderId
    '
    Me.OrderId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.OrderId.DataPropertyName = "OrderId"
    DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
    DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
    Me.OrderId.DefaultCellStyle = DataGridViewCellStyle6
    Me.OrderId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.OrderId.DisplayStyleForCurrentCellOnly = True
    Me.OrderId.FillWeight = 30.0!
    Me.OrderId.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.OrderId.HeaderText = "ORDER"
    Me.OrderId.Name = "OrderId"
    Me.OrderId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.OrderId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'HailDetailId
    '
    Me.HailDetailId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.HailDetailId.DataPropertyName = "HailDetailId"
    Me.HailDetailId.FillWeight = 50.0!
    Me.HailDetailId.HeaderText = "Hail Detail Id"
    Me.HailDetailId.Name = "HailDetailId"
    '
    'CatchDate
    '
    Me.CatchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.CatchDate.DataPropertyName = "CatchDate"
    Me.CatchDate.FillWeight = 10.0!
    Me.CatchDate.HeaderText = "CatchDate"
    Me.CatchDate.Name = "CatchDate"
    '
    'Harvested
    '
    Me.Harvested.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.Harvested.DataPropertyName = "Harvested"
    Me.Harvested.FillWeight = 10.0!
    Me.Harvested.HeaderText = "Harvested"
    Me.Harvested.Name = "Harvested"
    Me.Harvested.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Harvested.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'Processed
    '
    Me.Processed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.Processed.DataPropertyName = "Processed"
    Me.Processed.DataSource = Me.data
    Me.Processed.DisplayMember = "tCountries.Country"
    Me.Processed.FillWeight = 10.0!
    Me.Processed.HeaderText = "Processed"
    Me.Processed.Name = "Processed"
    Me.Processed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Processed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.Processed.ValueMember = "tCountries.CountryId"
    '
    'Weight
    '
    Me.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.Weight.DataPropertyName = "Weight"
    Me.Weight.FillWeight = 20.0!
    Me.Weight.HeaderText = "Weight"
    Me.Weight.Name = "Weight"
    '
    'DataGridDynamic
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(588, 427)
    Me.Controls.Add(Me.dgvHail)
    Me.Controls.Add(Me.btnGetIt)
    Me.Controls.Add(Me.bDoIt)
    Me.Controls.Add(Me.tTest)
    Me.Controls.Add(Me.lTest)
    Me.Controls.Add(Me.dgv)
    Me.Name = "DataGridDynamic"
    Me.Text = "DataGridDynamic"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvHail, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.data, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tHail, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tCountries, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lTest As Label
  Friend WithEvents tTest As TextBox
  Friend WithEvents bDoIt As Button
  Friend WithEvents btnGetIt As Button
  Friend WithEvents OrderId As DataGridViewComboBoxColumn
  Friend WithEvents PersonId As DataGridViewTextBoxColumn
  Friend WithEvents FirstName As DataGridViewTextBoxColumn
  Friend WithEvents LastName As DataGridViewTextBoxColumn
  Friend WithEvents dgvHail As DataGridView
  Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
  Friend WithEvents data As DataSet
  Friend WithEvents tHail As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents tCountries As DataTable
  Friend WithEvents DataColumn6 As DataColumn
  Friend WithEvents DataColumn7 As DataColumn
  Friend WithEvents DataGridViewComboBoxColumn2 As DataGridViewComboBoxColumn
  Friend WithEvents DataGridViewComboBoxColumn3 As DataGridViewComboBoxColumn
  Friend WithEvents HailDetailId As DataGridViewTextBoxColumn
  Friend WithEvents CatchDate As DataGridViewTextBoxColumn
  Friend WithEvents Harvested As DataGridViewComboBoxColumn
  Friend WithEvents Processed As DataGridViewComboBoxColumn
  Friend WithEvents Weight As DataGridViewTextBoxColumn
End Class
