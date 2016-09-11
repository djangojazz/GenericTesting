Public Class MainForm
  Private Sub Opener(sender As Object, e As EventArgs) Handles SimpleErrorCheckingToolStripMenuItem.Click, mSimpleDataGrid.Click, mDynamicDataGrid.Click, ListGridToolStripMenuItem.Click, TreeViewToolStripMenuItem.Click, OpenDataGridViewToolStripMenuItem.Click, CheckTwoButtonGenericDialogBoxToolStripMenuItem.Click, CheckGenericDialogBoxToolStripMenuItem.Click, DynamicComboBoxDoubleFillToolStripMenuItem.Click
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
      Case sender Is CheckTwoButtonGenericDialogBoxToolStripMenuItem
        newWindow = New DialogBoxGenericButtons("Parent", "Child")
      Case sender Is CheckGenericDialogBoxToolStripMenuItem
        newWindow = New GenericDialog("Brett Example", New List(Of String)({"A", "B", "C", "D", "E", "F"}))
      Case sender Is DynamicComboBoxDoubleFillToolStripMenuItem
        newWindow = New DynamicComboBoxDoubleFill()
    End Select

    If newWindow IsNot Nothing Then newWindow.Show()
  End Sub

  Private Sub DynamicComboBoxDoubleFillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DynamicComboBoxDoubleFillToolStripMenuItem.Click

  End Sub
End Class
