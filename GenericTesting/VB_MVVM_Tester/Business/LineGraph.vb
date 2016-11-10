Imports System.ComponentModel
Imports System.Collections.ObjectModel


Public Class LineGraph
  Inherits Control

  Private Shared _canvas As Canvas = Nothing
  Private Shared _legendText As TextBlock = Nothing
  Private Shared _xCeiling As Decimal = 0
  Private Shared _yCeiling As Decimal = 0

  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub


#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(Collection(Of LineTrend)), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf ChartDataChanged))

  Public Property ChartData As Collection(Of LineTrend)
    Get
      Return DirectCast(GetValue(ChartDataProperty), Collection(Of LineTrend))
    End Get
    Set
      SetValue(ChartDataProperty, Value)
    End Set
  End Property

  Private Shared Sub ChartDataChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim chartData = TryCast(e.NewValue, Collection(Of LineTrend))

    If _canvas IsNot Nothing AndAlso chartData IsNot Nothing Then
      For Each trend In chartData
        DrawTrend(trend)
      Next trend
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


  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    _canvas = TryCast(GetTemplateChild("PART_Canvas"), Canvas)
    _legendText = TryCast(GetTemplateChild("PART_LEGENDTEXT"), TextBlock)
    If LegendForeground IsNot Nothing Then _legendText.Visibility = Visibility.Visible
  End Sub

  Public Shared Sub DrawTrend(Trend As LineTrend)
    Dim t = TryCast(Trend, LineTrend)
    If t IsNot Nothing AndAlso t.Points IsNot Nothing Then
      For i As Integer = 1 To t.Points.Count - 1
        Dim toDraw = New Line With {
          .X1 = t.Points(i - 1).X,
          .Y1 = t.Points(i - 1).Y,
          .X2 = t.Points(i).X,
          .Y2 = t.Points(i).Y,
          .StrokeThickness = 2,
          .Stroke = t.LineColor}
        _canvas.Children.Add(toDraw)
      Next i
    End If
  End Sub

End Class