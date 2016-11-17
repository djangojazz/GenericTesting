﻿Public Class PlotPoint(Of T)
  Inherits PlotPoint

  Public Sub New(point As T)
    If Not (GetType(T) Is GetType(Decimal) Or GetType(T) Is GetType(Integer) Or GetType(T) Is GetType(Date)) Then Throw New ArgumentException("Cannot have a plot point that is not Decimal, Integer or Date")

    Me.Point = point
  End Sub
  Public Property Point As T

  Public Overrides ReadOnly Property PointType As Type
    Get
      Return GetType(T)
    End Get
  End Property

End Class

Public MustInherit Class PlotPoint
  MustOverride ReadOnly Property PointType As Type
End Class

