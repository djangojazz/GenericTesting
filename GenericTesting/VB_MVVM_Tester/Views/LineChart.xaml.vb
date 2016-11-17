Imports System.Collections.ObjectModel

Public Class LineChart
  Private _xType As Type
  Private _xFloor As Decimal = 0
  Private _xCeiling As Decimal = 0
  Private _yType As Type
  Private _yFloor As Decimal = 0
  Private _yCeiling As Decimal = 0

  Public Sub New()
    InitializeComponent()
  End Sub

#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(IList(Of LineTrend)), GetType(LineChart), New UIPropertyMetadata(New Collection(Of LineTrend), AddressOf LineChart.ChartDataChanged))

  Public Property ChartData As IList(Of LineTrend)
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

    If LC.PART_CanvasPoints IsNot Nothing AndAlso chartData IsNot Nothing Then
      LC._xFloor = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.XAsDouble).OrderBy(Function(x) x).FirstOrDefault()
      LC._xCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.XAsDouble).OrderByDescending(Function(x) x).FirstOrDefault()
      LC._yFloor = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.YAsDouble).OrderBy(Function(x) x).FirstOrDefault()
      LC._yCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.YAsDouble).OrderByDescending(Function(x) x).FirstOrDefault()

      LC.PART_CanvasPoints.Children.RemoveRange(0, LC.PART_CanvasPoints.Children.Count)
      LC.DrawTrends(chartData)


      If LC.PART_CanvasXAxisTicks IsNot Nothing And LC.PART_CanvasYAxisTicks IsNot Nothing Then
        If LC.NumberOfTicks = 0 Then LC.NumberOfTicks = 1 'I want at the very least to see a beginning and an end
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
  Public Shared ReadOnly BackGroundColorProperty As DependencyProperty = DependencyProperty.Register("BackGroundColor", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

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
  Public Shared ReadOnly BackGroundColorCanvasProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorCanvas", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

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
  Public Shared ReadOnly BackGroundColorLegendProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorLegend", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

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
  Public Shared ReadOnly ChartForegroundProperty As DependencyProperty = DependencyProperty.Register("ChartForeground", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

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
  Public Shared ReadOnly LegendForegroundProperty As DependencyProperty = DependencyProperty.Register("LegendForeground", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property LegendForeground As Brush
    Get
      Return DirectCast(GetValue(LegendForegroundProperty), Brush)
    End Get
    Set
      SetValue(LegendForegroundProperty, Value)
      PART_LEGENDTEXT.Visibility = Visibility.Visible
    End Set
  End Property

#End Region

#Region "NumberOfTicks"
  Public Shared ReadOnly NumberOfTicksProperty As DependencyProperty = DependencyProperty.Register("NumberOfTicks", GetType(Integer), GetType(LineChart), New UIPropertyMetadata(0))

  Public Property NumberOfTicks As Integer
    Get
      Return DirectCast(GetValue(NumberOfTicksProperty), Integer)
    End Get
    Set
      SetValue(NumberOfTicksProperty, Value)
    End Set
  End Property
#End Region

#Region "XValueConverter"
  Public Shared ReadOnly XValueConverterProperty As DependencyProperty = DependencyProperty.Register("XValueConverter", GetType(IValueConverter), GetType(LineChart), Nothing)

  Public Property XValueConverter As IValueConverter
    Get
      Return CType(GetValue(XValueConverterProperty), IValueConverter)
    End Get
    Set
      SetValue(XValueConverterProperty, Value)
    End Set
  End Property


#End Region


#Region "Drawing Methods"
  Public Sub DrawXAxis(lineTrends As IList(Of LineTrend))

    Dim segment = ((_xCeiling - _xFloor) / NumberOfTicks)
    PART_CanvasXAxisTicks.Children.RemoveRange(0, PART_CanvasXAxisTicks.Children.Count)
    PART_CanvasXAxisLabels.Children.RemoveRange(0, PART_CanvasXAxisLabels.Children.Count)

    PART_CanvasXAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = 1000,
                                   .Y1 = 0,
                                   .Y2 = 0,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })

    For i As Integer = 0 To NumberOfTicks
      Dim xSegment = If(i = 0, 0, i * (1000 / NumberOfTicks))
      Dim xSegmentLabel = If(i = 0, _xFloor, _xFloor + (i * segment))

      Dim lineSegment = New Line With {
          .X1 = xSegment,
          .X2 = xSegment,
          .Y1 = 0,
          .Y2 = 30,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      PART_CanvasXAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = If(XValueConverter Is Nothing, String.Empty, XValueConverter.Convert(xSegmentLabel, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)),
        .FontSize = If(NumberOfTicks <= 10, 30, 20),
        .Margin = New Thickness(xSegment - If(i = 0, 0, If(i = 5, 30, 15)), 0, 0, 0)
      }

      PART_CanvasXAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Public Sub DrawYAxis(lineTrends As IList(Of LineTrend))
    Dim segment = ((_yCeiling - _yFloor) / NumberOfTicks)

    PART_CanvasYAxisTicks.Children.RemoveRange(0, PART_CanvasYAxisTicks.Children.Count)
    PART_CanvasYAxisLabels.Children.RemoveRange(0, PART_CanvasYAxisLabels.Children.Count)

    PART_CanvasYAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = 0,
                                   .Y1 = 0,
                                   .Y2 = 1000,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })

    For i As Integer = 0 To NumberOfTicks
      Dim ySegment = If(i = 0, 0, i * (1000 / NumberOfTicks))
      Dim ySegmentLabel = If(i = 0, _yFloor, _yFloor + (i * segment))

      Dim lineSegment = New Line With {
          .X1 = 0,
          .X2 = 30,
          .Y1 = ySegment,
          .Y2 = ySegment,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      PART_CanvasYAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = ySegmentLabel.ToString,
        .FontSize = If(NumberOfTicks <= 10, 30, 20),
        .Margin = New Thickness(0, 980 - (ySegment - If(i = 0, 0, If(i = 5, 15, 5))), 0, 0)
      }

      PART_CanvasYAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Friend Sub DrawTrends(points As IList(Of LineTrend))

    For Each t In ChartData
      If t.Points IsNot Nothing Then
        Dim xFactor = (1000 / (_xCeiling - _xFloor))
        Dim yFactor = (1000 / (_yCeiling - _yFloor))

        For i As Integer = 1 To t.Points.Count - 1
          Dim toDraw = New Line With {
            .X1 = (t.Points(i - 1).XAsDouble - _xFloor) * xFactor,
            .Y1 = (t.Points(i - 1).YAsDouble - _yFloor) * yFactor,
            .X2 = (t.Points(i).XAsDouble - _xFloor) * xFactor,
            .Y2 = (t.Points(i).YAsDouble - _yFloor) * yFactor,
            .StrokeThickness = 2,
            .Stroke = t.LineColor}
          PART_CanvasPoints.Children.Add(toDraw)
        Next i
      End If
    Next


  End Sub
#End Region

End Class