<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComboBoxTesting
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
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.dgv = New System.Windows.Forms.DataGridView()
    Me.cmbTest = New System.Windows.Forms.ComboBox()
    Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.cmb = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.cmb2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dgv
    '
    Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cmb, Me.cmb2})
    Me.dgv.Location = New System.Drawing.Point(12, 12)
    Me.dgv.Name = "dgv"
    Me.dgv.Size = New System.Drawing.Size(324, 150)
    Me.dgv.TabIndex = 1
    '
    'cmbTest
    '
    Me.cmbTest.BackColor = System.Drawing.Color.White
    Me.cmbTest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.cmbTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbTest.ForeColor = System.Drawing.Color.Black
    Me.cmbTest.FormattingEnabled = True
    Me.cmbTest.Location = New System.Drawing.Point(22, 184)
    Me.cmbTest.Name = "cmbTest"
    Me.cmbTest.Size = New System.Drawing.Size(121, 21)
    Me.cmbTest.TabIndex = 2
    '
    'DataGridViewComboBoxColumn1
    '
    Me.DataGridViewComboBoxColumn1.DataPropertyName = "cmb"
    DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
    Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.DataGridViewComboBoxColumn1.HeaderText = "ComboBox"
    Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"A", "B", "C"})
    Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
    Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'DataGridViewComboBoxColumn2
    '
    Me.DataGridViewComboBoxColumn2.DataPropertyName = "cmb2"
    DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DataGridViewComboBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
    Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.DataGridViewComboBoxColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.DataGridViewComboBoxColumn2.HeaderText = "ComboBox2"
    Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
    Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'cmb
    '
    Me.cmb.DataPropertyName = "cmb"
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.cmb.DefaultCellStyle = DataGridViewCellStyle1
    Me.cmb.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.cmb.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmb.HeaderText = "ComboBox"
    Me.cmb.Items.AddRange(New Object() {"A", "B", "C"})
    Me.cmb.Name = "cmb"
    Me.cmb.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.cmb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'cmb2
    '
    Me.cmb2.DataPropertyName = "cmb2"
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.cmb2.DefaultCellStyle = DataGridViewCellStyle2
    Me.cmb2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
    Me.cmb2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmb2.HeaderText = "ComboBox2"
    Me.cmb2.Name = "cmb2"
    Me.cmb2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.cmb2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    '
    'ComboBoxTesting
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(616, 261)
    Me.Controls.Add(Me.cmbTest)
    Me.Controls.Add(Me.dgv)
    Me.Name = "ComboBoxTesting"
    Me.Text = "ComboBoxTesting"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents dgv As DataGridView
  Friend WithEvents cmb As DataGridViewComboBoxColumn
  Friend WithEvents cmb2 As DataGridViewComboBoxColumn
    Friend WithEvents cmbTest As ComboBox
  Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
  Friend WithEvents DataGridViewComboBoxColumn2 As DataGridViewComboBoxColumn
End Class
