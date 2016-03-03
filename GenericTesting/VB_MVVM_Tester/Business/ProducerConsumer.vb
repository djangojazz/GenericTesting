Imports System.Collections.Concurrent

Public NotInheritable Class ProducerConsumer
  Private Shared ReadOnly _instance As New Lazy(Of ProducerConsumer)(Function() New ProducerConsumer(), Threading.LazyThreadSafetyMode.ExecutionAndPublication)
  Private Shared _syncRoot = New Object
  Private NotProcessed As Boolean = True
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
    Do While (NotProcessed)
      Dim ToProcess As POCO = Nothing
      queue.TryDequeue(ToProcess)
      If Not ToProcess Is Nothing Then
        Threading.Thread.Sleep(10I)
      End If

      If queue.Count = 0 And Not IsNothing(ToProcess) Then
        MessageBox.Show(ToProcess.Id.ToString())
        Thing = ToProcess
        NotProcessed = False
      End If
    Loop


  End Sub
End Class
