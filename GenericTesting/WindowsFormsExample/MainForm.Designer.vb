<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.mDataGrids = New System.Windows.Forms.ToolStripMenuItem()
    Me.OpenDataGridViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mSimpleDataGrid = New System.Windows.Forms.ToolStripMenuItem()
    Me.mDynamicDataGrid = New System.Windows.Forms.ToolStripMenuItem()
    Me.ListGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.TreeViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DynamicComboBoxDoubleFillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuDynamicComboBoxDoubleFillSO = New System.Windows.Forms.ToolStripMenuItem()
    Me.dgvComboBoxTest = New System.Windows.Forms.ToolStripMenuItem()
    Me.ResizingExamplesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SimpleErrorCheckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.checkdialogs = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckGenericDialogBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckTwoButtonGenericDialogBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AsyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAsyncListViewBW = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mDataGrids, Me.SimpleErrorCheckingToolStripMenuItem, Me.checkdialogs, Me.AsyncToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(658, 24)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'mDataGrids
    '
    Me.mDataGrids.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDataGridViewToolStripMenuItem, Me.mSimpleDataGrid, Me.mDynamicDataGrid, Me.ListGridToolStripMenuItem, Me.TreeViewToolStripMenuItem, Me.DynamicComboBoxDoubleFillToolStripMenuItem, Me.mnuDynamicComboBoxDoubleFillSO, Me.dgvComboBoxTest, Me.ResizingExamplesToolStripMenuItem})
    Me.mDataGrids.Name = "mDataGrids"
    Me.mDataGrids.Size = New System.Drawing.Size(70, 20)
    Me.mDataGrids.Text = "DataGrids"
    '
    'OpenDataGridViewToolStripMenuItem
    '
    Me.OpenDataGridViewToolStripMenuItem.Name = "OpenDataGridViewToolStripMenuItem"
    Me.OpenDataGridViewToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
    Me.OpenDataGridViewToolStripMenuItem.Text = "OpenDataGridView"
    '
    'mSimpleDataGrid
    '
    Me.mSimpleDataGrid.Name = "mSimpleDataGrid"
    Me.mSimpleDataGrid.Size = New System.Drawing.Size(248, 22)
    Me.mSimpleDataGrid.Text = "SimpleDataGrid"
    '
    'mDynamicDataGrid
    '
    Me.mDynamicDataGrid.Name = "mDynamicDataGrid"
    Me.mDynamicDataGrid.Size = New System.Drawing.Size(248, 22)
    Me.mDynamicDataGrid.Text = "DynamicDataGrid"
    '
    'ListGridToolStripMenuItem
    '
    Me.ListGridToolStripMenuItem.Name = "ListGridToolStripMenuItem"
    Me.ListGridToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
    Me.ListGridToolStripMenuItem.Text = "ListGrid"
    '
    'TreeViewToolStripMenuItem
    '
    Me.TreeViewToolStripMenuItem.Name = "TreeViewToolStripMenuItem"
    Me.TreeViewToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
    Me.TreeViewToolStripMenuItem.Text = "TreeView"
    '
    'DynamicComboBoxDoubleFillToolStripMenuItem
    '
    Me.DynamicComboBoxDoubleFillToolStripMenuItem.Name = "DynamicComboBoxDoubleFillToolStripMenuItem"
    Me.DynamicComboBoxDoubleFillToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
    Me.DynamicComboBoxDoubleFillToolStripMenuItem.Text = "DynamicFilterOnTwoCritera"
    '
    'mnuDynamicComboBoxDoubleFillSO
    '
    Me.mnuDynamicComboBoxDoubleFillSO.Name = "mnuDynamicComboBoxDoubleFillSO"
    Me.mnuDynamicComboBoxDoubleFillSO.Size = New System.Drawing.Size(248, 22)
    Me.mnuDynamicComboBoxDoubleFillSO.Text = "DynamicComboBoxDoubleFillSO"
    '
    'dgvComboBoxTest
    '
    Me.dgvComboBoxTest.Name = "dgvComboBoxTest"
    Me.dgvComboBoxTest.Size = New System.Drawing.Size(248, 22)
    Me.dgvComboBoxTest.Text = "ComboBox In DataGrid View"
    '
    'ResizingExamplesToolStripMenuItem
    '
    Me.ResizingExamplesToolStripMenuItem.Name = "ResizingExamplesToolStripMenuItem"
    Me.ResizingExamplesToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
    Me.ResizingExamplesToolStripMenuItem.Text = "Resizing Examples"
    '
    'SimpleErrorCheckingToolStripMenuItem
    '
    Me.SimpleErrorCheckingToolStripMenuItem.Name = "SimpleErrorCheckingToolStripMenuItem"
    Me.SimpleErrorCheckingToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
    Me.SimpleErrorCheckingToolStripMenuItem.Text = "SimpleErrorChecking"
    '
    'checkdialogs
    '
    Me.checkdialogs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckGenericDialogBoxToolStripMenuItem, Me.CheckTwoButtonGenericDialogBoxToolStripMenuItem})
    Me.checkdialogs.Name = "checkdialogs"
    Me.checkdialogs.Size = New System.Drawing.Size(94, 20)
    Me.checkdialogs.Text = "Check Dialogs"
    '
    'CheckGenericDialogBoxToolStripMenuItem
    '
    Me.CheckGenericDialogBoxToolStripMenuItem.Name = "CheckGenericDialogBoxToolStripMenuItem"
    Me.CheckGenericDialogBoxToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
    Me.CheckGenericDialogBoxToolStripMenuItem.Text = "Check Generic Dialog Box"
    '
    'CheckTwoButtonGenericDialogBoxToolStripMenuItem
    '
    Me.CheckTwoButtonGenericDialogBoxToolStripMenuItem.Name = "CheckTwoButtonGenericDialogBoxToolStripMenuItem"
    Me.CheckTwoButtonGenericDialogBoxToolStripMenuItem.Size = New System.Drawing.Size(273, 22)
    Me.CheckTwoButtonGenericDialogBoxToolStripMenuItem.Text = "Check Two Button Generic Dialog Box"
    '
    'AsyncToolStripMenuItem
    '
    Me.AsyncToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAsyncListViewBW})
    Me.AsyncToolStripMenuItem.Name = "AsyncToolStripMenuItem"
    Me.AsyncToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
    Me.AsyncToolStripMenuItem.Text = "Async"
    '
    'mnuAsyncListViewBW
    '
    Me.mnuAsyncListViewBW.Name = "mnuAsyncListViewBW"
    Me.mnuAsyncListViewBW.Size = New System.Drawing.Size(184, 22)
    Me.mnuAsyncListViewBW.Text = "ListView Background"
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(658, 394)
    Me.Controls.Add(Me.MenuStrip1)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "MainForm"
    Me.Text = "Form1"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents mDataGrids As ToolStripMenuItem
  Friend WithEvents SimpleErrorCheckingToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents mSimpleDataGrid As ToolStripMenuItem
  Friend WithEvents mDynamicDataGrid As ToolStripMenuItem
  Friend WithEvents ListGridToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents TreeViewToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents OpenDataGridViewToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents checkdialogs As ToolStripMenuItem
  Friend WithEvents CheckGenericDialogBoxToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CheckTwoButtonGenericDialogBoxToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents DynamicComboBoxDoubleFillToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents mnuDynamicComboBoxDoubleFillSO As ToolStripMenuItem
  Friend WithEvents dgvComboBoxTest As ToolStripMenuItem
  Friend WithEvents ResizingExamplesToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents AsyncToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents mnuAsyncListViewBW As ToolStripMenuItem
End Class
