<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DynamicFilterOnTwoTextItems
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
    Me.tProducts = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn3 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.tPrd = New System.Windows.Forms.TextBox()
    Me.tsku = New System.Windows.Forms.TextBox()
    Me.lprd = New System.Windows.Forms.Label()
    Me.lSku = New System.Windows.Forms.Label()
    Me.ProductId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.SkuID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.bFilter = New System.Windows.Forms.Button()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.tProducts, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductId, Me.SkuID, Me.DESC})
    Me.dgv.Location = New System.Drawing.Point(13, 13)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(523, 150)
    Me.dgv.TabIndex = 0
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.tProducts})
    '
    'tProducts
    '
    Me.tProducts.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn3, Me.DataColumn2})
    Me.tProducts.TableName = "tProducts"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "ProductId"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn3
    '
    Me.DataColumn3.Caption = "SkuID"
    Me.DataColumn3.ColumnName = "SkuID"
    Me.DataColumn3.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "Desc"
    '
    'tPrd
    '
    Me.tPrd.Location = New System.Drawing.Point(72, 196)
    Me.tPrd.Name = "tPrd"
    Me.tPrd.Size = New System.Drawing.Size(100, 20)
    Me.tPrd.TabIndex = 1
    Me.tPrd.Text = "1"
    '
    'tsku
    '
    Me.tsku.Location = New System.Drawing.Point(233, 196)
    Me.tsku.Name = "tsku"
    Me.tsku.Size = New System.Drawing.Size(100, 20)
    Me.tsku.TabIndex = 2
    Me.tsku.Text = "1"
    '
    'lprd
    '
    Me.lprd.AutoSize = True
    Me.lprd.Location = New System.Drawing.Point(13, 203)
    Me.lprd.Name = "lprd"
    Me.lprd.Size = New System.Drawing.Size(56, 13)
    Me.lprd.TabIndex = 3
    Me.lprd.Text = "ProductId:"
    '
    'lSku
    '
    Me.lSku.AutoSize = True
    Me.lSku.Location = New System.Drawing.Point(189, 203)
    Me.lSku.Name = "lSku"
    Me.lSku.Size = New System.Drawing.Size(38, 13)
    Me.lSku.TabIndex = 4
    Me.lSku.Text = "SkuId:"
    '
    'ProductId
    '
    Me.ProductId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.ProductId.DataPropertyName = "ProductId"
    Me.ProductId.FillWeight = 30.0!
    Me.ProductId.HeaderText = "PRODUCT"
    Me.ProductId.Name = "ProductId"
    Me.ProductId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    '
    'SkuID
    '
    Me.SkuID.DataPropertyName = "SkuID"
    Me.SkuID.HeaderText = "SKU"
    Me.SkuID.Name = "SkuID"
    '
    'DESC
    '
    Me.DESC.DataPropertyName = "Desc"
    Me.DESC.HeaderText = "DESC"
    Me.DESC.Name = "DESC"
    '
    'bFilter
    '
    Me.bFilter.Location = New System.Drawing.Point(379, 194)
    Me.bFilter.Name = "bFilter"
    Me.bFilter.Size = New System.Drawing.Size(148, 23)
    Me.bFilter.TabIndex = 5
    Me.bFilter.Text = "Filter"
    Me.bFilter.UseVisualStyleBackColor = True
    '
    'DynamicFilterOnTwoTextItems
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(548, 273)
    Me.Controls.Add(Me.bFilter)
    Me.Controls.Add(Me.lSku)
    Me.Controls.Add(Me.lprd)
    Me.Controls.Add(Me.tsku)
    Me.Controls.Add(Me.tPrd)
    Me.Controls.Add(Me.dgv)
    Me.Name = "DynamicFilterOnTwoTextItems"
    Me.Text = "DataGridDynamic"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.tProducts, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents ds As DataSet
  Friend WithEvents tProducts As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn3 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents tPrd As TextBox
  Friend WithEvents tsku As TextBox
  Friend WithEvents lprd As Label
  Friend WithEvents lSku As Label
  Friend WithEvents ProductId As DataGridViewTextBoxColumn
  Friend WithEvents SkuID As DataGridViewTextBoxColumn
  Friend WithEvents DESC As DataGridViewTextBoxColumn
  Friend WithEvents bFilter As Button
End Class
