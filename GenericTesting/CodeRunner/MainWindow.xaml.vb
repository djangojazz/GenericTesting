Class MainWindow 

    Sub RunCode(sender As Object, e As RoutedEventArgs)
        'Add code here
        Dim unknownType

        Dim myString As String = "Hello World"
        Dim myNumber As Integer = 42
        Dim myDate As Date = DateValue("November 28, 2015")

        Dim myString2 = "Hello World"
        Dim myNumber2 = 42.5
        Dim myDate2 = DateValue("November 28, 2015")

        unknownType = myString

        Output(myString)
        Output(myNumber)
        Output(myDate)
    End Sub

    Sub Output(Value As String)
        txtOutput.Text += Value + vbCrLf
    End Sub

    Sub ClearOutput(sender As Object, e As RoutedEventArgs)
        txtOutput.Text = ""
    End Sub

End Class
