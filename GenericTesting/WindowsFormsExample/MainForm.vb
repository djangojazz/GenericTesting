Public Class MainForm
  Private Sub Opener(sender As Object, e As EventArgs) Handles SimpleErrorCheckingToolStripMenuItem.Click, mSimpleDataGrid.Click, mDynamicDataGrid.Click, ListGridToolStripMenuItem.Click, TreeViewToolStripMenuItem.Click, OpenDataGridViewToolStripMenuItem.Click, CheckTwoButtonGenericDialogBoxToolStripMenuItem.Click, CheckGenericDialogBoxToolStripMenuItem.Click, DynamicComboBoxDoubleFillToolStripMenuItem.Click, mnuDynamicComboBoxDoubleFillSO.Click, dgvComboBoxTest.Click, ResizingExamplesToolStripMenuItem.Click, mnuAsyncListViewBW.Click
    Dim newWindow = New Form()

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
      Case sender Is CheckGenericDialogBoxToolStripMenuItem
        newWindow = New Form()
        Dim btn As Button = Nothing
        'New GenericDialog("Brett Example", New List(Of String)({"A", "B", "C", "D", "E", "F"}))
        Dim array = New List(Of String)({"A", "B", "C", "D", "E", "F"})

        Dim locationVert = 20
        array.ForEach(Sub(x)
                        Dim b = New Button()
                        b.Name = x
                        b.Text = x
                        b.Width = 200
                        b.Height = 30
                        newWindow.Controls.Add(b)
                        b.Location = New Point(20, locationVert)

                        locationVert += 40
                      End Sub)


        For Each ctrl As Control In newWindow.Controls
          If TypeOf ctrl Is Button Then
            btn = DirectCast(ctrl, Button)
            AddHandler btn.Click, Sub(senderO, args) MessageBox.Show($"You clicked: {CType(senderO, Button).Text}")
          End If
        Next
      Case sender Is DynamicComboBoxDoubleFillToolStripMenuItem
        newWindow = New DynamicFilterOnTwoTextItems()
      Case sender Is mnuDynamicComboBoxDoubleFillSO
        newWindow = New DynamicComboBoxDoubleFillSO()
      Case sender Is dgvComboBoxTest
        newWindow = New ComboBoxTesting()
      Case sender Is ResizingExamplesToolStripMenuItem
        newWindow = New ResizingPracticeForDataGrids()
      Case sender Is mnuAsyncListViewBW
        newWindow = New BackGroundWorkerAsync()
    End Select

    If newWindow IsNot Nothing Then newWindow.Show()
  End Sub

End Class
