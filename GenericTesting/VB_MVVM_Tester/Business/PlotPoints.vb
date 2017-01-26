Public Class PlotPoints
  Inherits BaseViewModel

  'Private _x As PlotPoint
  Public ReadOnly Property X As PlotPoint
  Public ReadOnly Property Y As PlotPoint

  Public Sub New(x As PlotPoint, y As PlotPoint)
    Me.X = x
    Me.Y = y
  End Sub

  Public ReadOnly Property XAsDouble As Double
    Get
      Dim val As Double = 0

      Select Case True
        Case X.PointType Is GetType(Integer)
          val = CDbl(DirectCast(X, PlotPoint(Of Integer)).Point)
        Case X.PointType Is GetType(Double)
          val = CDbl(DirectCast(X, PlotPoint(Of Double)).Point)
        Case X.PointType Is GetType(Decimal)
          val = CDbl(DirectCast(X, PlotPoint(Of Decimal)).Point)
        Case X.PointType Is GetType(Date)
          val = CDbl(DirectCast(X, PlotPoint(Of Date)).Point.Ticks)
        Case X.PointType Is GetType(DateTime)
          val = CDbl(DirectCast(X, PlotPoint(Of DateTime)).Point.Ticks)
      End Select

      Return val
    End Get
  End Property

  Public ReadOnly Property YAsDouble As Double
    Get
      Dim val As Double = 0

      Select Case True
        Case Y.PointType Is GetType(Integer)
          val = CDbl(DirectCast(Y, PlotPoint(Of Integer)).Point)
        Case Y.PointType Is GetType(Double)
          val = CDbl(DirectCast(Y, PlotPoint(Of Double)).Point)
        Case Y.PointType Is GetType(Decimal)
          val = CDbl(DirectCast(Y, PlotPoint(Of Decimal)).Point)
        Case Y.PointType Is GetType(Date)
          val = CDbl(DirectCast(Y, PlotPoint(Of Date)).Point.Ticks)
        Case Y.PointType Is GetType(DateTime)
          val = CDbl(DirectCast(Y, PlotPoint(Of DateTime)).Point.Ticks)
      End Select

      Return val
    End Get
  End Property

  Public Overrides Function ToString() As String
    Return $"X {XAsDouble } Y {YAsDouble}"
  End Function

End Class