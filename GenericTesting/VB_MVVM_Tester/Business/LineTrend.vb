Imports System.Collections.ObjectModel

Public Class LineTrend
  Public Property SeriesName As String
  Public Property LineColor As Brush
  Public Property PointThickness As Thickness
  Public Property Points As ObservableCollection(Of Point)
End Class