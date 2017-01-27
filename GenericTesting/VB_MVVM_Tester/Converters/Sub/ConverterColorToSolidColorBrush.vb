Imports System.Windows.Data
Imports System.Windows.Media
Namespace Converters

  Public Class ConverterColorToSolidColorBrush
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
      If TypeOf value Is Color Then
        Return New SolidColorBrush(DirectCast(value, Color))
      Else
        Return New SolidColorBrush(Colors.LightGray)
      End If
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
      Return CType(value, SolidColorBrush).Color
    End Function

  End Class

End Namespace

