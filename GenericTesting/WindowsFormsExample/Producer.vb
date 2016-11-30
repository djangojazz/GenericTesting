Imports System.Threading
Imports System.Windows.Threading

Public Class Producer
  Implements IDisposable

  Public Property Delay As Integer = 1000I
  Private CloseControl As Boolean
  Public Event ProductionComplete(sender As Object, e As ProducerEventArg)
  Public EvokeThread As Thread
  Private _workingString As String = String.Empty
  Private _stringLock As New Object
  Private RequestNumber As Int64
  Private _invokeThread As Dispatcher

  Public Sub New()
    _invokeThread = Dispatcher.CurrentDispatcher
    EvokeThread = New Thread(AddressOf BackgroundOperation)
    EvokeThread.Start()
  End Sub

  Public Sub QueueRequest(text As String)
    SyncLock _stringLock
      _workingString = text
    End SyncLock
  End Sub

  Private Sub BackgroundOperation()
    Do While CloseControl = False
      Dim returnString As String = _workingString

      Thread.Sleep(Delay)

      Dim previousString As String = _workingString

      If Not String.IsNullOrEmpty(returnString) AndAlso returnString = previousString Then
        _invokeThread.Invoke(Sub() RaiseEvent ProductionComplete(Me, New ProducerEventArg(returnString)))
        SyncLock _stringLock
          _workingString = String.Empty
        End SyncLock
      End If
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
        _workingString = Nothing
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