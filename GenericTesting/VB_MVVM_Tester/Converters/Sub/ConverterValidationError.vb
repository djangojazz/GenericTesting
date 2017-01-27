Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Windows.Data

Namespace Converters

  Public Class ConverterValidationError
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
      Dim observables As ReadOnlyObservableCollection(Of ValidationError) = TryCast(value, ReadOnlyObservableCollection(Of ValidationError))
      If ((observables Is Nothing) OrElse (observables.Count = 0)) Then
        Return String.Empty
      End If
      Return observables.Item(0).ErrorContent
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
      Throw New NotImplementedException
    End Function

  End Class

End Namespace



