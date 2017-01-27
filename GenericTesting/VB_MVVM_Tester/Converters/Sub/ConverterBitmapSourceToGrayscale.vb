Imports System.Windows.Data
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Namespace Converters

  Public Class ConverterBitmapSourceToGrayscaleSource
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
      If TypeOf value Is BitmapSource Then
        Dim orgBmp As BitmapSource = DirectCast(value, BitmapSource)
        If orgBmp.Format = PixelFormats.Bgra32 Then
          Dim orgPixels As Byte() = New Byte(orgBmp.PixelHeight * orgBmp.PixelWidth * 4) {}
          Dim newPixels As Byte() = New Byte(orgPixels.Length) {}
          orgBmp.CopyPixels(orgPixels, orgBmp.PixelWidth * 4, 0)
          Dim i As Integer = 3
          While i < orgPixels.Length
            Dim grayVal As Integer = (CType(orgPixels(i - 3), Integer) + CType(orgPixels(i - 2), Integer) + CType(orgPixels(i - 1), Integer))

            If grayVal <> 0 Then
              grayVal = CInt(grayVal / 3)
            End If
            newPixels(i) = orgPixels(i)
            'Set AlphaChannel
            newPixels(i - 3) = CType(grayVal, Byte)
            newPixels(i - 2) = CType(grayVal, Byte)
            newPixels(i - 1) = CType(grayVal, Byte)
            i += 4
          End While
          Return BitmapSource.Create(orgBmp.PixelWidth, orgBmp.PixelHeight, 96, 96, PixelFormats.Bgra32, Nothing, _
           newPixels, orgBmp.PixelWidth * 4)
        End If
      End If
      Return value
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
      Throw New NotImplementedException
    End Function
  End Class

End Namespace
