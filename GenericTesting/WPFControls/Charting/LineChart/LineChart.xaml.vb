Imports System.Windows.Threading

Public Class LineChart

  'VARIABLES
  Private _xType As Type
  Private _xFloor As Decimal = 0
  Private _xCeiling As Decimal = 0
  Private _yType As Type
  Private _yFloor As Decimal = 0
  Private _yCeiling As Decimal = 0
  Private _viewHeight As Double = 0
  Private _viewWidth As Double = 0
  Private _tickWidth As Double = 0
  Private _tickHeight As Double = 0
  Private _labelWidth As Double = 0
  Private _labelHeight As Double = 0
  Private _timer As New DispatcherTimer
  Private _defaultTimeSpan As New TimeSpan(1000)

  Private ReadOnly Property Ratio As Double
    Get
      Return PART_CanvasBorder.ActualHeight / PART_CanvasBorder.ActualWidth
    End Get
  End Property

  Public Sub New()
    InitializeComponent()
    _timer.Interval = _defaultTimeSpan
  End Sub

#Region "Dependent Properties"

#Region "ChartData"
  Public Shared ReadOnly ChartDataProperty As DependencyProperty = DependencyProperty.Register("ChartData", GetType(ObservableCollectionContentNotifying(Of PlotTrend)), GetType(LineChart), New UIPropertyMetadata(New ObservableCollectionContentNotifying(Of PlotTrend), AddressOf LineChart.ChartDataChanged))

  Public Property ChartData As ObservableCollectionContentNotifying(Of PlotTrend)
    Get
      Return CType(GetValue(ChartDataProperty), ObservableCollectionContentNotifying(Of PlotTrend))
    End Get
    Set
      SetValue(ChartDataProperty, Value)
    End Set
  End Property
#End Region

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

#Region "BackGroundColor"
  Public Shared ReadOnly BackGroundColorProperty As DependencyProperty = DependencyProperty.Register("BackGroundColor", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColor As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorProperty, Value)
    End Set
  End Property
#End Region

#Region "BackGroundColorCanvas"
  Public Shared ReadOnly BackGroundColorCanvasProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorCanvas", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColorCanvas As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorCanvasProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorCanvasProperty, Value)
    End Set
  End Property
#End Region

#Region "BackGroundColorLegend"
  Public Shared ReadOnly BackGroundColorLegendProperty As DependencyProperty = DependencyProperty.Register("BackGroundColorLegend", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property BackGroundColorLegend As Brush
    Get
      Return DirectCast(GetValue(BackGroundColorLegendProperty), Brush)
    End Get
    Set
      SetValue(BackGroundColorLegendProperty, Value)
    End Set
  End Property
#End Region

#Region "ChartForeground"
  Public Shared ReadOnly ChartForegroundProperty As DependencyProperty = DependencyProperty.Register("ChartForeground", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black))

  Public Property ChartForeground As Brush
    Get
      Return DirectCast(GetValue(ChartForegroundProperty), Brush)
    End Get
    Set
      SetValue(ChartForegroundProperty, Value)
    End Set
  End Property
#End Region

#Region "LegendForeground"
  Public Shared ReadOnly LegendForegroundProperty As DependencyProperty = DependencyProperty.Register("LegendForeground", GetType(Brush), GetType(LineChart), New UIPropertyMetadata(Brushes.Black, AddressOf LineChart.ChartLegendTextChanged))

  Public Property LegendForeground As Brush
    Get
      Return DirectCast(GetValue(LegendForegroundProperty), Brush)
    End Get
    Set
      SetValue(LegendForegroundProperty, Value)
    End Set
  End Property

  Public Shared Sub ChartLegendTextChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim LC As LineChart = DirectCast(d, LineChart)
    LC.PART_LEGENDTEXT.Visibility = Visibility.Visible
  End Sub
#End Region

