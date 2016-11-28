Public Class BackGroundWorkerAsync

  Delegate Sub SetListItem(ByVal lstItem As ListViewItem) 'Your delegate..

  'Start the process...
  Private Sub btnStartProcess_Click(sender As Object, e As EventArgs) Handles btnStartProcess.Click
    lvItems.Clear()
    bwList.RunWorkerAsync()
  End Sub

  'Private Sub AddListItem(lstItem As ListViewItem)
  '  If Me.lvItems.InvokeRequired Then 'Invoke if required...
  '    Dim d As New SetListItem(AddressOf AddListItem) 'Your delegate...
  '    Me.Invoke(d, New Object() {lstItem})
  '  Else 'Otherwise, no invoke required...
  '    Me.lvItems.Items.Add(lstItem)
  '  End If
  'End Sub

  Private Sub bwList_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwList.DoWork
    Dim intComplete As Integer = 0

    For i As Integer = 1 To CInt(txtCount.Text)
      If Not (bwList.CancellationPending) Then
        Dim li = New ListViewItem
        li.Text = "Item " & i.ToString
        'AddListItem(li)
        Me.lvItems.Items.Add(li)
        Threading.Thread.Sleep(1) 'Give the thread a very..very short break...
      ElseIf (bwList.CancellationPending) Then
        e.Cancel = True
        Exit For
      End If

      intComplete = CInt(CDec(i / CInt(txtCount.Text)) * 100)
      If intComplete < 100 Then
        bwList.ReportProgress(intComplete)
      End If

      'If li IsNot Nothing Then
      '  li = Nothing
      'End If
    Next

  End Sub

  Private Sub bwList_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwList.ProgressChanged
    pbList.Value = e.ProgressPercentage
  End Sub

  Private Sub bwList_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwList.RunWorkerCompleted
    If pbList.Value < 100 Then pbList.Value = 100
    MessageBox.Show(lvItems.Items.Count.ToString & " items were added!")
  End Sub

  Private Sub btnStopWork_Click(sender As Object, e As EventArgs) Handles btnStopWork.Click
    bwList.CancelAsync()
  End Sub

  Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
    pbList.Value = 0
    lvItems.Items.Clear()
    txtCount.Text = String.Empty
  End Sub
End Class