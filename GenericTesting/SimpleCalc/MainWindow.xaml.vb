Class MainWindow

    Const ADD As String = "Add"
    Const SUBTRACT As String = "Subtract"
    Const MULTIPLY As String = "Multiply"
    Const DIVIDE As String = "Divide"

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

        Dim result As Double
        Select Case operation
            Case ADD
                result = dbl1 + dbl2
            Case SUBTRACT
                result = dbl1 - dbl2
            Case MULTIPLY
                result = dbl1 * dbl2
            Case DIVIDE
                result = dbl1 / dbl2
                If Double.IsPositiveInfinity(result) Or
                    Double.IsNegativeInfinity(result) Then
                    DisplayError("Divide by zero")
                    Return
                End If
        End Select
        DisplayResult(result)
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
        Calculate(SUBTRACT)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs) Handles btnAdd.Click
        Calculate(ADD)
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As RoutedEventArgs) Handles btnMultiply.Click
        Calculate(MULTIPLY)
    End Sub

    Private Sub btnDivide_Click(sender As Object, e As RoutedEventArgs) Handles btnDivide.Click
        Calculate(DIVIDE)
    End Sub

    Private Sub DisplayError(message As String)
        lblOutput.Content = message
        lblOutput.Foreground = Brushes.Red
    End Sub

End Class
