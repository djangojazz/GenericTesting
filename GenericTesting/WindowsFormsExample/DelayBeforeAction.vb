Imports System.Threading
Imports System.Collections.Concurrent

Public Class DelayBeforeAction

  Delegate Sub SetTextBox(text As String)

  Private _loaded As Boolean = False
  Private WithEvents _producer As New Producer With {.Delay = 1000I}
  Private Shared _sw As Stopwatch = New Stopwatch()

  Public Sub New()
    InitializeComponent()
    _loaded = True
    timer.Interval = 1000
  End Sub

  Private Sub ChangeDelay(sender As Object, e As EventArgs) Handles txtWait.TextChanged
    _producer.Delay = If(Not IsNumeric(txtWait.Text) Or CInt(txtWait.Text) < 1000, 1000, CInt(txtWait.Text))
  End Sub



  Private Sub txtTest_TextChanged(sender As Object, e As EventArgs) Handles txtTest.TextChanged
    If _loaded Then
      timer.Stop()
      timer.Start()
      '_producer.QueueRequest(txtTest.Text)
      '_sw.Start()

      'Dim source As New CancellationTokenSource()
      'Dim token As CancellationToken = source.Token

      'DelayExecute(Sub() If _sw.ElapsedMilliseconds > CInt(txtWait.Text) Then _sw.Reset() : MessageBox.Show(txtTest.Text) Else _sw.Restart(), CInt(txtWait.Text), token)
    End If
  End Sub


  Private Sub ShowResult(sender As Object, e As ProducerEventArg) Handles _producer.ProductionComplete
    MessageBox.Show(e.ResultingString)
  End Sub

  Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
    timer.Stop()
    MessageBox.Show(txtTest.Text)

  End Sub

  Private Async Sub DelayExecute(action As Action, timeout As Integer, token As CancellationToken)
    Await Task.Delay(timeout, token)
    action()
  End Sub
End Class