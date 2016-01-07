Class MainWindow

    Dim names As ArrayList = New ArrayList()



    Sub RunCode(sender As Object, e As RoutedEventArgs)
        'Add code here
        Dim item1 As String = "Hello"
        Dim item2 As String = "There"
        Dim format = String.Format("{0} {1}", item1, item2)
        Dim stringInterpolate = $"{item1} {item2}"

        Output(format)
        Output(stringInterpolate)

    End Sub

    Sub Output(Value As String)
        txtOutput.Text += Value + vbCrLf
    End Sub

    Sub ClearOutput(sender As Object, e As RoutedEventArgs)
        txtOutput.Text = ""
    End Sub

End Class
