Imports System.Collections.ObjectModel

Public Class LineChart


  Friend _canvasPoints As Canvas = Nothing
  Private _canvasXAxisTicks As Canvas = Nothing
  Private _canvasXAxisLabels As Canvas = Nothing
  Private _canvasYAxisTicks As Canvas = Nothing
  Private _canvasYAxisLabels As Canvas = Nothing
  Private _legendText As TextBlock = Nothing
  Private _numberOfTicks As Integer = 0
  Private _xValueConverter As IValueConverter = Nothing
  Friend _xFloor As Decimal = 0
  Friend _xCeiling As Decimal = 0
  Private _yFloor As Decimal = 0
  Private _yCeiling As Decimal = 0

  Public Sub New()
    InitializeComponent()

    _canvasPoints = PART_CanvasPoints
    _canvasXAxisTicks = PART_CanvasXAxisTicks
    _canvasXAxisLabels = PART_CanvasXAxisLabels
    _canvasYAxisTicks = PART_CanvasYAxisTicks
    _canvasYAxisLabels = PART_CanvasYAxisLabels
    _legendText = PART_LEGENDTEXT
  End Sub

#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(Collection(Of LineTrend)), GetType(LineChart), New UIPropertyMetadata(New Collection(Of LineTrend), AddressOf LineChart.ChartDataChanged))

  Public Property ChartData As ObservableCollection(Of LineTrend)
    Get
      Return CType(GetValue(ChartDataProperty), IList(Of LineTrend))
    End Get
    Set
      SetValue(ChartDataProperty, Value)
    End Set
  End Property

  Public Shared Sub ChartDataChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)

    Dim LC As LineChart = DirectCast(d, LineChart)
    Dim chartData = TryCast(e.NewValue, IList(Of LineTrend))

    If LC._canvasPoints IsNot Nothing AndAlso chartData IsNot Nothing Then
      LC._xFloor = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.X).OrderBy(Function(x) x).FirstOrDefault()
      LC._xCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.X).OrderByDescending(Function(x) x).FirstOrDefault()
      LC._yFloor = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.Y).OrderBy(Function(x) x).FirstOrDefault()
      LC._yCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.Y).OrderByDescending(Function(x) x).FirstOrDefault()
      LC._canvasPoints.Children.RemoveRange(0, LC._canvasPoints.Children.Count)

      For Each trend In chartData
        LC.DrawTrend(trend)
      Next trend

      If LC._canvasXAxisTicks IsNot Nothing And LC._canvasYAxisTicks IsNot Nothing Then
        If LC._numberOfTicks = 0 Then LC._numberOfTicks = 1 'I want at the very least to see a beginning and an end
        LC.DrawXAxis(chartData)
        LC.DrawYAxis(chartData)
      End If
    End If
  End Sub


#End Region

#Region "ChartTitle"
  Public Shared ReadOnly ChartTitleProperty As DependencyProperty = DependencyProperty.Register("ChartTitle", GetType(String), GetType(LineChart), New UIPropertyMetadata(String.Empty))

  Public Property ChartTitle As String
    Get
      Return CType(GetValue(ChartTitleProperty), String)
    End Get
    Set
      SetValue(ChartTitleProperty, Value)
    End Set
  End Property
#End Region

#Region "BackGroundColor"
  Public Shared ReadOnly BackGroundColorProperty As DependencyProperty = DependencyProperty.Register("BackGroundColor", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColor As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorProperty, Value)
    End Set
  End Property
#End Region

#Region "BackGroundColorCanvas"
  Public Shared ReadOnly BackGroundColorCanvasProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorCanvas", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColorCanvas As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorCanvasProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorCanvasProperty, Value)
    End Set
  End Property
#End Region

#Region "BackGroundColorLegend"
  Public Shared ReadOnly BackGroundColorLegendProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorLegend", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColorLegend As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorLegendProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorLegendProperty, Value)
    End Set
  End Property
#End Region

#Region "ChartForeground"
  Public Shared ReadOnly ChartForegroundProperty As DependencyProperty = DependencyProperty.Register("ChartForeground", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Brushes.Black))

  Public Property ChartForeground As Brush
    Get
      Return DirectCast(GetValue(ChartForegroundProperty), Brush)
    End Get
    Set
      SetValue(ChartForegroundProperty, Value)
    End Set
  End Property
#End Region

#Region "LegendForeground"
  Public Shared ReadOnly LegendForegroundProperty As DependencyProperty = DependencyProperty.Register("LegendForeground", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Brushes.Black))

  Public Property LegendForeground As Brush
    Get
      Return DirectCast(GetValue(LegendForegroundProperty), Brush)
    End Get
    Set
      SetValue(LegendForegroundProperty, Value)
      _legendText.Visibility = Visibility.Visible
    End Set
  End Property

