Public Class PlotPoints
  Public Property X As PlotPoint
  Public Property Y As PlotPoint

  Public ReadOnly Property XAsDouble As Decimal
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
          val = CDbl(DirectCast(X, PlotPoint(Of Date)).Point.ToOADate)
      End Select

      Return val
    End Get
  End Property

  Public ReadOnly Property YAsDouble As Decimal
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
          val = CDbl(DirectCast(Y, PlotPoint(Of Date)).Point.ToOADate)
      End Select

      Return val
    End Get
  End Property

End Class