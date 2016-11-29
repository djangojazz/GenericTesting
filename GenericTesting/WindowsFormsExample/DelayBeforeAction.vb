Imports System.Threading
Imports System.Collections.Concurrent

Public Class DelayBeforeAction

  Delegate Sub SetTextBox(text As String)

  Private _loaded As Boolean = False
  Private WithEvents Producer As New Producer With {.Delay = 1000I}
  Private Shared _sw As Stopwatch = New Stopwatch()

  Public Sub New()
    InitializeComponent()
    _loaded = True
  End Sub

  Private Sub ChangeDelay(sender As Object, e As EventArgs) Handles txtWait.TextChanged
    Producer.Delay = If(Not IsNumeric(txtWait.Text) Or CInt(txtWait.Text) < 1000, 1000, CInt(txtWait.Text))
  End Sub

  Private Sub txtTest_TextChanged(sender As Object, e As EventArgs) Handles txtTest.TextChanged
    If _loaded Then
      'Producer.QueueRequest(txtTest.Text)
      'Dim source As New CancellationTokenSource()
      'Dim token As CancellationToken = source.Token

      _sw.Start()

      DelayExecute(Sub()
                     If _sw.ElapsedMilliseconds > CInt(txtWait.Text) Then
                       _sw.Reset()
                       bw.RunWorkerAsync()
                     Else
                       _sw.Restart()
                       bw.CancelAsync()
                     End If
                   End Sub, CInt(txtWait.Text))
    End If
  End Sub


  Private Sub ShowResult(sender As Object, e As ProducerEventArg) Handles Producer.ProductionComplete
    MessageBox.Show(e.ResultingString)
  End Sub

  Private Async Sub DelayExecute(action As Action, timeout As Integer)
    Await Task.Delay(timeout)
    action()
  End Sub

  Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
    If Not bw.CancellationPending Then MessageBox.Show(txtTest.Text) Else e.Cancel = True
  End Sub
End Class