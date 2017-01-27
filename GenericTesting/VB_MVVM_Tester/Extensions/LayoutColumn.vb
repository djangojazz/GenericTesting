Imports System
Imports System.Windows
Imports System.Windows.Controls

Public MustInherit Class LayoutColumn

    'METHODS
    Protected Shared Function HasPropertyValue(ByVal column As GridViewColumn, ByVal dp As DependencyProperty) As Boolean
      If column Is Nothing Then Throw New ArgumentNullException("column")

      Dim value As Object = column.ReadLocalValue(dp)
      Return If(value IsNot Nothing AndAlso value.GetType() Is dp.PropertyType, True, False)
    End Function

    Protected Shared Function GetColumnWidth(ByVal column As GridViewColumn, ByVal dp As DependencyProperty) As System.Nullable(Of Double)
      If column Is Nothing Then Throw New ArgumentNullException("column")

      Dim value As Object = column.ReadLocalValue(dp)
      Return If(value IsNot Nothing AndAlso value.GetType() Is dp.PropertyType, CDbl(value), Nothing)
    End Function

End Class