#End Region

#Region "NumberOfTicks"
  Public Shared ReadOnly NumberOfTicksProperty As DependencyProperty = DependencyProperty.Register("NumberOfTicks", GetType(Integer), GetType(LineGraph), New UIPropertyMetadata(0))

  Public Property NumberOfTicks As Integer
    Get
      Return DirectCast(GetValue(NumberOfTicksProperty), Integer)
    End Get
    Set
      SetValue(NumberOfTicksProperty, Value)
      _numberOfTicks = Value
    End Set
  End Property
#End Region


#Region "XValueConverter"
  'Public Shared ReadOnly XValueConverterProperty As DependencyProperty = DependencyProperty.Register("XValueConverter", GetType(IValueConverter), GetType(LineChart), New UIPropertyMetadata(DependencyProperty.UnsetValue, AddressOf XValChanged))

  'Public Property XValueConverter As IValueConverter
  '  Get
  '    Return CType(GetValue(XValueConverterProperty), IValueConverter)
  '  End Get
  '  Set
  '    SetValue(XValueConverterProperty, Value)
  '  End Set
  'End Property

  'Private Shared Sub XValChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  '  _xValueConverter = e.NewValue
  'End Sub


#End Region


#Region "Drawing Methods"
  Public Sub DrawXAxis(lineTrends As IList(Of LineTrend))

    Dim segment = ((_xCeiling - _xFloor) / _numberOfTicks)
    _canvasXAxisTicks.Children.RemoveRange(0, _canvasXAxisTicks.Children.Count)
    _canvasXAxisLabels.Children.RemoveRange(0, _canvasXAxisLabels.Children.Count)

    _canvasXAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = 1000,
                                   .Y1 = 0,
                                   .Y2 = 0,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })

    For i As Integer = 0 To _numberOfTicks
      Dim xSegment = If(i = 0, 0, i * (1000 / _numberOfTicks))
      Dim xSegmentLabel = If(i = 0, _xFloor, _xFloor + (i * segment))

      Dim lineSegment = New Line With {
          .X1 = xSegment,
          .X2 = xSegment,
          .Y1 = 0,
          .Y2 = 30,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      _canvasXAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = xSegmentLabel.ToString,
        .FontSize = If(_numberOfTicks <= 10, 30, 20),
        .Margin = New Thickness(xSegment - If(i = 0, 0, If(i = 5, 30, 15)), 0, 0, 0)
      }
      'If(_xValueConverter Is Nothing, String.Empty, _xValueConverter.Convert(xSegmentLabel, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)),

      _canvasXAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Public Sub DrawYAxis(lineTrends As IList(Of LineTrend))
    Dim segment = ((_yCeiling - _yFloor) / _numberOfTicks)
    _canvasYAxisTicks.Children.RemoveRange(0, _canvasYAxisTicks.Children.Count)
    _canvasYAxisLabels.Children.RemoveRange(0, _canvasYAxisLabels.Children.Count)

    _canvasYAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = 0,
                                   .Y1 = 0,
                                   .Y2 = 1000,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })

    For i As Integer = 0 To _numberOfTicks
      Dim ySegment = If(i = 0, 0, i * (1000 / _numberOfTicks))
      Dim ySegmentLabel = If(i = 0, _yFloor, _yFloor + (i * segment))

      Dim lineSegment = New Line With {
          .X1 = 0,
          .X2 = 30,
          .Y1 = ySegment,
          .Y2 = ySegment,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      _canvasYAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = ySegmentLabel.ToString,
        .FontSize = If(_numberOfTicks <= 10, 30, 20),
        .Margin = New Thickness(0, 980 - (ySegment - If(i = 0, 0, If(i = 5, 15, 5))), 0, 0)
      }

      _canvasYAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Friend Sub DrawTrend(Trend As LineTrend)
    Dim t = TryCast(Trend, LineTrend)

    If t IsNot Nothing AndAlso t.Points IsNot Nothing Then
      Dim xFactor = (1000 / (_xCeiling - _xFloor))
      Dim yFactor = (1000 / (_yCeiling - _yFloor))

      For i As Integer = 1 To t.Points.Count - 1
        Dim toDraw = New Line With {
          .X1 = (t.Points(i - 1).X - _xFloor) * xFactor,
          .Y1 = (t.Points(i - 1).Y - _yFloor) * yFactor,
          .X2 = (t.Points(i).X - _xFloor) * xFactor,
          .Y2 = (t.Points(i).Y - _yFloor) * yFactor,
          .StrokeThickness = 2,
          .Stroke = t.LineColor}
        _canvasPoints.Children.Add(toDraw)
      Next i
    End If
  End Sub
#End Region

End Class
