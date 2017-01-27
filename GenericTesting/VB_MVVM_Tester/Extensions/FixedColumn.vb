Imports System.Windows
Imports System.Windows.Controls

Public NotInheritable Class FixedColumn
    Inherits LayoutColumn

    'CONSTRUCTOR STATIC CLASS
    Private Sub New()
    End Sub


    'PROPERTIES
    Public Shared ReadOnly WidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("Width", GetType(Double), GetType(FixedColumn))


    'METHODS
    Public Shared Function GetWidth(ByVal obj As DependencyObject) As Double
      Return CDbl(obj.GetValue(WidthProperty))
    End Function

    Public Shared Sub SetWidth(ByVal obj As DependencyObject, ByVal width As Double)
      obj.SetValue(WidthProperty, width)
    End Sub

    Public Shared Function IsFixedColumn(ByVal column As GridViewColumn) As Boolean
      Return If(column Is Nothing, False, HasPropertyValue(column, FixedColumn.WidthProperty))
    End Function

    Public Shared Function GetFixedWidth(ByVal column As GridViewColumn) As System.Nullable(Of Double)
      Return GetColumnWidth(column, FixedColumn.WidthProperty)
    End Function

    Public Shared Function ApplyWidth(ByVal gridViewColumn As GridViewColumn, ByVal width As Double) As GridViewColumn
      SetWidth(gridViewColumn, width)
      Return gridViewColumn
    End Function

End Class