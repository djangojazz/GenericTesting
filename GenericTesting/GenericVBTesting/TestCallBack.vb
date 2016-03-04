Public Class TestCallBack
  Public Sub DoWork(message As String, callback As Action(Of String))
    callback(message)
  End Sub
End Class
