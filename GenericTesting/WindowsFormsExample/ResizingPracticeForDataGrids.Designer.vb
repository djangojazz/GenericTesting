<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResizingPracticeForDataGrids
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
    Me.dgv1 = New System.Windows.Forms.DataGridView()
    Me.ds = New System.Data.DataSet()
    Me.Main = New System.Data.DataTable()
    Me.DataColumn1 = New System.Data.DataColumn()
    Me.DataColumn2 = New System.Data.DataColumn()
    Me.dgv2 = New System.Windows.Forms.DataGridView()
    Me.dgv3 = New System.Windows.Forms.DataGridView()
    Me.dgv4 = New System.Windows.Forms.DataGridView()
    Me.splitter = New System.Windows.Forms.SplitContainer()
    CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Main, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgv4, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.splitter, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.splitter.Panel1.SuspendLayout()
    Me.splitter.Panel2.SuspendLayout()
    Me.splitter.SuspendLayout()
    Me.SuspendLayout()
    '
    'dgv1
    '
    Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv1.Location = New System.Drawing.Point(24, 33)
    Me.dgv1.Name = "dgv1"
    Me.dgv1.Size = New System.Drawing.Size(327, 100)
    Me.dgv1.TabIndex = 0
    '
    'ds
    '
    Me.ds.DataSetName = "NewDataSet"
    Me.ds.Tables.AddRange(New System.Data.DataTable() {Me.Main})
    '
    'Main
    '
    Me.Main.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2})
    Me.Main.TableName = "Main"
    '
    'DataColumn1
    '
    Me.DataColumn1.ColumnName = "Id"
    Me.DataColumn1.DataType = GetType(Integer)
    '
    'DataColumn2
    '
    Me.DataColumn2.ColumnName = "Desc"
    '
    'dgv2
    '
    Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv2.Location = New System.Drawing.Point(24, 151)
    Me.dgv2.Name = "dgv2"
    Me.dgv2.Size = New System.Drawing.Size(327, 100)
    Me.dgv2.TabIndex = 1
    '
    'dgv3
    '
    Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgv3.Location = New System.Drawing.Point(0, 0)
    Me.dgv3.Name = "dgv3"
    Me.dgv3.Size = New System.Drawing.Size(327, 140)
    Me.dgv3.TabIndex = 2
    '
    'dgv4
    '
    Me.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgv4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgv4.Location = New System.Drawing.Point(0, 0)
    Me.dgv4.Name = "dgv4"
    Me.dgv4.Size = New System.Drawing.Size(327, 138)
    Me.dgv4.TabIndex = 3
    '
    'splitter
    '
    Me.splitter.Location = New System.Drawing.Point(24, 286)
    Me.splitter.Name = "splitter"
    Me.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'splitter.Panel1
    '
    Me.splitter.Panel1.Controls.Add(Me.dgv3)
    '
    'splitter.Panel2
    '
    Me.splitter.Panel2.Controls.Add(Me.dgv4)
    Me.splitter.Size = New System.Drawing.Size(327, 282)
    Me.splitter.SplitterDistance = 140
    Me.splitter.TabIndex = 4
    '
    'ResizingPracticeForDataGrids
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(698, 624)
    Me.Controls.Add(Me.splitter)
    Me.Controls.Add(Me.dgv2)
    Me.Controls.Add(Me.dgv1)
    Me.Name = "ResizingPracticeForDataGrids"
    Me.Text = "ResizingPracticeForDataGrids"
    CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Main, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgv4, System.ComponentModel.ISupportInitialize).EndInit()
    Me.splitter.Panel1.ResumeLayout(False)
    Me.splitter.Panel2.ResumeLayout(False)
    CType(Me.splitter, System.ComponentModel.ISupportInitialize).EndInit()
    Me.splitter.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents dgv1 As DataGridView
  Friend WithEvents ds As DataSet
  Friend WithEvents Main As DataTable
  Friend WithEvents DataColumn1 As DataColumn
  Friend WithEvents DataColumn2 As DataColumn
  Friend WithEvents dgv2 As DataGridView
  Friend WithEvents dgv3 As DataGridView
  Friend WithEvents dgv4 As DataGridView
  Friend WithEvents splitter As SplitContainer
End Class
