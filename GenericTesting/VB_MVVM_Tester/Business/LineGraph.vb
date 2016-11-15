Imports System.ComponentModel
Imports System.Collections.ObjectModel


Public Class LineGraph
  Inherits Control

  Private Shared _canvasPoints As Canvas = Nothing
  Private Shared _canvasXAxisTicks As Canvas = Nothing
  Private Shared _canvasXAxisLabels As Canvas = Nothing
  Private Shared _canvasYAxisTicks As Canvas = Nothing
  Private Shared _canvasYAxisLabels As Canvas = Nothing
  Private Shared _legendText As TextBlock = Nothing
  Private Shared _xCeiling As Decimal = 0
  Private Shared _yCeiling As Decimal = 0

  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub

  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    _canvasPoints = TryCast(GetTemplateChild("PART_CanvasPoints"), Canvas)
    _canvasXAxisTicks = TryCast(GetTemplateChild("PART_CanvasXAxisTicks"), Canvas)
    _canvasXAxisLabels = TryCast(GetTemplateChild("PART_CanvasXAxisLabels"), Canvas)
    _canvasYAxisTicks = TryCast(GetTemplateChild("PART_CanvasYAxisTicks"), Canvas)
    _canvasYAxisLabels = TryCast(GetTemplateChild("PART_CanvasYAxisLabels"), Canvas)
    _legendText = TryCast(GetTemplateChild("PART_LEGENDTEXT"), TextBlock)

    If LegendForeground IsNot Nothing Then _legendText.Visibility = Visibility.Visible
  End Sub


#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(IList(Of LineTrend)), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf ChartDataChanged))

  Public Property ChartData As IList(Of LineTrend)
    Get
      Return DirectCast(GetValue(ChartDataProperty), IList(Of LineTrend))
    End Get
    Set
      SetValue(ChartDataProperty, Value)
    End Set
  End Property

  Private Shared Sub ChartDataChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim chartData = TryCast(e.NewValue, IList(Of LineTrend))

    If _canvasPoints IsNot Nothing AndAlso chartData IsNot Nothing Then
      _xCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.X).OrderByDescending(Function(x) x).FirstOrDefault()
      _yCeiling = chartData.SelectMany(Function(x) x.Points).Select(Function(x) x.Y).OrderByDescending(Function(x) x).FirstOrDefault()
      _canvasPoints.Children.RemoveRange(0, _canvasPoints.Children.Count)

      For Each trend In chartData
        DrawTrend(trend)
      Next trend

      If _canvasXAxisTicks IsNot Nothing And _canvasYAxisTicks IsNot Nothing Then
        DrawXAxis(chartData)
        DrawYAxis(chartData)
      End If
    End If
  End Sub
#End Region

#Region "BackGroundColor"
  Public Shared ReadOnly BackGroundColorProperty As DependencyProperty = DependencyProperty.Register("BackGroundColor", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf BackGroundColorChanged))

  Public Property BackGroundColor As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorProperty, Value)
    End Set
  End Property

  Private Shared Sub BackGroundColorChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  End Sub
#End Region

#Region "BackGroundColorCanvas"
  Public Shared ReadOnly BackGroundColorCanvasProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorCanvas", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf BackGroundColorCanvasChanged))

  Public Property BackGroundColorCanvas As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorCanvasProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorCanvasProperty, Value)
    End Set
  End Property

  Private Shared Sub BackGroundColorCanvasChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  End Sub
#End Region

#Region "BackGroundColorLegend"
  Public Shared ReadOnly BackGroundColorLegendProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorLegend", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf BackGroundColorLegendChanged))

  Public Property BackGroundColorLegend As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorLegendProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorLegendProperty, Value)
    End Set
  End Property

  Private Shared Sub BackGroundColorLegendChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  End Sub
#End Region

#Region "ChartForeground"
  Public Shared ReadOnly ChartForegroundProperty As DependencyProperty = DependencyProperty.Register("ChartForeground", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf ChartForegroundChanged))

  Public Property ChartForeground As Brush
    Get
      Return DirectCast(GetValue(ChartForegroundProperty), Brush)
    End Get
    Set
      SetValue(ChartForegroundProperty, Value)
    End Set
  End Property

  Private Shared Sub ChartForegroundChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  End Sub
#End Region

#Region "LegendForeground"
  Public Shared ReadOnly LegendForegroundProperty As DependencyProperty = DependencyProperty.Register("LegendForeground", GetType(Brush), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf LegendForegroundChanged))

  Public Property LegendForeground As Brush
    Get
      Return DirectCast(GetValue(LegendForegroundProperty), Brush)
    End Get
    Set
      SetValue(LegendForegroundProperty, Value)
      _legendText.Visibility = Visibility.Visible
    End Set
  End Property

  Private Shared Sub LegendForegroundChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    If _legendText?.Visibility IsNot Nothing Then
      _legendText.Visibility = Visibility.Visible
    End If
  End Sub
#End Region

#Region "ChartTitle"
  Public Shared ReadOnly ChartTitleProperty As DependencyProperty = DependencyProperty.Register("ChartTitle", GetType(String), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf ChartTitleChanged))

  Public Property ChartTitle As String
    Get
      Return DirectCast(GetValue(ChartTitleProperty), String)
    End Get
    Set
      SetValue(ChartTitleProperty, Value)
    End Set
  End Property



  Private Shared Sub ChartTitleChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
  End Sub
#End Region


#Region "Drawing Methods"
  Public Shared Sub DrawXAxis(lineTrends As IList(Of LineTrend))
    Dim segment = (_xCeiling / 5)
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

    For i As Integer = 0 To 5
      Dim xSegment = If(i = 0, 0, i * 200)
      Dim xSegmentLabel = If(i = 0, 0, i * segment)

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
        .FontSize = 20,
        .Margin = New Thickness(xSegment - If(i = 0, 0, If(i = 5, 30, 15)), 0, 0, 0)
      }

      _canvasXAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Public Shared Sub DrawYAxis(lineTrends As IList(Of LineTrend))
    Dim segment = (_yCeiling / 5)
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

    For i As Integer = 0 To 5
      Dim ySegment = If(i = 0, 0, i * 200)
      Dim ySegmentLabel = If(i = 0, 0, i * segment)

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
        .FontSize = 20,
        .Margin = New Thickness(0, 980 - (ySegment - If(i = 0, 0, If(i = 5, 15, 5))), 0, 0)
      }

      _canvasYAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Public Shared Sub DrawTrend(Trend As LineTrend)
    Dim t = TryCast(Trend, LineTrend)

    If t IsNot Nothing AndAlso t.Points IsNot Nothing Then
      Dim xFactor = (1000 / _xCeiling)
      Dim yFactor = (1000 / _yCeiling)

      For i As Integer = 1 To t.Points.Count - 1
        Dim toDraw = New Line With {
          .X1 = t.Points(i - 1).X * xFactor,
          .Y1 = t.Points(i - 1).Y * yFactor,
          .X2 = t.Points(i).X * xFactor,
          .Y2 = t.Points(i).Y * yFactor,
          .StrokeThickness = 2,
          .Stroke = t.LineColor}
        _canvasPoints.Children.Add(toDraw)
      Next i
    End If
  End Sub
#End Region

End Class