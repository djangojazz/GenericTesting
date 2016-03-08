Public Class TestUsingClass
  Implements IDisposable

  Private _input As String

  Public Sub New()
  End Sub

  Public Sub New(input As String)
    _input = input
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        Console.WriteLine("I was disposed automatically")
      End If
    End If
    disposedValue = True
  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose
    Dispose(True)
  End Sub
#End Region
End Class
