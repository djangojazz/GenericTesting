Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class LineGraph
  Inherits Control
  Implements INotifyPropertyChanged

  'CONSTRUCTOR
  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub

  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

  Public Shared ReadOnly _TrendsKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("Trends", GetType(Collection(Of LineTrend)), GetType(LineGraph), New PropertyMetadata(New Collection(Of LineTrend)()))
  Public Shared ReadOnly _Trends As DependencyProperty = _TrendsKey.DependencyProperty

  Public ReadOnly Property Trends() As Collection(Of LineTrend)
    Get
      Return DirectCast(GetValue(_Trends), Collection(Of LineTrend))
    End Get
  End Property

  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    Dim trendsViewPort = TryCast(GetTemplateChild("PART_TrendsViewPort"), Canvas)
    If trendsViewPort IsNot Nothing AndAlso Trends IsNot Nothing Then
      For Each trend In Trends
        DrawTrend(trendsViewPort, trend)
      Next trend
    End If
  End Sub

  Private Sub DrawTrend(ByVal drwaingCanvas As Canvas, ByVal Trend As LineTrend)
    Dim t = TryCast(Trend, LineTrend)
    If t IsNot Nothing AndAlso t.Points IsNot Nothing Then
      For i As Integer = 1 To t.Points.Count - 1
        Dim toDraw = New Line With {
          .X1 = t.Points(i - 1).X,
          .Y1 = t.Points(i - 1).Y,
          .X2 = t.Points(i).X,
          .Y2 = t.Points(i).Y,
          .StrokeThickness = 2,
          .Stroke = t.TrendColor}
        drwaingCanvas.Children.Add(toDraw)
      Next i
    End If
  End Sub

End Class

Public Class LineTrend
  Inherits DependencyObject


  Public Shared ReadOnly _TrendColor As DependencyProperty = DependencyProperty.Register("TrendColor", GetType(Brush), GetType(LineTrend), New PropertyMetadata(Nothing))
  Public Property TrendColor() As Brush
    Get
      Return DirectCast(GetValue(_TrendColor), Brush)
    End Get
    Set(value As Brush)
      SetValue(_TrendColor, value)
    End Set
  End Property

  Public Shared ReadOnly _PointThickness As DependencyProperty = DependencyProperty.Register("PointThinkness", GetType(Thickness), GetType(LineTrend), New PropertyMetadata(Nothing))
  Public Property PointThickness() As Thickness
    Get
      Return DirectCast(GetValue(_PointThickness), Thickness)
    End Get
    Set(value As Thickness)
      SetValue(_PointThickness, value)
    End Set
  End Property

  Public Shared ReadOnly _Points As DependencyProperty = DependencyProperty.Register("Points", GetType(ObservableCollection(Of TrendPoint)), GetType(LineTrend), New UIPropertyMetadata(Nothing))
  Public Property Points() As ObservableCollection(Of TrendPoint)
    Get
      Return DirectCast(GetValue(_Points), ObservableCollection(Of TrendPoint))
    End Get
    Set(value As ObservableCollection(Of TrendPoint))
      SetValue(_Points, value)
    End Set
  End Property

End Class

Public Class TrendPoint
  Inherits DependencyObject
  Public Property X() As Single
  Public Property Y() As Single
  Public Property AdditionalData() As Dictionary(Of String, String)

  Public Sub New()
    X = 0
    Y = 0
    AdditionalData = New Dictionary(Of String, String)()
  End Sub
End Class
