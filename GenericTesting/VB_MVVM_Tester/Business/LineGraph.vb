Imports System.ComponentModel
Imports System.Collections.ObjectModel


Public Class LineGraph
  Inherits Control

  Private Shared _canvas

  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub


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

  Protected Overridable Sub ChartDataChanged(oldAxis As String, newAxis As String)
  End Sub

  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    _canvas = TryCast(GetTemplateChild("PART_Canvas"), Canvas)
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