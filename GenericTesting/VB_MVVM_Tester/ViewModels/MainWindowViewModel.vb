
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _queueFinished As Boolean = False
  Private _result As String
  'Private _currentPoints As New ObservableCollection(Of Point)
  Private _lastPoints As List(Of PlotPoints)


  Public Sub DoIt(result As String)
    MessageBox.Show(result)
  End Sub

  Sub New()
    TestText = "Line Chart Hello there"
    Points = "0,260 10,250 20,245 40,200 50,250 80, 200, 140,100"

    _lastPoints = New List(Of PlotPoints)({New PlotPoints With {.X = New PlotPoint(Of Double)(700), .Y = New PlotPoint(Of Double)(930)}, New PlotPoints With {.X = New PlotPoint(Of Double)(650), .Y = New PlotPoint(Of Double)(950)}})


    ChartData = New Collection(Of LineTrend)({
                                             New LineTrend With
                                               {
                                               .SeriesName = "First",
                                               .LineColor = Brushes.Blue,
                                               .Points = New List(Of PlotPoints)({
                                                                              New PlotPoints With {.X = New PlotPoint(Of Double)(300), .Y = New PlotPoint(Of Double)(930)},
                                                                              New PlotPoints With {.X = New PlotPoint(Of Double)(650), .Y = New PlotPoint(Of Double)(850)},
                                                                              _lastPoints(0)
                                                                              })
                                              },
                                              New LineTrend With
                                              {
                                              .SeriesName = "Second",
                                               .LineColor = Brushes.Red,
                                               .Points = New List(Of PlotPoints)({
                                                                              New PlotPoints With {.X = New PlotPoint(Of Double)(400), .Y = New PlotPoint(Of Double)(400)},
                                                                              New PlotPoints With {.X = New PlotPoint(Of Double)(500), .Y = New PlotPoint(Of Double)(300)},
                                                                              _lastPoints(0)
                                                                              })
                                              }})
  End Sub

  Private _items As ObservableCollection(Of Stuff)

  Private _points As String
  Public Property Points As String
    Get
      Return _points
    End Get
    Set(ByVal value As String)
      _points = value
      OnPropertyChanged(NameOf(Points))
    End Set
  End Property

  Private _chartData As Collection(Of LineTrend)
  Public Property ChartData As Collection(Of LineTrend)
    Get
      Return _chartData
    End Get
    Set
      _chartData = Value
      OnPropertyChanged(NameOf(ChartData))
    End Set
  End Property

  Private _chartData2 As Collection(Of LineTrend)
  Public Property ChartData2 As Collection(Of LineTrend)
    Get
      Return _chartData2
    End Get
    Set
      _chartData2 = Value
      OnPropertyChanged(NameOf(ChartData2))
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

#Region "Test Command"
  Private _testCommand As New Lazy(Of DelegateCommand(Of Object))(Function() New DelegateCommand(Of Object)(AddressOf TestCommandExecute))

  Public ReadOnly Property TestCommand As ICommand
    Get
      Return _testCommand.Value
    End Get
  End Property

  Private Sub TestCommandExecute()

    Dim newPoints = New List(Of PlotPoints)

    For i = 1 To _lastPoints.Count
      newPoints.Add(New PlotPoints With {.X = New PlotPoint(Of Double)((DirectCast(_lastPoints(i - 1).X, PlotPoint(Of Double)).Point + i) * 10), .Y = New PlotPoint(Of Double)(DirectCast(_lastPoints(i - 1).Y, PlotPoint(Of Double)).Point * 1.95)})
    Next

    _lastPoints = newPoints
    ChartData(0).Points.Add(_lastPoints(0))
    ChartData(1).Points.Add(_lastPoints(1))
    ChartData = New Collection(Of LineTrend)({
    New LineTrend With {.SeriesName = "First", .LineColor = Brushes.Blue, .Points = ChartData(0).Points},
    New LineTrend With {.SeriesName = "Second", .LineColor = Brushes.Red, .Points = ChartData(1).Points}
    })

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
#End Region

End Class
