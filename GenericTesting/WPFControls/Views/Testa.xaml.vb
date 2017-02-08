Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports WPFControls.WPFControls

Public Class Testa
  Implements INotifyPropertyChanged


  Public Sub New()
    InitializeComponent()
    PART_TestLayout.DataContext = Me
  End Sub

#Region "TestTitle"
  Public Shared ReadOnly TestTitleProperty As DependencyProperty = DependencyProperty.Register("TestTitle", GetType(String), GetType(Testa), New UIPropertyMetadata(String.Empty, AddressOf TestChanged))

  Public Property TestTitle As String
    Get
      Return CType(GetValue(TestTitleProperty), String)
    End Get
    Set
      SetValue(TestTitleProperty, Value)
    End Set
  End Property

  Private Shared Sub TestChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim m = DirectCast(d, Testa)
    m.PART_Text2.Text = $"Changed {DateTime.Now.ToLongTimeString}"
  End Sub
#End Region

#Region "T"
  Public Shared ReadOnly TProperty As DependencyProperty = DependencyProperty.Register("T", GetType(ObservableCollection(Of String)), GetType(Testa), New UIPropertyMetadata(New ObservableCollection(Of String), AddressOf TChanged))

  Public Property T As ObservableCollection(Of String)
    Get
      Return CType(GetValue(TProperty), ObservableCollection(Of String))
    End Get
    Set
      SetValue(TProperty, Value)
    End Set
  End Property

  Private Shared Sub TChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim m = DirectCast(d, Testa)
  End Sub
#End Region

#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(ObservableCollection(Of PlotTrend)), GetType(Testa), New UIPropertyMetadata(New ObservableCollection(Of PlotTrend), AddressOf ChartDataChanged))

  Public Property ChartData As ObservableCollection(Of PlotTrend)
    Get
      Return CType(GetValue(ChartDataProperty), ObservableCollection(Of PlotTrend))
    End Get
    Set
      SetValue(ChartDataProperty, Value)
    End Set
  End Property
#End Region

  Public Shared Sub ChartDataChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim m = DirectCast(d, Testa)

    If Not IsNothing(e.OldValue) Then
      Dim OldCollection = TryCast(e.OldValue, ObservableCollection(Of PlotTrend))
    End If

    If Not IsNothing(e.NewValue) Then
      Dim NewCollection = TryCast(e.NewValue, ObservableCollection(Of PlotTrend))
    End If

  End Sub

  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

  Public Sub OnPropertyChanged(ByVal info As String)
    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
  End Sub
End Class
