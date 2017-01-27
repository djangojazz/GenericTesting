Imports System.Windows.Data
Imports System.Windows.Media

Namespace Converters

  <ValueConversion(GetType(Boolean), GetType(Visibility))>
  Public Class ConverterBoolToVisibility

    Implements IValueConverter

    Public Property VisibilityTrue As Visibility = Visibility.Visible
    Public Property VisibilityFalse As Visibility = Visibility.Collapsed

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
      Return If(CBool(value), VisibilityTrue, VisibilityFalse)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
      Return Nothing
    End Function
  End Class

End Namespace