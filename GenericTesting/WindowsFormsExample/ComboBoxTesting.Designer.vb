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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.dgv = New System.Windows.Forms.DataGridView()
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
    Me.ClientSize = New System.Drawing.Size(374, 261)
    Me.Controls.Add(Me.dgv)
    Me.Name = "ComboBoxTesting"
    Me.Text = "ComboBoxTesting"
    CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents advCombo As AdvancedComboBox
  Friend WithEvents dgv As DataGridView
  Friend WithEvents cmb As DataGridViewComboBoxColumn
  Friend WithEvents cmb2 As DataGridViewComboBoxColumn
End Class
