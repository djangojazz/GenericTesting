Class MainWindow

    Dim names As ArrayList = New ArrayList()



    Sub RunCode(sender As Object, e As RoutedEventArgs)
        'Add code here

    End Sub

    Sub Output(Value As String)
        txtOutput.Text += Value + vbCrLf
    End Sub

    Sub ClearOutput(sender As Object, e As RoutedEventArgs)
        txtOutput.Text = ""
    End Sub

End Class
