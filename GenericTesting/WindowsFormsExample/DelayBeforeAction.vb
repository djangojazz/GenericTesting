Public Class DelayBeforeAction

  Private Sub MyButton_Click() Handles bDelayTest.Click
    Me.DisableButtonAsync()
  End Sub

  Private Sub PerformWork()
    MessageBox.Show("Ready!")
  End Sub

  Private Async Sub DisableButtonAsync()
    Me.bDelayTest.Enabled = False

    Await Task.Delay(CInt(txtEntry.Text))
    Me.PerformWork()
    Me.bDelayTest.Enabled = True
  End Sub
End Class