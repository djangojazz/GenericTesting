Imports System.Windows.Data
Namespace Converters
  Public Class ConverterNullableOfDecimalToString
    Implements IValueConverter
    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
      Select Case True
        Case TypeOf value Is Nullable(Of Decimal)
          Dim oValue As Nullable(Of Decimal) = CType(value, Nullable(Of Decimal))
          If oValue.HasValue Then
            Return oValue.Value
          Else
            Return ""
          End If
        Case Else : Return ""
      End Select
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
      If IsNumeric(value) Then
        Return CDec(value)
      Else
        Return New Nullable(Of Decimal)
      End If
    End Function
  End Class
End Namespace
