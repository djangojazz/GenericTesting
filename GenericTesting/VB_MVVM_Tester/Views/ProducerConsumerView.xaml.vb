Imports System.Collections.Concurrent
Imports System.ComponentModel

Public Class ProducerConsumerView

  Public Sub New()
    InitializeComponent()

  End Sub

  Private Sub UserControl_MouseMove(sender As Object, e As MouseEventArgs)
    Dim pos = Mouse.GetPosition(Application.Current.MainWindow)

    Dim dc = DirectCast(DataContext, MainWindowViewModel)
    dc.MouseMove = $"{pos.X} {pos.Y}"
  End Sub

End Class
