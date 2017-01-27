
Imports System.Windows.Media

Namespace Converters

  'THIS IS AN INSTANCE PROXY OF CONVERTER OBJECTS
  Public Class Converters
    'CONSTRUCTOR
    Private Sub New()
    End Sub

    Public Shared BitmapSourceToGrayscaleSource As New ConverterBitmapSourceToGrayscaleSource

    Public Shared BoolToActiveColorOrInactiveColor As New ConverterBoolToColor With {.BrushTrue = New SolidColorBrush(Colors.Black),
                                                                                     .BrushFalse = New SolidColorBrush(Colors.LightGray)}

    Public Shared BoolToEnabledorDisabledColor As New ConverterBoolToColor With {.BrushTrue = New SolidColorBrush(Colors.White),
                                                                                 .BrushFalse = New SolidColorBrush(Colors.LightGray)}

    Public Shared BoolToVisibleOrCollapsed As New ConverterBoolToVisibility With {.VisibilityTrue = Visibility.Visible,
                                                                                  .VisibilityFalse = Visibility.Collapsed}

    Public Shared StringToLengthGreaterZeroBoolean As New ConverterStringLengthToBool With {.TargetLength = 0,
                                                                                            .BoolGreaterThan = True,
                                                                                            .BoolEqualTo = False,
                                                                                            .BoolLessThan = False}
    Public Shared ColorToBrush As New ConverterColorToSolidColorBrush

    Public Shared StringToTrimString As New ConverterTrimString

    Public Shared ValidationError As New ConverterValidationError

    Public Shared NullableOfDecimalToString As New ConverterNullableOfDecimalToString

  End Class

End Namespace