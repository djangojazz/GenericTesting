Imports CodeRunner.Utilities

Class MainWindow

    Sub Calculate(operation As String)

        Dim str1 As String = txtInput1.Text
        Dim str2 As String = txtInput2.Text
        Dim dbl1 As Double
        Dim dbl2 As Double

        If IsNumeric(str1) And IsNumeric(str2) Then
            dbl1 = Double.Parse(str1)
            dbl2 = Double.Parse(str2)
        Else
            DisplayError("Not a number")
            Return
        End If

        Dim calc = New CalcUtility(dbl1, dbl2)

        Select Case operation
            Case CalcUtility.ADD
                calc.AddValues()
            Case CalcUtility.SUBTRACT
                calc.SubtractValues()
            Case CalcUtility.MULTIPLY
                calc.MultiplyValues()
            Case CalcUtility.DIVIDE
                calc.DivideValues()
        End Select
        If Double.IsPositiveInfinity(calc.result) Or
                    Double.IsNegativeInfinity(calc.result) Then
            DisplayError("Divide by zero")
            Return
        End If

        DisplayResult(calc.result)
    End Sub

    Sub DisplayResult(result As Double)
        lblOutput.Content = result.ToString
        If result >= 0 Then
            lblOutput.Foreground = Brushes.Black
        Else
            lblOutput.Foreground = Brushes.Red
        End If
    End Sub

    Private Sub btnSubtract_Click(sender As Object, e As RoutedEventArgs)
        Calculate(CalcUtility.SUBTRACT)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Calculate(CalcUtility.ADD)
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As RoutedEventArgs) Handles btnMultiply.Click
        Calculate(CalcUtility.MULTIPLY)
    End Sub

    Private Sub btnDivide_Click(sender As Object, e As RoutedEventArgs) Handles btnDivide.Click
        Calculate(CalcUtility.DIVIDE)
    End Sub

    Private Sub DisplayError(message As String)
        lblOutput.Content = message
        lblOutput.Foreground = Brushes.Red
    End Sub

End Class
