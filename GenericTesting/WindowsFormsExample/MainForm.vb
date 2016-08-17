Public Class MainForm
  Private Sub Opener(sender As Object, e As EventArgs) Handles OpenDataGridViewToolStripMenuItem.Click, SimpleErrorCheckingToolStripMenuItem.Click, mSimpleDataGrid.Click, mDynamicDataGrid.Click, ListGridToolStripMenuItem.Click, TreeViewToolStripMenuItem.Click
    Dim newWindow = Nothing

    Select Case True
      Case sender Is OpenDataGridViewToolStripMenuItem
        newWindow = New DataGridWindow()
      Case sender Is SimpleErrorCheckingToolStripMenuItem
        newWindow = New ErrorChecking()
      Case sender Is mSimpleDataGrid
        newWindow = New SimpleDataGrid()
      Case sender Is mDynamicDataGrid
        newWindow = New DataGridDynamic()
      Case sender Is ListGridToolStripMenuItem
        newWindow = New ListViewWindow()
      Case sender Is TreeViewToolStripMenuItem
        newWindow = New TreeView()
    End Select

    If newWindow IsNot Nothing Then newWindow.Show()
  End Sub

End Class
