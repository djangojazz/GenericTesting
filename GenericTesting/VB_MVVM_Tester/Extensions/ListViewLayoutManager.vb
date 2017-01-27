Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.ComponentModel

Public Class ListViewLayoutManager
    'VARIABLES
    Private scrollViewer As ScrollViewer
    Private loaded As Boolean = False
    Private resizing As Boolean = False
    Private resizeCursor As Cursor
    Private _VerticalScrollBarVisibility As ScrollBarVisibility = ScrollBarVisibility.Auto
    Private autoSizedColumn As GridViewColumn

    'PROPERTIES
    Public Shared ReadOnly EnabledProperty As DependencyProperty = DependencyProperty.RegisterAttached("Enabled", GetType(Boolean), GetType(ListViewLayoutManager), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnLayoutManagerEnabledChanged)))

    'CONSTRUCTOR
    Public Sub New(ByVal listView As Controls.ListView)
      If listView Is Nothing Then Throw New ArgumentNullException("listView")

      Me._ListView = listView
      AddHandler Me._ListView.Loaded, AddressOf ListViewLoaded
      AddHandler Me._ListView.Unloaded, AddressOf ListViewUnloaded
    End Sub

    Private ReadOnly _ListView As Controls.ListView
    Public ReadOnly Property ListView() As Controls.ListView
      Get
        Return Me._ListView
      End Get
    End Property

    Public Property VerticalScrollBarVisibility() As ScrollBarVisibility
      Get
        Return Me._VerticalScrollBarVisibility
      End Get
      Set(ByVal value As ScrollBarVisibility)
        Me._VerticalScrollBarVisibility = value
      End Set
    End Property

    Public Shared Sub SetEnabled(ByVal dependencyObject As DependencyObject, ByVal enabled As Boolean)
      dependencyObject.SetValue(EnabledProperty, enabled)
    End Sub

    Private Sub RegisterEvents(ByVal start As DependencyObject)
      For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(start) - 1
        Dim childVisual As Visual = TryCast(VisualTreeHelper.GetChild(start, i), Visual)
        If TypeOf childVisual Is Thumb Then
          Dim gridViewColumn__1 As GridViewColumn = FindParentColumn(childVisual)
          If gridViewColumn__1 Is Nothing Then
            Continue For
          End If

          Dim thumb As Thumb = TryCast(childVisual, Thumb)
          AddHandler thumb.PreviewMouseMove, AddressOf ThumbPreviewMouseMove
          AddHandler thumb.PreviewMouseLeftButtonDown, AddressOf ThumbPreviewMouseLeftButtonDown
          DependencyPropertyDescriptor.FromProperty(GridViewColumn.WidthProperty, GetType(GridViewColumn)).AddValueChanged(gridViewColumn__1, AddressOf GridColumnWidthChanged)
        ElseIf TypeOf childVisual Is GridViewColumnHeader Then
          Dim columnHeader As GridViewColumnHeader = TryCast(childVisual, GridViewColumnHeader)
          AddHandler columnHeader.SizeChanged, AddressOf GridColumnHeaderSizeChanged
        ElseIf Me.scrollViewer Is Nothing AndAlso TypeOf childVisual Is ScrollViewer Then
          Me.scrollViewer = TryCast(childVisual, ScrollViewer)
          AddHandler Me.scrollViewer.ScrollChanged, AddressOf ScrollViewerScrollChanged
          ' assume we do the regulation of the horizontal scrollbar
          Me.scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden
          Me.scrollViewer.VerticalScrollBarVisibility = Me._VerticalScrollBarVisibility
        End If

        ' recursive
        RegisterEvents(childVisual)
      Next
    End Sub

    Private Sub UnregisterEvents(ByVal start As DependencyObject)
      For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(start) - 1
        Dim childVisual As Visual = TryCast(VisualTreeHelper.GetChild(start, i), Visual)
        If TypeOf childVisual Is Thumb Then
          Dim gridViewColumn__1 As GridViewColumn = FindParentColumn(childVisual)
          If gridViewColumn__1 Is Nothing Then
            Continue For
          End If

          Dim thumb As Thumb = TryCast(childVisual, Thumb)
          RemoveHandler thumb.PreviewMouseMove, AddressOf ThumbPreviewMouseMove
          RemoveHandler thumb.PreviewMouseLeftButtonDown, AddressOf ThumbPreviewMouseLeftButtonDown
          DependencyPropertyDescriptor.FromProperty(GridViewColumn.WidthProperty, GetType(GridViewColumn)).RemoveValueChanged(gridViewColumn__1, AddressOf GridColumnWidthChanged)
        ElseIf TypeOf childVisual Is GridViewColumnHeader Then
          Dim columnHeader As GridViewColumnHeader = TryCast(childVisual, GridViewColumnHeader)
          RemoveHandler columnHeader.SizeChanged, AddressOf GridColumnHeaderSizeChanged
        ElseIf Me.scrollViewer Is Nothing AndAlso TypeOf childVisual Is ScrollViewer Then
          Me.scrollViewer = TryCast(childVisual, ScrollViewer)
          RemoveHandler Me.scrollViewer.ScrollChanged, AddressOf ScrollViewerScrollChanged
        End If

        ' recursive
        UnregisterEvents(childVisual)
      Next
    End Sub

    Private Function FindParentColumn(ByVal element As DependencyObject) As GridViewColumn
      If element Is Nothing Then
        Return Nothing
      End If

      While element IsNot Nothing
        If TypeOf element Is GridViewColumnHeader Then
          Return DirectCast(element, GridViewColumnHeader).Column
        End If
        element = VisualTreeHelper.GetParent(element)
      End While

      Return Nothing
    End Function

    Private Function FindColumnHeader(ByVal start As DependencyObject, ByVal gridViewColumn As GridViewColumn) As GridViewColumnHeader
      For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(start) - 1
        Dim childVisual As Visual = TryCast(VisualTreeHelper.GetChild(start, i), Visual)
        If TypeOf childVisual Is GridViewColumnHeader Then
          Dim gridViewHeader As GridViewColumnHeader = TryCast(childVisual, GridViewColumnHeader)
          If gridViewHeader IsNot Nothing AndAlso gridViewHeader.Column Is gridViewColumn Then
            Return gridViewHeader
          End If
        End If
        Dim childGridViewHeader As GridViewColumnHeader = FindColumnHeader(childVisual, gridViewColumn)
        ' recursive
        If childGridViewHeader IsNot Nothing Then
          Return childGridViewHeader
        End If
      Next
      Return Nothing
    End Function

    Private Sub InitColumns()
      Dim view As GridView = TryCast(Me._ListView.View, GridView)
      If view Is Nothing Then
        Exit Sub
      End If

      For Each gridViewColumn As GridViewColumn In view.Columns
        If Not RangeColumn.IsRangeColumn(gridViewColumn) Then
          Continue For
        End If

        Dim minWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMinWidth(gridViewColumn)
        Dim maxWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMaxWidth(gridViewColumn)
        If Not minWidth.HasValue AndAlso Not maxWidth.HasValue Then
          Continue For
        End If

        Dim columnHeader As GridViewColumnHeader = FindColumnHeader(Me._ListView, gridViewColumn)
        If columnHeader Is Nothing Then
          Continue For
        End If

        Dim actualWidth As Double = columnHeader.ActualWidth
        If minWidth.HasValue Then
          columnHeader.MinWidth = minWidth.Value
          If Not Double.IsInfinity(actualWidth) AndAlso actualWidth < columnHeader.MinWidth Then
            gridViewColumn.Width = columnHeader.MinWidth
          End If
        End If
        If maxWidth.HasValue Then
          columnHeader.MaxWidth = maxWidth.Value
          If Not Double.IsInfinity(actualWidth) AndAlso actualWidth > columnHeader.MaxWidth Then
            gridViewColumn.Width = columnHeader.MaxWidth
          End If
        End If
      Next
    End Sub

    Protected Overridable Sub ResizeColumns()
      Dim view As GridView = TryCast(Me._ListView.View, GridView)
      If view Is Nothing OrElse view.Columns.Count = 0 Then
        Exit Sub
      End If

      ' listview width
      Dim actualWidth As Double = Double.PositiveInfinity
      If Me.scrollViewer IsNot Nothing Then
        actualWidth = Me.scrollViewer.ViewportWidth
      End If
      If Double.IsInfinity(actualWidth) Then
        actualWidth = Me._ListView.ActualWidth
      End If
      If Double.IsInfinity(actualWidth) OrElse actualWidth <= 0 Then
        Exit Sub
      End If

      Dim resizeableRegionCount As Double = 0
      Dim otherColumnsWidth As Double = 0
      ' determine column sizes
      For Each gridViewColumn As GridViewColumn In view.Columns
        If ProportionalColumn.IsProportionalColumn(gridViewColumn) Then
          resizeableRegionCount += ProportionalColumn.GetProportionalWidth(gridViewColumn).Value
        Else
          otherColumnsWidth += gridViewColumn.ActualWidth
        End If
      Next

      If resizeableRegionCount <= 0 Then
        ' no proportional columns present: commit the regulation to the scroll viewer
        Me.scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto

        ' search the first fill column
        Dim fillColumn As GridViewColumn = Nothing
        For i As Integer = 0 To view.Columns.Count - 1
          Dim gridViewColumn As GridViewColumn = view.Columns(i)
          If IsFillColumn(gridViewColumn) Then
            fillColumn = gridViewColumn
            Exit For
          End If
        Next

        If fillColumn IsNot Nothing Then
          Dim otherColumnsWithoutFillWidth As Double = otherColumnsWidth - fillColumn.ActualWidth
          Dim fillWidth As Double = actualWidth - otherColumnsWithoutFillWidth
          If fillWidth > 0 Then
            Dim minWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMinWidth(fillColumn)
            Dim maxWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMaxWidth(fillColumn)

            Dim setWidth As Boolean = True
            If minWidth.HasValue AndAlso fillWidth < minWidth.Value Then
              setWidth = False
            End If
            If maxWidth.HasValue AndAlso fillWidth > maxWidth.Value Then
              setWidth = False
            End If
            If setWidth Then
              Me.scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden
              fillColumn.Width = fillWidth
            End If
          End If
        End If
        Exit Sub
      End If

      Dim resizeableColumnsWidth As Double = actualWidth - otherColumnsWidth
      If resizeableColumnsWidth <= 0 Then
        ' missing space
        Exit Sub
      End If

      ' resize columns
      Dim resizeableRegionWidth As Double = resizeableColumnsWidth / resizeableRegionCount
      For Each gridViewColumn As GridViewColumn In view.Columns
        If ProportionalColumn.IsProportionalColumn(gridViewColumn) Then
          gridViewColumn.Width = ProportionalColumn.GetProportionalWidth(gridViewColumn).Value * resizeableRegionWidth
        End If
      Next
    End Sub

    Private Function SetRangeColumnToBounds(ByVal gridViewColumn As GridViewColumn) As Double
      Dim startWidth As Double = gridViewColumn.Width

      Dim minWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMinWidth(gridViewColumn)
      Dim maxWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMaxWidth(gridViewColumn)

      If (minWidth.HasValue AndAlso maxWidth.HasValue) AndAlso (minWidth > maxWidth) Then
        ' invalid case
        Return 0
      End If

      If minWidth.HasValue AndAlso gridViewColumn.Width < minWidth.Value Then
        gridViewColumn.Width = minWidth.Value
      ElseIf maxWidth.HasValue AndAlso gridViewColumn.Width > maxWidth.Value Then
        gridViewColumn.Width = maxWidth.Value
      End If

      Return gridViewColumn.Width - startWidth
    End Function

    Private Function IsFillColumn(ByVal gridViewColumn As GridViewColumn) As Boolean
      If gridViewColumn Is Nothing Then
        Return False
      End If

      Dim view As GridView = TryCast(Me._ListView.View, GridView)
      If view Is Nothing OrElse view.Columns.Count = 0 Then
        Return False
      End If

      Dim isFillCoumn As System.Nullable(Of Boolean) = RangeColumn.GetRangeIsFillColumn(gridViewColumn)
      Return isFillCoumn.HasValue AndAlso isFillCoumn.Value = True
    End Function

    Private Sub DoResizeColumns()
      If Me.resizing Then
        Exit Sub
      End If

      Me.resizing = True
      Try
        ResizeColumns()
      Catch
        Throw
      Finally
        Me.resizing = False
      End Try
    End Sub

    Private Sub ListViewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
      RegisterEvents(Me._ListView)
      InitColumns()
      DoResizeColumns()
      Me.loaded = True
    End Sub

    Private Sub ListViewUnloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
      If Not Me.loaded Then
        Exit Sub
      End If
      UnregisterEvents(Me._ListView)
      Me.loaded = False
    End Sub

    Private Sub ThumbPreviewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim thumb As Thumb = TryCast(sender, Thumb)
      Dim gridViewColumn As GridViewColumn = FindParentColumn(thumb)
      If gridViewColumn Is Nothing Then
        Exit Sub
      End If

      ' suppress column resizing for proportional, fixed and range fill columns
      If ProportionalColumn.IsProportionalColumn(gridViewColumn) OrElse FixedColumn.IsFixedColumn(gridViewColumn) OrElse IsFillColumn(gridViewColumn) Then
        thumb.Cursor = Nothing
        Exit Sub
      End If

      ' check range column bounds
      If thumb.IsMouseCaptured AndAlso RangeColumn.IsRangeColumn(gridViewColumn) Then
        Dim minWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMinWidth(gridViewColumn)
        Dim maxWidth As System.Nullable(Of Double) = RangeColumn.GetRangeMaxWidth(gridViewColumn)

        If (minWidth.HasValue AndAlso maxWidth.HasValue) AndAlso (minWidth > maxWidth) Then
          ' invalid case
          Exit Sub
        End If

        If Me.resizeCursor Is Nothing Then
          ' save the resize cursor
          Me.resizeCursor = thumb.Cursor
        End If

        If minWidth.HasValue AndAlso gridViewColumn.Width <= minWidth.Value Then
          thumb.Cursor = Cursors.No
        ElseIf maxWidth.HasValue AndAlso gridViewColumn.Width >= maxWidth.Value Then
          thumb.Cursor = Cursors.No
        Else
          ' between valid min/max
          thumb.Cursor = Me.resizeCursor
        End If
      End If
    End Sub

    Private Sub ThumbPreviewMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
      Dim thumb As Thumb = TryCast(sender, Thumb)
      Dim gridViewColumn As GridViewColumn = FindParentColumn(thumb)

      ' suppress column resizing for proportional, fixed and range fill columns
      If ProportionalColumn.IsProportionalColumn(gridViewColumn) OrElse FixedColumn.IsFixedColumn(gridViewColumn) OrElse IsFillColumn(gridViewColumn) Then
        e.Handled = True
        Exit Sub
      End If
    End Sub

    Private Sub GridColumnWidthChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Not Me.loaded Then
        Exit Sub
      End If

      Dim gridViewColumn As GridViewColumn = TryCast(sender, GridViewColumn)

      ' suppress column resizing for proportional and fixed columns
      If ProportionalColumn.IsProportionalColumn(gridViewColumn) OrElse FixedColumn.IsFixedColumn(gridViewColumn) Then
        Exit Sub
      End If

      ' ensure range column within the bounds
      If RangeColumn.IsRangeColumn(gridViewColumn) Then
        ' special case: auto column width - maybe conflicts with min/max range
        If gridViewColumn.Width.Equals(Double.NaN) Then
          Me.autoSizedColumn = gridViewColumn
          ' handled by the change header size event
          Exit Sub
        End If

        ' ensure column bounds
        If SetRangeColumnToBounds(gridViewColumn) <> 0 Then
          Exit Sub
        End If
      End If

      DoResizeColumns()
    End Sub

    Private Sub GridColumnHeaderSizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
      If Me.autoSizedColumn Is Nothing Then
        Exit Sub
      End If

      Dim gridViewColumnHeader As GridViewColumnHeader = TryCast(sender, GridViewColumnHeader)
      If gridViewColumnHeader.Column Is Me.autoSizedColumn Then
        If gridViewColumnHeader.Width.Equals(Double.NaN) Then
          ' sync column with 
          gridViewColumnHeader.Column.Width = gridViewColumnHeader.ActualWidth
          DoResizeColumns()
        End If

        Me.autoSizedColumn = Nothing
      End If
    End Sub

    Private Sub ScrollViewerScrollChanged(ByVal sender As Object, ByVal e As ScrollChangedEventArgs)
      If Me.loaded AndAlso e.ViewportWidthChange <> 0 Then
        DoResizeColumns()
      End If
    End Sub

    Private Shared Sub OnLayoutManagerEnabledChanged(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
      Dim listView As Controls.ListView = TryCast(dependencyObject, Controls.ListView)
      If listView IsNot Nothing Then
        Dim enabled As Boolean = CBool(e.NewValue)
        If enabled Then
          Dim o As New ListViewLayoutManager(listView)
          'new ListViewLayoutManager(listView)
        End If
      End If
    End Sub

End Class