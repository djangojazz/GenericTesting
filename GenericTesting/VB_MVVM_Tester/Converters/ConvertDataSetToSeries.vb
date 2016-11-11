Imports System.Globalization
Imports System.Collections.ObjectModel

Public Class ConvertDataSetToSeries
  Inherits Control
  'Inherits MarkupExtension
  Implements IValueConverter
  'Private Shared instance As ConvertDataSetToSeries

#Region "Overrides of MarkupExtension"

  'Public Overrides Function ProvideValue(serviceProvider As IServiceProvider) As Object
  '  Return If(instance, (InlineAssignHelper(instance, New ConvertDataSetToSeries())))
  'End Function

  'Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
  '  target = value
  '  Return value
  'End Function

#End Region

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


    'If Not (TypeOf value Is LegendLocation) Then
    '  Return Nothing
    'End If
    'Dim legendLocation__1 = DirectCast(value, LegendLocation)
    'Dim horAlignment = String.IsNullOrEmpty(DirectCast(parameter, String)) OrElse DirectCast(parameter, String).StartsWith("H")
    'If horAlignment Then
    '  Select Case legendLocation__1
    '    Case LegendLocation.TopLeft, LegendLocation.BottomLeft
    '      Return HorizontalAlignment.Left
    '    Case LegendLocation.TopRight, LegendLocation.BottomRight
    '      Return HorizontalAlignment.Right
    '  End Select
    'Else
    '  Select Case legendLocation__1
    '    Case LegendLocation.TopLeft, LegendLocation.TopRight
    '      Return VerticalAlignment.Top
    '    Case LegendLocation.BottomLeft, LegendLocation.BottomRight
    '      Return VerticalAlignment.Bottom
    '  End Select
    'End If
    'Return Nothing
  End Function

  Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    Throw New NotImplementedException()
  End Function


  'Private Function IValueConverter_Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
  '  Throw New NotImplementedException()
  'End Function

  'Private Function IValueConverter_ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
  '  Throw New NotImplementedException()
  'End Function

#End Region
End Class
