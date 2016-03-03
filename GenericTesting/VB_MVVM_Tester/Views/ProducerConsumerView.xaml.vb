Imports System.Collections.Concurrent
Imports System.ComponentModel

Public Class ProducerConsumerView
  Dim singleton = ProducerConsumer.Instance

  Public Sub New()
    InitializeComponent()
    'Dim singleton = ProducerConsumer.Instance
    singleton.producer.Start()
  End Sub
  Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    tbProgress.Text = "Start"

    For i As Integer = 1 To 10
      'Dim singleton = ProducerConsumer.Instance
      singleton.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString})
      Me.tbProgress.Text = $"{singleton.Thing.Id}"
    Next

    'Threading.Thread.Sleep(800)

    For x As Integer = 11 To 20
      singleton.queue.Enqueue(New POCO With {.Id = x, .Desc = x.ToString})
      Me.tbProgress.Text = $"{singleton.Thing.Id}"
    Next

  End Sub
End Class
