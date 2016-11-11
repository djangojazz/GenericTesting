Imports System.ComponentModel
Imports System.Collections.ObjectModel


Public Class LineGraph2
  Inherits Control

  Private Shared _canvas As Canvas = Nothing
  Private Shared _legendText As TextBlock = Nothing
  Private Shared _xCeiling As Decimal = 0
  Private Shared _yCeiling As Decimal = 0

  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub


  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    '_canvas = TryCast(GetTemplateChild("PART_Canvas"), Canvas)
    '_legendText = TryCast(GetTemplateChild("PART_LEGENDTEXT"), TextBlock)
    'If LegendForeground IsNot Nothing Then _legendText.Visibility = Visibility.Visible
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