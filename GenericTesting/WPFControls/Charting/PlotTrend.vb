Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class PlotTrend
  Implements INotifyPropertyChanged

  Private _seriesName As String
  Public Property SeriesName As String
    Get
      Return _seriesName
    End Get
    Set
      _seriesName = Value
      OnPropertyChanged(NameOf(SeriesName))
    End Set
  End Property

  Private _lineColor As Brush
  Public Property LineColor As Brush
    Get
      Return _lineColor
    End Get
    Set
      _lineColor = Value
      OnPropertyChanged(NameOf(LineColor))
    End Set
  End Property

  Private _pointThickness As Thickness
  Public Property PointThickness As Thickness
    Get
      Return _pointThickness
    End Get
    Set
      _pointThickness = Value
      OnPropertyChanged(NameOf(PointThickness))
    End Set
  End Property

  Public ReadOnly Property Points As New ObservableCollection(Of PlotPoints)

  Public Sub New(seriesName As String, lineColor As Brush, pointThickness As Thickness, points As IEnumerable(Of PlotPoints))
    Me.SeriesName = seriesName
    Me.LineColor = lineColor
    Me.PointThickness = pointThickness
    Me.Points.ClearAndAddRange(points)

    AddHandler Me.Points.CollectionChanged, AddressOf NotifyChangedCollection
  End Sub

  Private Sub NotifyChangedCollection(sender As Object, e As EventArgs)
    Me.OnPropertyChanged(NameOf(Points))
  End Sub

  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

  Public Sub OnPropertyChanged(ByVal info As String)
    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
  End Sub

End Class