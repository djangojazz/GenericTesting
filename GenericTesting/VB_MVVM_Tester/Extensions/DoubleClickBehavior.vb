Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows
Imports System.Windows.Media
Imports Prism.Interactivity

Public Class DoubleClickBehavior
    Inherits CommandBehaviorBase(Of Controls.ListView)

    Public ClickedItem As ListViewItem

    Public Sub New(ByVal Element As Controls.ListView)
      MyBase.New(Element)

      AddHandler Element.MouseDoubleClick, AddressOf Element_DoubleClicked
    End Sub

    Public Sub Element_DoubleClicked(ByVal Sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
      MyBase.ExecuteCommand(Nothing)

      Dim dep As DependencyObject = CType(e.OriginalSource, DependencyObject)
      Do While dep IsNot Nothing AndAlso Not TypeOf (dep) Is ListViewItem
        dep = VisualTreeHelper.GetParent(dep)
      Loop
      ClickedItem = DirectCast(dep, ListViewItem)
    End Sub

  End Class


Public NotInheritable Class DoubleClick

  'DEPENDENCY PROPERTIES
  ' Using a DependencyProperty as the backing store for Command. This enables animation, styling, binding, etc... 
  Public Shared ReadOnly CommandProperty As DependencyProperty = DependencyProperty.RegisterAttached("Command", GetType(ICommand), GetType(DoubleClick), New PropertyMetadata(AddressOf OnSetCommandCallback))
  Public Shared ReadOnly CommandParameterProperty As DependencyProperty = DependencyProperty.RegisterAttached("CommandParameter", GetType(Object), GetType(DoubleClick), New PropertyMetadata(AddressOf OnSetCommandParameterCallback))
  Public Shared ReadOnly DoubleClickBehaviorProperty As DependencyProperty = DependencyProperty.RegisterAttached("SelectedIndexChangedBehavior", GetType(DoubleClickBehavior), GetType(DoubleClick), Nothing)


  'METHODS
  Private Shared Function GetOrCreateBehavior(ByVal element As Controls.ListView) As DoubleClickBehavior
    Dim behavior As DoubleClickBehavior = TryCast(element.GetValue(DoubleClickBehaviorProperty), DoubleClickBehavior)
    If behavior Is Nothing Then
      behavior = New DoubleClickBehavior(element)
      element.SetValue(DoubleClickBehaviorProperty, behavior)
    End If
    Return behavior
  End Function

  Private Shared Sub OnSetCommandCallback(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
    Dim element As Controls.ListView = TryCast(dependencyObject, Controls.ListView)
    If element IsNot Nothing Then
      Dim behavior As DoubleClickBehavior = GetOrCreateBehavior(element)
      behavior.Command = TryCast(e.NewValue, ICommand)
    End If
  End Sub

  Private Shared Sub OnSetCommandParameterCallback(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
    Dim element As Controls.ListView = TryCast(dependencyObject, Controls.ListView)
    If element IsNot Nothing Then
      Dim behavior As DoubleClickBehavior = GetOrCreateBehavior(element)
      behavior.CommandParameter = e.NewValue
    End If
  End Sub

  Public Shared Function GetCommand(ByVal obj As DependencyObject) As ICommand
    Return DirectCast(obj.GetValue(CommandProperty), ICommand)
  End Function

  Public Shared Sub SetCommand(ByVal obj As DependencyObject, ByVal value As ICommand)
    obj.SetValue(CommandProperty, value)
  End Sub

  Public Shared Function GetCommandParameter(ByVal Element As Controls.ListView) As Object
    Return Element.GetValue(CommandParameterProperty)
  End Function

  Public Shared Sub SetCommandParameter(ByVal Element As Controls.ListView, ByVal parameter As Object)
    Element.SetValue(CommandParameterProperty, parameter)
  End Sub

  Public Shared Function GetDoubleClickBehavior(ByVal obj As DependencyObject) As DoubleClickBehavior
    Return DirectCast(obj.GetValue(DoubleClickBehaviorProperty), DoubleClickBehavior)
  End Function

  Public Shared Sub SetDoubleClickBehavior(ByVal obj As DependencyObject, ByVal value As DoubleClickBehavior)
    obj.SetValue(DoubleClickBehaviorProperty, value)
  End Sub

End Class
