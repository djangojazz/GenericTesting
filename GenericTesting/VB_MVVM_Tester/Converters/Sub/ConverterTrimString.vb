Imports System.Globalization
Imports System.Windows.Data

Namespace Converters

  <ValueConversion(GetType(String), GetType(String))>
  Public Class ConverterTrimString
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
      If IsNothing(value) Then Return ""
      Return CStr(value).Trim
    End Function


    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
      Throw New NotImplementedException
    End Function
  End Class

End Namespace