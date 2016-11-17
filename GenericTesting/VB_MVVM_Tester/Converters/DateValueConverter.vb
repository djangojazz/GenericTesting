Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class DateValueConverter
  Inherits Control
  Implements IValueConverter

  Public Property DateFormat As String = "MM/dd/yyyy"

  Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    Dim dt = New DateTime(value)

    Return dt.ToString(DateFormat)
  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function
End Class
