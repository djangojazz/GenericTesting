
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _queueFinished As Boolean = False
  Private _result As String



  Public Sub DoIt(result As String)
    MessageBox.Show(result)
  End Sub

  Sub New()
    ProducerConsumer.Instance.producer.Start()
    Items = New ObservableCollection(Of Stuff)(New List(Of Stuff)({New Stuff With {.Id = 1, .Value = "Stuff", .ShipType = ShipType.Owned, .MoreStuff = "More Stuff"}, New Stuff With {.Id = 2, .Value = "Another"}}))

  End Sub

  Private _items As ObservableCollection(Of Stuff)

  Public Property Items() As ObservableCollection(Of Stuff)
    Get
      Return _items
    End Get
    Set(ByVal value As ObservableCollection(Of Stuff))
      _items = value
      OnPropertyChanged(NameOf(Items))
    End Set
  End Property

  Private _testText As String
  Public Property TestText As String
    Get
      Return _testText
    End Get
    Set
      _testText = Value
      OnPropertyChanged(NameOf(TestText))
    End Set
  End Property

  Private _mouseMove As String
  Public Property MouseMove As String
    Get
      Return _mouseMove
    End Get
    Set
      _mouseMove = Value

      'Dim result As String = String.Empty
      'Dim result2 As String
      'Dim action As Action(Of String) = Nothing
      'ProducerConsumerFinished = Nothing
      Dim poc = New POCO With {.Desc = Value, .DescAction = Function(x) x}

      ProducerConsumer.Instance.queue.Enqueue(poc)

      poc.DescAction = Sub(x) TestText = x

      'If Not action Is Nothing Then
      '  TestText = act
      'End If

      'Dim result As New POCO
      'ProducerConsumer.Instance.queue.TryPeek(result)

      'If Not result Is Nothing Then
      '  TestText = $"{ProducerConsumer.Instance.queue.Count} {result.Desc}"
      'End If

      'TestText = ProducerConsumer.Instance.Thing.Desc

      '_queueFinished = ProducerConsumer.Instance.queue.Count = 0
      'If _queueFinished Then
      '  TestText = $"Done {DateTime.Now.ToString()}"
      'End If

      OnPropertyChanged(NameOf(MouseMove))
    End Set
  End Property

  Private _startCommandProdCons As New Lazy(Of DelegateCommand(Of Object))(Function() New DelegateCommand(Of Object)(AddressOf StartCommandProdConsExecute))

  Public ReadOnly Property StartCommandProdCons As ICommand
    Get
      Return _startCommandProdCons.Value
    End Get
  End Property

  Private Sub StartCommandProdConsExecute()
    TestText = "Start"

    For i As Integer = 1 To 10
      'Dim singleton = ProducerConsumer.Instance
      ProducerConsumer.Instance.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString()})
    Next

    Dim value = ProducerConsumer.Instance.Thing.Id
    TestText = $"{value}"
  End Sub

End Class
