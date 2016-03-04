
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String

  Sub New()
    TestText = "Hello"
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
      ProducerConsumer.Instance.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString})
    Next

    Dim value = ProducerConsumer.Instance.Thing.Id
    TestText = $"{value}"
  End Sub

End Class
