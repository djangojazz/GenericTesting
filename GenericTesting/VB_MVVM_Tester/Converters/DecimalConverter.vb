Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class DecimalConverter
  Inherits Control
  Implements IValueConverter

  Public DecimalPositions As Integer = 2
  Public IncludeComma As Boolean = True


  Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    If Not IsNumeric(value) Then Return ""

    Dim FormatString As String = If(IncludeComma, "#,##0", "0")
    If DecimalPositions > 0 Then FormatString &= "." & StrDup(DecimalPositions, "0"c)

    Return CType(value, Decimal).ToString(FormatString)

  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function
End Class
