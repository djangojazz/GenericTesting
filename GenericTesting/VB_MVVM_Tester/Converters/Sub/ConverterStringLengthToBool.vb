Imports System.Globalization
Imports System.Windows.Data

Namespace Converters

  <ValueConversion(GetType(String), GetType(Boolean))>
  Public Class ConverterStringLengthToBool
    Implements IValueConverter


    Public Property TargetLength As Integer = 0
    Public Property BoolGreaterThan As Boolean = True
    Public Property BoolEqualTo As Boolean = False

    Public Property BoolLessThan As Boolean = False

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
      Select Case True
        Case value.ToString.Length > TargetLength : Return BoolGreaterThan
        Case value.ToString.Length = TargetLength : Return BoolEqualTo
        Case Else : Return BoolLessThan
      End Select
    End Function


    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
      Throw New NotImplementedException
    End Function
  End Class

End Namespace
