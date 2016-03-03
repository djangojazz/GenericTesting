Imports System.Collections.Concurrent
Imports System.ComponentModel

Public Class ProducerConsumerView

  Public Sub New()
    InitializeComponent()
    Dim singleton = ProducerConsumer.Instance
    singleton.producer.Start()
  End Sub
  Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    For i As Integer = 1 To 50
      Dim singleton = ProducerConsumer.Instance
      singleton.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString})
    Next
  End Sub
End Class
