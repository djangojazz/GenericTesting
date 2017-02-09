Public Class HeaderSection
  Public Sub New()
    InitializeComponent()
    SECTION_ChartTitle.DataContext = Me
  End Sub

#Region "ChartTitle"
  Public Shared ReadOnly ChartTitleProperty As DependencyProperty = DependencyProperty.Register("ChartTitle", GetType(String), GetType(LineChart), New UIPropertyMetadata(String.Empty))

  Public Property ChartTitle As String
    Get
      Return CType(GetValue(ChartTitleProperty), String)
    End Get
    Set
      SetValue(ChartTitleProperty, Value)
    End Set
  End Property
#End Region

#Region "ChartTitleForeground"
  Public Shared ReadOnly ChartTitleForegroundProperty As DependencyProperty = DependencyProperty.Register("ChartTitleForeground", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property ChartTitleForeground As Brush
    Get
      Return DirectCast(GetValue(ChartTitleForegroundProperty), Brush)
    End Get
    Set
      SetValue(ChartTitleForegroundProperty, Value)
    End Set
  End Property
#End Region

#Region "ChartTitleHidden"
  Public Shared ReadOnly ChartTitleHiddenProperty As DependencyProperty = DependencyProperty.Register("ChartTitleHidden", GetType(Boolean), GetType(LineChart), New UIPropertyMetadata(False, AddressOf HeaderSection.ChartTitleHiddenChanged))

  Public Property ChartTitleHidden As Boolean
    Get
      Return DirectCast(GetValue(ChartTitleHiddenProperty), Boolean)
    End Get
    Set
      SetValue(ChartTitleHiddenProperty, Value)
    End Set
  End Property

  Public Shared Sub ChartTitleHiddenChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim hdr = DirectCast(d, HeaderSection)

    If CBool(e.NewValue) Then
      hdr.SECTION_ChartTitle.Visibility = Visibility.Collapsed
    Else
      hdr.SECTION_ChartTitle.Visibility = Visibility.Visible
    End If

  End Sub
#End Region
End Class
