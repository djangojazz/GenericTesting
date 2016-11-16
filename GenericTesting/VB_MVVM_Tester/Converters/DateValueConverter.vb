Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class DateValueConverter
  Inherits Control
  Implements IValueConverter


  Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    If Not IsDate(value) Then Return ""

    Return CType(value, Date).ToString("MM/dd/yyyy")

  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function
End Class
