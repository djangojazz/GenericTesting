Imports System.Collections.Concurrent
Imports System.Threading

Public Class Producer
  Implements IDisposable

  Public Property Delay As Integer = 1000I
  Private CloseControl As Boolean
  Public Event ProductionComplete(sender As Object, e As ProducerEventArg)
  Public EvokeThread As Thread
  Private _concurrentDictionary As New ConcurrentDictionary(Of Decimal, String)
  Private RequestNumber As Int64

  Public Sub New()
    EvokeThread = New Thread(AddressOf BackgroundOperation)
    EvokeThread.Start()
  End Sub

  Public Sub QueueRequest(text As String)
    RequestNumber += 1
    _concurrentDictionary.TryAdd(RequestNumber, text)
  End Sub

  Private Sub BackgroundOperation()
    Do While CloseControl = False
      Do While Not _concurrentDictionary.Any
      Loop

      Thread.Sleep(Delay)

      Dim ReturnString As String = String.Empty
      If _concurrentDictionary.Any Then
        Dim LastPoint = _concurrentDictionary.First.Key
        _concurrentDictionary.TryGetValue(LastPoint, ReturnString)
        For Each o In _concurrentDictionary
          If o.Key <= LastPoint Then _concurrentDictionary.TryRemove(o.Key, Nothing)
        Next
      End If
      If Not String.IsNullOrEmpty(ReturnString) Then RaiseEvent ProductionComplete(Me, New ProducerEventArg(ReturnString))

    Loop
  End Sub

  Public Sub close()
    CloseControl = True
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        CloseControl = True
        _concurrentDictionary = Nothing
      End If
    End If
    disposedValue = True
  End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
  End Sub
#End Region

End Class

Public Class ProducerEventArg
  Inherits EventArgs

  Public Sub New(ReturnString As String)
    Me.ResultingString = ReturnString
  End Sub

  Public Property ResultingString As String
End Class