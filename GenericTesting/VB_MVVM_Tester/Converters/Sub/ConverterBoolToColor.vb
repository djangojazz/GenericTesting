Imports System.Windows.Data
Imports System.Windows.Media
Namespace Converters

  <ValueConversion(GetType(Boolean), GetType(Brush))>
  Public Class ConverterBoolToColor
    Implements IValueConverter

    Public Property BrushTrue As New SolidColorBrush(Colors.Black)
    Public Property BrushFalse As New SolidColorBrush(Colors.LightGray)

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
      Return If(CBool(value), BrushTrue, BrushFalse)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
      Throw New NotImplementedException
    End Function

  End Class

End Namespace
