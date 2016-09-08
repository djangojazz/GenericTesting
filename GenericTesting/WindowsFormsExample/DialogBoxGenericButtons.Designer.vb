<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogBoxGenericButtons
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
    Me.ds = New System.Data.DataSet()
    Me.tOrders = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.tPeople = New System.Data.DataTable()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn4 = New System.Data.DataColumn()
    Me.DataColumn5 = New System.Data.DataColumn()
    Me.DataColumn6 = New System.Data.DataColumn()
    Me.b1 = New System.Windows.Forms.Button()
    Me.b2 = New System.Windows.Forms.Button()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tOrders, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    'b1
    '
    Me.b1.Location = New System.Drawing.Point(12, 29)
    Me.b1.Name = "b1"
    Me.b1.Size = New System.Drawing.Size(75, 23)
    Me.b1.TabIndex = 3
    Me.b1.Text = "1st Button"
    Me.b1.UseVisualStyleBackColor = True
    '
    'b2
    '
    Me.b2.Location = New System.Drawing.Point(115, 29)
    Me.b2.Name = "b2"
    Me.b2.Size = New System.Drawing.Size(75, 23)
    Me.b2.TabIndex = 4
    Me.b2.Text = "2nd Button"
    Me.b2.UseVisualStyleBackColor = True
    '
    'DialogBoxGenericButtons
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 94)
    Me.Controls.Add(Me.b2)
    Me.Controls.Add(Me.b1)
    Me.Name = "DialogBoxGenericButtons"
    Me.Text = "DataGridDynamic"
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tOrders, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tPeople, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ds As DataSet
  Friend WithEvents tOrders As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents b1 As Button
  Friend WithEvents b2 As Button
  Friend WithEvents tPeople As DataTable
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn4 As DataColumn
  Friend WithEvents DataColumn5 As DataColumn
  Friend WithEvents DataColumn6 As DataColumn
End Class