#Region "LegendHidden"
  Public Shared ReadOnly LegendHiddenProperty As DependencyProperty = DependencyProperty.Register("LegendHidden", GetType(Boolean), GetType(LineChart), New UIPropertyMetadata(False, AddressOf LineChart.ChartLegendHiddenChanged))

  Public Property LegendHidden As Boolean
    Get
      Return DirectCast(GetValue(LegendHiddenProperty), Boolean)
    End Get
    Set
      SetValue(LegendHiddenProperty, Value)
    End Set
  End Property

  Public Shared Sub ChartLegendHiddenChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim LC As LineChart = DirectCast(d, LineChart)

    If CBool(e.NewValue) Then
      LC.PART_LEGEND.Visibility = Visibility.Collapsed
      LC.PART_LEGENDTEXT.Visibility = Visibility.Collapsed
    Else
      LC.PART_LEGENDTEXT.Visibility = Visibility.Visible
      LC.PART_LEGEND.Visibility = Visibility.Visible
    End If

  End Sub
#End Region

#Region "ChartTitleHidden"
  Public Shared ReadOnly ChartTitleHiddenProperty As DependencyProperty = DependencyProperty.Register("ChartTitleHidden", GetType(Boolean), GetType(LineChart), New UIPropertyMetadata(False, AddressOf LineChart.ChartTitleHiddenChanged))

  Public Property ChartTitleHidden As Boolean
    Get
      Return DirectCast(GetValue(ChartTitleHiddenProperty), Boolean)
    End Get
    Set
      SetValue(ChartTitleHiddenProperty, Value)
    End Set
  End Property

  Public Shared Sub ChartTitleHiddenChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim LC As LineChart = DirectCast(d, LineChart)

    If CBool(e.NewValue) Then
      LC.PART_ChartTitle.Visibility = Visibility.Collapsed
    Else
      LC.PART_ChartTitle.Visibility = Visibility.Visible
    End If

  End Sub
#End Region

#Region "NumberOfTicks"
  Public Shared ReadOnly NumberOfTicksProperty As DependencyProperty = DependencyProperty.Register("NumberOfTicks", GetType(Integer), GetType(LineChart), New UIPropertyMetadata(0))

  Public Property NumberOfTicks As Integer
    Get
      Return DirectCast(GetValue(NumberOfTicksProperty), Integer)
    End Get
    Set
      SetValue(NumberOfTicksProperty, Value)
    End Set
  End Property
#End Region

#Region "XValueConverter"
  Public Shared ReadOnly XValueConverterProperty As DependencyProperty = DependencyProperty.Register("XValueConverter", GetType(IValueConverter), GetType(LineChart), Nothing)

  Public Property XValueConverter As IValueConverter
    Get
      Return CType(GetValue(XValueConverterProperty), IValueConverter)
    End Get
    Set
      SetValue(XValueConverterProperty, Value)
    End Set
  End Property
#End Region

#Region "YValueConverter"
  Public Shared ReadOnly YValueConverterProperty As DependencyProperty = DependencyProperty.Register("YValueConverter", GetType(IValueConverter), GetType(LineChart), Nothing)

  Public Property YValueConverter As IValueConverter
    Get
      Return CType(GetValue(YValueConverterProperty), IValueConverter)
    End Get
    Set
      SetValue(YValueConverterProperty, Value)
    End Set
  End Property
#End Region

#Region "FontType"
  Public Shared ReadOnly FontTypeProperty As DependencyProperty = DependencyProperty.Register("FontType", GetType(FontFamily), GetType(LineChart), Nothing)

  Public Property FontType As FontFamily
    Get
      Return CType(GetValue(FontTypeProperty), FontFamily)
    End Get
    Set
      SetValue(FontTypeProperty, Value)
    End Set
  End Property
#End Region
#End Region

