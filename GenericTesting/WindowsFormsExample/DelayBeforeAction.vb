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
  End Sub

  Private Sub ChangeDelay(sender As Object, e As EventArgs) Handles txtWait.TextChanged
    _producer.Delay = If(Not IsNumeric(txtWait.Text) Or CInt(txtWait.Text) < 1000, 1000, CInt(txtWait.Text))
  End Sub

  Private Sub txtTest_TextChanged(sender As Object, e As EventArgs) Handles txtTest.TextChanged
    If _loaded Then
      _producer.QueueRequest(txtTest.Text)
    End If
  End Sub


  Private Sub ShowResult(sender As Object, e As ProducerEventArg) Handles _producer.ProductionComplete
    Dim s = e.ResultingString
    txtOut.Text = s
  End Sub


End Class