Imports System.Collections.Concurrent
Imports System.ComponentModel

Public Class ProducerConsumerView
  Dim singleton = ProducerConsumer.Instance

  'Public Class POCO
  '  Public Property Id As Integer
  '  Public Property Desc As String
  'End Class

  'Private producer As New Threading.Thread(AddressOf ThreadProcessing)
  'Private queue As New ConcurrentQueue(Of POCO)

  'Private Sub ThreadProcessing()
  '  Do While (True)
  '    Dim ToProcess As POCO = Nothing
  '    queue.TryDequeue(ToProcess)
  '    If Not ToProcess Is Nothing Then
  '      Threading.Thread.Sleep(10I)
  '    End If
  '    If queue.Count = 0 And Not IsNothing(ToProcess) Then
  '      'PROCESS CURRENT VALUE
  '      MessageBox.Show("Processing a record" & ToProcess.Desc)

  '    End If
  '  Loop
  'End Sub

  Private bw As BackgroundWorker = New BackgroundWorker
  Private restartWorker = False

  Public Sub New()
    InitializeComponent()

    singleton.producer.Start()
  End Sub
  Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    For i As Integer = 1 To 50
      singleton.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString})
    Next
  End Sub
End Class
