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
    Me.OrderId = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.ds = New System.Data.DataSet()
    Me.tOrders = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.lTest = New System.Windows.Forms.Label()
    Me.tTest = New System.Windows.Forms.TextBox()
    Me.bDoIt = New System.Windows.Forms.Button()
    Me.btnGetIt = New System.Windows.Forms.Button()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tOrders, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderId})
    Me.dgv.Location = New System.Drawing.Point(13, 13)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(401, 150)
    Me.dgv.TabIndex = 0
    '
    'OrderId
    '
    Me.OrderId.DataPropertyName = "OrderId"
    Me.OrderId.DataSource = Me.ds
    Me.OrderId.DisplayMember = "tOrders.Description"
    Me.OrderId.HeaderText = "ORDER"
    Me.OrderId.Name = "OrderId"
    Me.OrderId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.OrderId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.OrderId.ValueMember = "tOrders.OrderId"
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tOrders})
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
    'lTest
    '
    Me.lTest.AutoSize = True
    Me.lTest.Location = New System.Drawing.Point(13, 196)
    Me.lTest.Name = "lTest"
    Me.lTest.Size = New System.Drawing.Size(96, 13)
    Me.lTest.TabIndex = 1
    Me.lTest.Text = "TEST For the label"
    '
    'tTest
    '
    Me.tTest.Location = New System.Drawing.Point(115, 189)
    Me.tTest.Name = "tTest"
    Me.tTest.Size = New System.Drawing.Size(100, 20)
    Me.tTest.TabIndex = 2
    Me.tTest.Text = "1"
    '
    'bDoIt
    '
    Me.bDoIt.Location = New System.Drawing.Point(236, 187)
    Me.bDoIt.Name = "bDoIt"
    Me.bDoIt.Size = New System.Drawing.Size(75, 23)
    Me.bDoIt.TabIndex = 3
    Me.bDoIt.Text = "Do It"
    Me.bDoIt.UseVisualStyleBackColor = True
    '
    'btnGetIt
    '
    Me.btnGetIt.Location = New System.Drawing.Point(329, 186)
    Me.btnGetIt.Name = "btnGetIt"
    Me.btnGetIt.Size = New System.Drawing.Size(75, 23)
    Me.btnGetIt.TabIndex = 4
    Me.btnGetIt.Text = "GetIt"
    Me.btnGetIt.UseVisualStyleBackColor = True
    '
    'DataGridDynamic
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(498, 273)
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
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents lTest As Label
  Friend WithEvents ds As DataSet
  Friend WithEvents tOrders As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents OrderId As DataGridViewComboBoxColumn
  Friend WithEvents tTest As TextBox
  Friend WithEvents bDoIt As Button
  Friend WithEvents btnGetIt As Button
End Class
