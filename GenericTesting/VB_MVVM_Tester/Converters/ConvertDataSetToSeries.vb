Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class ConvertDataSetToSeries
  Inherits Control
  Implements IValueConverter

#Region "Implementation of IValueConverter"

  Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    Dim rawData = TryCast(value, Collection(Of LineTrend))

    If rawData IsNot Nothing Then
      Return "lkajsd;flkajs;ljkasd"
    End If
  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function

#End Region
End Class
