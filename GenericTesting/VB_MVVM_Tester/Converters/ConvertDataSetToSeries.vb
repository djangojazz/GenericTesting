﻿Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class ConvertDataSetToSeries
  Inherits Control
  Implements IValueConverter

#Region "Implementation of IValueConverter"

  Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    Dim rawData = TryCast(value, Collection(Of LineTrend))

    If rawData IsNot Nothing Then

      If parameter = "H" Then
        'Dim xs = rawData.SelectMany(Function(x) x.Points).Select(Function(x) x.X).Distinct().OrderBy(Function(x) x)

        Return New List(Of String)({"0", "", "20", "", "40", "", "60", "", "80", "", "100"})
      Else
        Dim ys = rawData.SelectMany(Function(x) x.Points).Select(Function(x) x.Y).Distinct().OrderBy(Function(x) x)
        Return ys
      End If


    End If
  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function

#End Region
End Class