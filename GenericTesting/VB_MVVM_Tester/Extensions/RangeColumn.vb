Imports System
Imports System.Windows
Imports System.Windows.Controls

Public NotInheritable Class RangeColumn
    Inherits LayoutColumn

    'CONSTRUCTOR STATIC CLASS
    Private Sub New()
    End Sub


    'PROPERTIES
    Public Shared ReadOnly MinWidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("MinWidth", GetType(Double), GetType(RangeColumn))

    Public Shared ReadOnly MaxWidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("MaxWidth", GetType(Double), GetType(RangeColumn))

    Public Shared ReadOnly IsFillColumnProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsFillColumn", GetType(Boolean), GetType(RangeColumn))


    'METHODS
    Public Shared Function GetMinWidth(ByVal obj As DependencyObject) As Double
      Return CDbl(obj.GetValue(MinWidthProperty))
    End Function

    Public Shared Sub SetMinWidth(ByVal obj As DependencyObject, ByVal minWidth As Double)
      obj.SetValue(MinWidthProperty, minWidth)
    End Sub


    Public Shared Function GetMaxWidth(ByVal obj As DependencyObject) As Double
      Return CDbl(obj.GetValue(MaxWidthProperty))
    End Function

    Public Shared Sub SetMaxWidth(ByVal obj As DependencyObject, ByVal maxWidth As Double)
      obj.SetValue(MaxWidthProperty, maxWidth)
    End Sub

    Public Shared Function GetIsFillColumn(ByVal obj As DependencyObject) As Boolean
      Return CBool(obj.GetValue(IsFillColumnProperty))
    End Function

    Public Shared Sub SetIsFillColumn(ByVal obj As DependencyObject, ByVal isFillColumn As Boolean)
      obj.SetValue(IsFillColumnProperty, isFillColumn)
    End Sub

    Public Shared Function IsRangeColumn(ByVal column As GridViewColumn) As Boolean
      If column Is Nothing Then
        Return False
      End If
      Return HasPropertyValue(column, MinWidthProperty) OrElse HasPropertyValue(column, MaxWidthProperty) OrElse HasPropertyValue(column, IsFillColumnProperty)
    End Function

    Public Shared Function GetRangeMinWidth(ByVal column As GridViewColumn) As System.Nullable(Of Double)
      Return GetColumnWidth(column, MinWidthProperty)
    End Function

    Public Shared Function GetRangeMaxWidth(ByVal column As GridViewColumn) As System.Nullable(Of Double)
      Return GetColumnWidth(column, MaxWidthProperty)
    End Function

    Public Shared Function GetRangeIsFillColumn(ByVal column As GridViewColumn) As System.Nullable(Of Boolean)
      If column Is Nothing Then
        Throw New ArgumentNullException("column")
      End If
      Dim value As Object = column.ReadLocalValue(IsFillColumnProperty)
      If value IsNot Nothing AndAlso value.GetType() Is IsFillColumnProperty.PropertyType Then
        Return CBool(value)
      End If

      Return Nothing
    End Function

    Public Shared Function ApplyWidth(ByVal gridViewColumn As GridViewColumn, ByVal minWidth As Double, ByVal width As Double, ByVal maxWidth As Double) As GridViewColumn
      Return ApplyWidth(gridViewColumn, minWidth, width, maxWidth, False)
    End Function
    Public Shared Function ApplyWidth(ByVal gridViewColumn As GridViewColumn, ByVal minWidth As Double, ByVal width As Double, ByVal maxWidth As Double, ByVal isFillColumn As Boolean) As GridViewColumn
      SetMinWidth(gridViewColumn, minWidth)
      gridViewColumn.Width = width
      SetMaxWidth(gridViewColumn, maxWidth)
      SetIsFillColumn(gridViewColumn, isFillColumn)
      Return gridViewColumn
    End Function

End Class