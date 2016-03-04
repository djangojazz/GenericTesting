Imports System.Collections.Concurrent

Public NotInheritable Class ProducerConsumer

  Private Shared ReadOnly _instance As New Lazy(Of ProducerConsumer)(Function() New ProducerConsumer(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)
  Private Shared _syncRoot = New Object

  Public NotProcessed As Boolean = True
  Public producer As New Threading.Thread(AddressOf ThreadProcessing)
  Public queue As New ConcurrentQueue(Of POCO)

  Public Sub New()
  End Sub

  Public Shared ReadOnly Property Instance() As ProducerConsumer
    Get
      Return _instance.Value
    End Get
  End Property

  Public Shared Property Thing As New POCO

  Private Sub ThreadProcessing()
    Dim ToProcess As New POCO

    Do While (NotProcessed)
      queue.TryDequeue(ToProcess)
      If Not ToProcess Is Nothing Then
        Threading.Thread.Sleep(30I)
      End If

      If queue.Count = 0 And Not IsNothing(ToProcess) Then
        ToProcess.DescAction.Invoke(ToProcess.Desc)
      End If
    Loop
  End Sub

End Class
