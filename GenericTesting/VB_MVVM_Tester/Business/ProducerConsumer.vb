Imports System.Collections.Concurrent

Public NotInheritable Class ProducerConsumer
  Private Shared ReadOnly _instance As New Lazy(Of ProducerConsumer)(Function() New ProducerConsumer(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)

  Private Shared _syncRoot = New Object
  Friend producer As New Threading.Thread(AddressOf ThreadProcessing)
  Friend queue As New ConcurrentQueue(Of POCO)

  Public Sub New()
  End Sub

  Public Shared ReadOnly Property Instance() As ProducerConsumer
    Get
      Return _instance.Value
    End Get
  End Property

  Public Property Thing = "Hello"

  Private Sub ThreadProcessing()
    Do While (True)
      Dim ToProcess As POCO = Nothing
      queue.TryDequeue(ToProcess)
      If Not ToProcess Is Nothing Then
        Threading.Thread.Sleep(10I)
      End If
      If queue.Count = 0 And Not IsNothing(ToProcess) Then
        'PROCESS CURRENT VALUE
        MessageBox.Show("Processing a record" & ToProcess.Desc)

      End If
    Loop
  End Sub
End Class