#Region "DataChangedAndTimingEvents"

  Public Shared Sub ChartDataChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim LC As LineChart = DirectCast(d, LineChart)
    Dim chartData = TryCast(e.NewValue, ObservableCollectionContentNotifying(Of PlotTrend))

    AddHandler LC.ChartData.OnCollectionItemChanged, Sub(o As Object, ev As EventArgs) LC.CalculatePlotTrends()
    AddHandler LC.ChartData.CollectionChanged, Sub(o As Object, ev As EventArgs) LC.CalculatePlotTrends()
    AddHandler LC.Loaded, Sub() LC.ResizeAndPlotPoints(LC)
    AddHandler LC.SizeChanged, Sub() LC.Resized()
    AddHandler LC._timer.Tick, Sub() LC.OnTick(LC)
  End Sub

  Private Sub OnTick(lc As LineChart)
    _timer.Stop()
    lc.ResizeAndPlotPoints(lc)
  End Sub

  Private Sub Resized()
    _timer.Stop()
    _timer.Start()
  End Sub
#End Region

#Region "ResivingAndPlotPoints"
  Private Sub ResizeAndPlotPoints(lc As LineChart)
    SetupInternalHeightAndWidths()
    SetupHeightAndWidthsOfObjects()
    lc.CalculatePlotTrends()
  End Sub

  Private Sub SetupHeightAndWidthsOfObjects()
    PART_CanvasYAxisLabels.Height = _viewHeight
    PART_CanvasYAxisLabels.Width = _labelWidth
    PART_CanvasYAxisTicks.Height = _viewHeight
    PART_CanvasYAxisTicks.Width = _tickWidth

    PART_CanvasXAxisLabels.Height = _labelHeight
    PART_CanvasXAxisLabels.Width = _viewWidth
    PART_CanvasXAxisTicks.Height = _tickHeight
    PART_CanvasXAxisTicks.Width = _viewWidth

    PART_CanvasPoints.Height = _viewHeight
    PART_CanvasPoints.Width = _viewWidth
  End Sub

  Private Sub SetupInternalHeightAndWidths()
    Dim margin = 0.99

    'True for Height having a larger aspect, False for Width having a larger aspect.  I am setting a floor for 25, anything smaller and it looks like crap.
    Dim SetHeightOrWidth As Func(Of Integer, Boolean, Double) = Function(x, y)
                                                                  Dim val = If(y, ((x / Ratio) * margin), ((x * Ratio) * margin))
                                                                  Return If(val <= 25, 25, val)
                                                                End Function

    If Ratio > 1 Then
      _viewHeight = 1000
      _viewWidth = SetHeightOrWidth(1000, True)
      _tickHeight = 50
      _tickWidth = SetHeightOrWidth(50, True)
      _labelHeight = 30
      _labelWidth = SetHeightOrWidth(75, True)
    Else
      _viewHeight = SetHeightOrWidth(1000, False)
      _viewWidth = 1000
      _tickHeight = SetHeightOrWidth(50, False)
      _tickWidth = 50
      _labelHeight = SetHeightOrWidth(30, False)
      _labelWidth = 75
    End If

  End Sub

  Public Sub CalculatePlotTrends()
    If Me.PART_CanvasPoints IsNot Nothing AndAlso ChartData IsNot Nothing Then
      If ChartData.Count > 1 Then

        'Uniformity check of X and Y types.  EG: You cannot have a DateTime and a Number for different X axis or Y axis sets.
        If ChartData.ToList().Select(Function(x) x.Points(0).X.GetType).Distinct.GroupBy(Function(x) x).Count > 1 Or ChartData.ToList().Select(Function(x) x.Points(0).Y.GetType).Distinct.GroupBy(Function(x) x).Count > 1 Then
          Me.PART_CanvasPoints.LayoutTransform = New ScaleTransform(1, 1)
          Me.PART_CanvasPoints.UpdateLayout()
          Dim fontFamily = If(Me.FontType IsNot Nothing, Me.FontType, New FontFamily("Segoe UI"))
          Dim stackPanel = New StackPanel
          stackPanel.Children.Add(New TextBlock With {.Text = "Type Mismatch cannot render!", .FontSize = 54, .FontFamily = fontFamily})
          stackPanel.Children.Add(New TextBlock With {.Text = "Either the X or Y plot points are of different types.", .FontSize = 32, .FontFamily = fontFamily})
          Me.PART_CanvasPoints.Children.Add(stackPanel)
          Return
        End If
      End If

      Me._xFloor = ChartData.SelectMany(Function(x) x.Points).Select(Function(x) x.XAsDouble).OrderBy(Function(x) x).FirstOrDefault()
      Me._xCeiling = ChartData.SelectMany(Function(x) x.Points).Select(Function(x) x.XAsDouble).OrderByDescending(Function(x) x).FirstOrDefault()
      Me._yFloor = ChartData.SelectMany(Function(x) x.Points).Select(Function(x) x.YAsDouble).OrderBy(Function(x) x).FirstOrDefault()
      Me._yCeiling = ChartData.SelectMany(Function(x) x.Points).Select(Function(x) x.YAsDouble).OrderByDescending(Function(x) x).FirstOrDefault()

      Me.PART_CanvasPoints.Children.RemoveRange(0, Me.PART_CanvasPoints.Children.Count)
      Me.DrawTrends(ChartData)

      If Me.PART_CanvasXAxisTicks IsNot Nothing And Me.PART_CanvasYAxisTicks IsNot Nothing Then
        If Me.NumberOfTicks = 0 Then Me.NumberOfTicks = 1 'I want at the very least to see a beginning and an end
        Me.DrawXAxis(ChartData)
        Me.DrawYAxis(ChartData)
      End If
    End If
  End Sub
