Public Class MainForm
  Private Sub OpenDataGridViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDataGridViewToolStripMenuItem.Click
    Dim newWindow = New DataGridWindow()
    newWindow.Show()
  End Sub

  Private Sub SimpleErrorCheckingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpleErrorCheckingToolStripMenuItem.Click
    Dim newWindow = New ErrorChecking()
    newWindow.Show()
  End Sub

  Private Sub SimpleDataGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mSimpleDataGrid.Click
    Dim newWindow = New SimpleDataGrid()
    newWindow.Show()
  End Sub

  Private Sub mDynamicDataGrid_Click(sender As Object, e As EventArgs) Handles mDynamicDataGrid.Click
    Dim newWindow = New DataGridDynamic()
    newWindow.Show()
  End Sub
End Class
