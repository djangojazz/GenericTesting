Imports System.ComponentModel
Imports System.Collections.ObjectModel


Public Class LineGraph
  Inherits Control
  Implements INotifyPropertyChanged

  Public Shared ReadOnly TESTProperty As DependencyProperty = DependencyProperty.Register("TEST", GetType(String), GetType(LineGraph), New UIPropertyMetadata(Nothing, AddressOf OnTestChanged))

  Public Property TEST As String
    Get
      Return DirectCast(GetValue(TESTProperty), String)
    End Get
    Set
      SetValue(TESTProperty, Value)
    End Set
  End Property

  Private Shared Sub OnTestChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    MessageBox.Show(e.NewValue)
    'Dim target = DirectCast(d, LineGraph)
    'Dim oldAxis = DirectCast(e.OldValue, IEnumerable)
    'Dim newAxis = target.Axis
    'target.OnAxis2Changed(oldAxis, newAxis)
  End Sub

  ''' <summary>
  '''   Provides derived classes an opportunity to handle changes to the Axis property.
  ''' </summary>
  Protected Overridable Sub OnTrendsChanged(oldAxis As String, newAxis As String)
  End Sub

  'CONSTRUCTOR
  Shared Sub New()
    DefaultStyleKeyProperty.OverrideMetadata(GetType(LineGraph), New FrameworkPropertyMetadata(GetType(LineGraph)))
  End Sub

  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

  Public Sub OnPropertyChanged(ByVal info As String)
    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
  End Sub

  Public Shared ReadOnly _Trends As DependencyProperty = DependencyProperty.RegisterReadOnly("Trends", GetType(Collection(Of ChartDataSegment)), GetType(LineGraph), New PropertyMetadata(New Collection(Of ChartDataSegment)())).DependencyProperty

  Public ReadOnly Property Trends As Collection(Of ChartDataSegment)
    Get
      Return DirectCast(GetValue(_Trends), Collection(Of ChartDataSegment))
    End Get
  End Property

  Public Overrides Sub OnApplyTemplate()
    MyBase.OnApplyTemplate()
    Dim canvas = TryCast(GetTemplateChild("PART_Canvas"), Canvas)
    If canvas IsNot Nothing AndAlso Trends IsNot Nothing Then
      For Each trend In Trends
        DrawTrend(canvas, trend)
      Next trend
    End If
  End Sub

  Public Sub DrawTrend(drawingCanvas As Canvas, Trend As ChartDataSegment)
    Dim t = TryCast(Trend, ChartDataSegment)
    If t IsNot Nothing AndAlso t.Points IsNot Nothing Then
      For i As Integer = 1 To t.Points.Count - 1
        Dim toDraw = New Line With {
          .X1 = t.Points(i - 1).X,
          .Y1 = t.Points(i - 1).Y,
          .X2 = t.Points(i).X,
          .Y2 = t.Points(i).Y,
          .StrokeThickness = 2,
          .Stroke = t.LineColor}
        drawingCanvas.Children.Add(toDraw)
      Next i
    End If
  End Sub

End Class

Public Class ChartDataSegment
  Inherits DependencyObject


  Public Shared ReadOnly _LineColor As DependencyProperty = DependencyProperty.Register("LineColor", GetType(Brush), GetType(ChartDataSegment), New PropertyMetadata(Nothing))
  Public Property LineColor As Brush
    Get
      Return DirectCast(GetValue(_LineColor), Brush)
    End Get
    Set(value As Brush)
      SetValue(_LineColor, value)
    End Set
  End Property

  Public Shared ReadOnly _LineThickness As DependencyProperty = DependencyProperty.Register("LineThickness", GetType(Thickness), GetType(ChartDataSegment), New PropertyMetadata(Nothing))
  Public Property PointThickness As Thickness
    Get
      Return DirectCast(GetValue(_LineThickness), Thickness)
    End Get
    Set(value As Thickness)
      SetValue(_LineThickness, value)
    End Set
  End Property

  Public Shared ReadOnly _Points As DependencyProperty = DependencyProperty.Register("Points", GetType(ObservableCollection(Of Point)), GetType(ChartDataSegment), New UIPropertyMetadata(Nothing))
  Public Property Points As ObservableCollection(Of Point)
    Get
      Return DirectCast(GetValue(_Points), ObservableCollection(Of Point))
    End Get
    Set(value As ObservableCollection(Of Point))
      SetValue(_Points, value)
    End Set
  End Property


  Private _commandCloseMe As New Lazy(Of DelegateCommand(Of String))(Function() New DelegateCommand(Of String)(AddressOf CommandCloseMeExecute))

  Public ReadOnly Property CommandCloseMe As DelegateCommand(Of String)
    Get
      Return _commandCloseMe.Value
    End Get
  End Property

  Private Sub CommandCloseMeExecute()

  End Sub
End Class