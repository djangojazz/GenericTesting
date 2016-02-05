Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Collections.Generic
Imports Microsoft.Maps.MapControl.WPF

Partial Public Class MapEvents
    Inherits Window

    ' A collection of key/value pairs containing the event name 
    ' and the text block to display the event to.
    Private eventBlocks As New Dictionary(Of String, TextBlock)()
  ' A collection of key/value pairs containing the event name  
  ' and the number of times the event fired.
  Private eventCount As New Dictionary(Of String, Integer)()

  Private _previousZoom As Integer

  Public Sub New()
    InitializeComponent()

    ' Set focus on map
    MapWithEvents.Focus()

    ' Fires every animated frame from one location to another.
    AddHandler MapWithEvents.ViewChangeOnFrame, AddressOf MapWithEvents_ViewChangeOnFrame
    ' Fires when the map view location has changed.
    AddHandler MapWithEvents.TargetViewChanged, AddressOf MapWithEvents_TargetViewChanged
    ' Fires when the map view starts to move to its new target view.
    AddHandler MapWithEvents.ViewChangeStart, AddressOf MapWithEvents_ViewChangeStart
    ' Fires when the map view has reached its new target view.
    AddHandler MapWithEvents.ViewChangeEnd, AddressOf MapWithEvents_ViewChangeEnd
    ' Fires when a different mode button on the navigation bar is selected.
    AddHandler MapWithEvents.ModeChanged, AddressOf MapWithEvents_ModeChanged
    ' Fires when the mouse is double clicked
    AddHandler MapWithEvents.MouseDoubleClick, AddressOf MapWithEvents_MouseDoubleClick
    ' Fires when the mouse wheel is used to scroll the map
    AddHandler MapWithEvents.MouseWheel, AddressOf MapWithEvents_MouseWheel
    ' Fires when the left mouse button is depressed
    AddHandler MapWithEvents.MouseLeftButtonDown, AddressOf MapWithEvents_MouseLeftButtonDown
    ' Fires when the left mouse button is released
    AddHandler MapWithEvents.MouseLeftButtonUp, AddressOf MapWithEvents_MouseLeftButtonUp
  End Sub

  Private Sub MapWithEvents_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseEventArgs)
    ' Updates the count of single mouse clicks.
    ShowEvent("MapWithEvents_MouseLeftButtonUp")
  End Sub


  Private Sub MapWithEvents_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
    ' Updates the count of mouse drag boxes created.
    ShowEvent("MapWithEvents_MouseWheel")
  End Sub

  Private Sub MapWithEvents_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    ' Updates the count of mouse pans.
    ShowEvent("MapWithEvents_MouseLeftButtonDown")
  End Sub

  Private Sub MapWithEvents_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    ' Updates the count of mouse double clicks.
    ShowEvent("MapWithEvents_MouseDoubleClick")
  End Sub

  Private Sub MapWithEvents_ViewChangeEnd(ByVal sender As Object, ByVal e As MapEventArgs)
    'Updates the number of times the map view has changed.
    ShowEvent("ViewChangeEnd")
  End Sub

  Private Sub MapWithEvents_ViewChangeStart(ByVal sender As Object, ByVal e As MapEventArgs)
    'Updates the number of times the map view started changing.
    ShowEvent("ViewChangeStart")
  End Sub

  Private Sub MapWithEvents_ViewChangeOnFrame(ByVal sender As Object, ByVal e As MapEventArgs)
    ' Updates the number of times a map view has changed 
    ' during an animation from one location to another.
    ShowEvent("ViewChangeOnFrame")
  End Sub
  Private Sub MapWithEvents_TargetViewChanged(ByVal sender As Object, ByVal e As MapEventArgs)
    ' Updates the number of map view changes that occured during
    ' a zoom or pan.
    Dim zm = CInt(MapWithEvents.TargetZoomLevel)
    If (_previousZoom <> zm) Then
      _previousZoom = MapWithEvents.TargetZoomLevel
      ShowEvent("TargetViewChange")
    End If



  End Sub

  Private Sub MapWithEvents_ModeChanged(ByVal sender As Object, ByVal e As MapEventArgs)
      ' Updates the number of times the map mode changed.
      ShowEvent("ModeChanged")
    End Sub

    Private Sub ShowEvent(ByVal eventName As String)
      ' Updates the display box showing the number of times 
      ' the wired events occured.
      If Not eventBlocks.ContainsKey(eventName) Then
        Dim tb As New TextBlock()
        tb.Foreground = New SolidColorBrush(Color.FromArgb(255, 128, 255, 128))
        tb.Margin = New Thickness(5)
        eventBlocks.Add(eventName, tb)
        eventCount.Add(eventName, 0)
        eventsPanel.Children.Add(tb)
      End If

      eventCount(eventName) += 1
      eventBlocks(eventName).Text = String.Format("{0}: [{1} times] {2} (HH:mm:ss:ffff)", eventName, eventCount(eventName).ToString(), Date.Now.ToString())
    End Sub

End Class