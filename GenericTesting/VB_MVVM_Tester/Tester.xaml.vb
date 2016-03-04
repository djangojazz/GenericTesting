Class Tester
  Sub New()
    InitializeComponent()
    DataContext = New MainWindowViewModel()
  End Sub

  Protected Overrides Sub OnClosed(e As EventArgs)
    MyBase.OnClosed(e)
    ProducerConsumer.Instance.NotProcessed = False
    Application.Current.Shutdown()
  End Sub
End Class
