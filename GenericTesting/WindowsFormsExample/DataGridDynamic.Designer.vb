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
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.ds = New System.Data.DataSet()
    Me.tOrders = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.tPeople = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.lTest = New System.Windows.Forms.Label()
    Me.tTest = New System.Windows.Forms.TextBox()
    Me.bDoIt = New System.Windows.Forms.Button()
    Me.btnGetIt = New System.Windows.Forms.Button()
    Me.OrderId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.PersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tOrders, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderId, Me.PersonId, Me.FirstName, Me.LastName})
    Me.dgv.Location = New System.Drawing.Point(13, 13)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(523, 219)
    Me.dgv.TabIndex = 0
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tOrders, Me.tPeople})
    '
    'tOrders
    '
    Me.tOrders.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
    Me.tOrders.TableName = "tOrders"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "OrderId"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "Description"
    '
    'tPeople
    '
    Me.tPeople.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6})
    Me.tPeople.TableName = "tPeople"
    '
    'DataColumn3
    '
    Me.DataColumn3.ColumnName = "OrderId"
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
    'lTest
    '
    Me.lTest.AutoSize = True
    Me.lTest.Location = New System.Drawing.Point(11, 248)
    Me.lTest.Name = "lTest"
    Me.lTest.Size = New System.Drawing.Size(96, 13)
    Me.lTest.TabIndex = 1
    Me.lTest.Text = "TEST For the label"
    '
    'tTest
    '
    Me.tTest.Location = New System.Drawing.Point(113, 241)
    Me.tTest.Name = "tTest"
    Me.tTest.Size = New System.Drawing.Size(100, 20)
    Me.tTest.TabIndex = 2
    Me.tTest.Text = "1"
    '
    'bDoIt
    '
    Me.bDoIt.Location = New System.Drawing.Point(234, 239)
    Me.bDoIt.Name = "bDoIt"
    Me.bDoIt.Size = New System.Drawing.Size(75, 23)
    Me.bDoIt.TabIndex = 3
    Me.bDoIt.Text = "Do It"
    Me.bDoIt.UseVisualStyleBackColor = True
    '
    'btnGetIt
    '
    Me.btnGetIt.Location = New System.Drawing.Point(327, 238)
    Me.btnGetIt.Name = "btnGetIt"
    Me.btnGetIt.Size = New System.Drawing.Size(75, 23)
    Me.btnGetIt.TabIndex = 4
    Me.btnGetIt.Text = "GetIt"
    Me.btnGetIt.UseVisualStyleBackColor = True
    '
    'OrderId
    '
    Me.OrderId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.OrderId.DataPropertyName = "OrderId"
    Me.OrderId.FillWeight = 30.0!
    Me.OrderId.HeaderText = "ORDER"
    Me.OrderId.Name = "OrderId"
    Me.OrderId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.OrderId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
    'DataGridDynamic
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(548, 273)
    Me.Controls.Add(Me.btnGetIt)
    Me.Controls.Add(Me.bDoIt)
    Me.Controls.Add(Me.tTest)
    Me.Controls.Add(Me.lTest)
    Me.Controls.Add(Me.dgv)
    Me.Name = "DataGridDynamic"
    Me.Text = "DataGridDynamic"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tOrders, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lTest As Label
  Friend WithEvents ds As DataSet
  Friend WithEvents tOrders As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents tTest As TextBox
  Friend WithEvents bDoIt As Button
  Friend WithEvents btnGetIt As Button
  Friend WithEvents tPeople As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents DataColumn6 As DataColumn
  Friend WithEvents OrderId As DataGridViewComboBoxColumn
  Friend WithEvents PersonId As DataGridViewTextBoxColumn
  Friend WithEvents FirstName As DataGridViewTextBoxColumn
  Friend WithEvents LastName As DataGridViewTextBoxColumn
End Class
