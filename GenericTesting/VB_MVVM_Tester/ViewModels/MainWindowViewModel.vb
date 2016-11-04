
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _queueFinished As Boolean = False
  Private _result As String
  Private _currentPoints As New ObservableCollection(Of Point)
  Private _lastPoint As Point
  Private _lineTrend As New LineGraph()



  Public Sub DoIt(result As String)
    MessageBox.Show(result)
  End Sub

  Sub New()
    ProducerConsumer.Instance.producer.Start()
    Items = New ObservableCollection(Of Stuff)(New List(Of Stuff)({New Stuff With {.Id = 1, .Value = "Stuff", .ShipType = ShipType.Owned, .MoreStuff = "More Stuff"}, New Stuff With {.Id = 2, .Value = "Another"}}))

    TestText = "Line Chart"
    Points = "0,260 10,250 20,245 40,200 50,250 80, 200, 140,100"

    _currentPoints = New ObservableCollection(Of Point)({New Point With {.X = 1, .Y = 1}, New Point With {.X = 50, .Y = 20}, New Point With {.X = 100, .Y = 100}})
    _lastPoint = New Point With {.X = 150, .Y = 130}
    _currentPoints.Add(_lastPoint)

    _lineTrend.Trends.Add(New ChartDataSegment With {.LineColor = Brushes.Blue, .Points = _currentPoints})
  End Sub

  Private _items As ObservableCollection(Of Stuff)

  Private _points As String
  Public Property Points() As String
    Get
      Return _points
    End Get
    Set(ByVal value As String)
      _points = value
      OnPropertyChanged(NameOf(Points))
    End Set
  End Property

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

  Private _testCommand As New Lazy(Of DelegateCommand(Of Object))(Function() New DelegateCommand(Of Object)(AddressOf TestCommandExecute))

  Public ReadOnly Property TestCommand As ICommand
    Get
      Return _testCommand.Value
    End Get
  End Property

  Private Sub TestCommandExecute()
    MessageBox.Show("Testing")
    _lastPoint = New Point With {.X = 250, .Y = 130}
    _currentPoints.Add(_lastPoint)
    _lineTrend.Trends.Add(New ChartDataSegment With {.LineColor = Brushes.Blue, .Points = _currentPoints})
    _lineTrend.DrawTrend()
  End Sub

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
