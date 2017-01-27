Imports System
Imports System.Windows
Imports System.Windows.Controls
Public NotInheritable Class ProportionalColumn
    Inherits LayoutColumn

    'CONSTRUCTOR STATIC
    Private Sub New()
    End Sub


    'PROPERTIES
    Public Shared ReadOnly WidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("Width", GetType(Double), GetType(ProportionalColumn))


    'METHODS
    Public Shared Function GetWidth(ByVal obj As DependencyObject) As Double
      Return CDbl(obj.GetValue(WidthProperty))
    End Function

    Public Shared Sub SetWidth(ByVal obj As DependencyObject, ByVal width As Double)
      obj.SetValue(WidthProperty, width)
    End Sub

    Public Shared Function IsProportionalColumn(ByVal column As GridViewColumn) As Boolean
      If column Is Nothing Then
        Return False
      End If
      Return HasPropertyValue(column, WidthProperty)
    End Function

    Public Shared Function GetProportionalWidth(ByVal column As GridViewColumn) As System.Nullable(Of Double)
      Return GetColumnWidth(column, WidthProperty)
    End Function

    Public Shared Function ApplyWidth(ByVal gridViewColumn As GridViewColumn, ByVal width As Double) As GridViewColumn
      SetWidth(gridViewColumn, width)
      Return gridViewColumn
    End Function

  End Class
