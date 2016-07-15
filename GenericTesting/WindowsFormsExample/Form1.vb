Public Class Form1
  Private Sub OpenDataGridViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDataGridViewToolStripMenuItem.Click
    Dim newWindow = New DataGridWindow()
    newWindow.Show()
  End Sub

  Private Sub SimpleDataGridViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SimpleDataGridViewToolStripMenuItem1.Click
    Dim newWindow = New SimpleDataGrid()
    newWindow.Show()
  End Sub

  Private Sub SimpleErrorCheckingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpleErrorCheckingToolStripMenuItem.Click
    Dim newWindow = New ErrorChecking()
    newWindow.Show()
  End Sub
End Class