#End Region

#Region "Drawing Methods"
  Public Sub DrawXAxis(lineTrends As IList(Of PlotTrend))
    Dim segment = ((_xCeiling - _xFloor) / NumberOfTicks)
    PART_CanvasXAxisTicks.Children.RemoveRange(0, PART_CanvasXAxisTicks.Children.Count)
    PART_CanvasXAxisLabels.Children.RemoveRange(0, PART_CanvasXAxisLabels.Children.Count)

    PART_CanvasXAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = _viewWidth,
                                   .Y1 = 0,
                                   .Y2 = 0,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })

    'Sizing should be done from the ceiling
    Dim lastText = New String(If(XValueConverter Is Nothing, _xCeiling.ToString, XValueConverter.Convert(_xCeiling, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)))
    Dim spacingForText = lastText.Count * 6
    Dim totalLength = spacingForText * NumberOfTicks
    Dim fontSize = 0
    Dim finalSpacing = 0
    Dim lastSpaceFactor = 0

    Select Case totalLength
      Case <= 200
        fontSize = 30
        finalSpacing = spacingForText * 1.2
        lastSpaceFactor = finalSpacing * 2
      Case <= 250
        fontSize = 20
        finalSpacing = spacingForText * 0.9
        lastSpaceFactor = finalSpacing * 1.75
      Case <= 500
        fontSize = 16
        finalSpacing = spacingForText * 0.6
        lastSpaceFactor = finalSpacing * 2
      Case <= 750
        fontSize = 12
        finalSpacing = spacingForText * 0.45
        lastSpaceFactor = finalSpacing * 1.8
      Case Else
        fontSize = 8
        finalSpacing = spacingForText * 0.3
        lastSpaceFactor = finalSpacing * 2
    End Select

    For i As Integer = 0 To NumberOfTicks
      Dim xSegment = If(i = 0, 0, i * (_viewWidth / NumberOfTicks))
      Dim xSegmentLabel = If(i = 0, _xFloor, _xFloor + (i * segment))
      Dim textForLabel = New String(If(XValueConverter Is Nothing, xSegmentLabel.ToString, XValueConverter.Convert(xSegmentLabel, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)))

      Dim lineSegment = New Line With {
          .X1 = xSegment,
          .X2 = xSegment,
          .Y1 = 0,
          .Y2 = _labelHeight,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      PART_CanvasXAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = textForLabel,
        .FontSize = fontSize,
        .Margin = New Thickness(xSegment - If(i = 0, 0, If(i = NumberOfTicks, lastSpaceFactor, finalSpacing)), 0, 0, 0)
      }

      PART_CanvasXAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Public Sub DrawYAxis(lineTrends As IList(Of PlotTrend))
    Dim segment = ((_yCeiling - _yFloor) / NumberOfTicks)
    PART_CanvasYAxisTicks.Children.RemoveRange(0, PART_CanvasYAxisTicks.Children.Count)
    PART_CanvasYAxisLabels.Children.RemoveRange(0, PART_CanvasYAxisLabels.Children.Count)

    PART_CanvasYAxisTicks.Children.Add(New Line With {
                                   .X1 = 0,
                                   .X2 = 0,
                                   .Y1 = 0,
                                   .Y2 = _viewHeight,
                                   .StrokeThickness = 2,
                                   .Stroke = Brushes.Black
                                   })


    'Sizing should be done from the ceiling
    Dim lastText = New String(If(YValueConverter Is Nothing, _yCeiling.ToString, YValueConverter.Convert(_yCeiling, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)))
    Dim spacingForText = lastText.Count * 5
    Dim totalLength = spacingForText * NumberOfTicks
    Dim fontSize = 0
    Dim finalSpacing = 0
    Dim lastSpaceFactor = 0

    Select Case totalLength
      Case <= 200
        fontSize = 30
        finalSpacing = spacingForText * 0.5
        lastSpaceFactor = finalSpacing * 1.9
      Case <= 250
        fontSize = 20
        finalSpacing = spacingForText * 0.5
        lastSpaceFactor = finalSpacing * 1.5
      Case Else
        fontSize = 16
        finalSpacing = spacingForText * 0.25
        lastSpaceFactor = finalSpacing * 1
    End Select

    For i As Integer = 0 To NumberOfTicks
      Dim ySegment = If(i = 0, 0, i * (_viewHeight / NumberOfTicks))
      Dim ySegmentLabel = If(i = 0, _yFloor, _yFloor + (i * segment))
      Dim textForLabel = New String(If(YValueConverter Is Nothing, ySegmentLabel.ToString, YValueConverter.Convert(ySegmentLabel, GetType(String), Nothing, Globalization.CultureInfo.InvariantCulture)))

      Dim lineSegment = New Line With {
          .X1 = 0,
          .X2 = _labelHeight,
          .Y1 = ySegment,
          .Y2 = ySegment,
          .StrokeThickness = 2,
          .Stroke = Brushes.Black}
      PART_CanvasYAxisTicks.Children.Add(lineSegment)

      Dim labelSegment = New TextBlock With {
        .Text = textForLabel,
        .FontSize = fontSize,
        .Margin = New Thickness(0, _viewHeight - 20 - (ySegment - If(i = 0, 0, If(i = NumberOfTicks, lastSpaceFactor, finalSpacing))), 0, 0)
      }

      PART_CanvasYAxisLabels.Children.Add(labelSegment)
    Next
  End Sub

  Friend Sub DrawTrends(points As IList(Of PlotTrend))

    For Each t In ChartData
      If t.Points IsNot Nothing Then
        Dim xFactor = (_viewWidth / (_xCeiling - _xFloor))
        Dim yFactor = (_viewHeight / (_yCeiling - _yFloor))

        For i As Integer = 1 To t.Points.Count - 1
          Dim toDraw = New Line With {
            .X1 = (t.Points(i - 1).XAsDouble - _xFloor) * xFactor,
            .Y1 = (t.Points(i - 1).YAsDouble - _yFloor) * yFactor,
            .X2 = (t.Points(i).XAsDouble - _xFloor) * xFactor,
            .Y2 = (t.Points(i).YAsDouble - _yFloor) * yFactor,
            .StrokeThickness = 2,
            .Stroke = t.LineColor}
          PART_CanvasPoints.Children.Add(toDraw)
        Next i
      End If
    Next


  End Sub
#End Region

End Class