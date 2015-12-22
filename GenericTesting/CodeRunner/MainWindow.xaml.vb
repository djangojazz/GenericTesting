Class MainWindow 

    Sub RunCode(sender As Object, e As RoutedEventArgs)
        'Add code here
        'Output("Hellow World")
        Dim input As String = txtInput.Text
        Output(input)
    End Sub

    Sub Output(Value As String)
        txtOutput.Text += Value + vbCrLf
    End Sub

    Sub ClearOutput(sender As Object, e As RoutedEventArgs)
        txtOutput.Text = ""
    End Sub

End Class
