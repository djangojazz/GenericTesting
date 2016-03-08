Public Class TestCallBack
  Public Sub DoWork(message As String, callback As Action(Of String))
    callback(message)
  End Sub

  Public Sub Examples()
    Dim item As String = String.Empty
    Dim thing = New TestCallBack
    thing.DoWork("hello", Sub(x) Console.WriteLine($"{x}"))
    thing.DoWork("hey", Sub(x) item = x)
    Console.WriteLine($"{item}")
  End Sub
End Class
