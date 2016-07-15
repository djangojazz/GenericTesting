Public Class ErrorChecking
  Private Function txtOne_KeyPress(sender As Object, e As KeyPressEventArgs) As Integer Handles txtOne.KeyPress, txtTwo.KeyPress
    'lblTest.Text = DirectCast(sender, TextBox).Text.Split("."c).GetUpperBound(0)

    If Not Char.IsDigit(e.KeyChar) Then
      If sender Is txtTwo AndAlso e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Split("."c).GetUpperBound(0) > 0 Then
        errorProvider.SetError(CType(sender, Control), "Please use only one decimal place.")
      ElseIf sender Is txtTwo AndAlso e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Split("."c).GetUpperBound(0) = 0 Then
        Return 0
      Else
        errorProvider.SetError(CType(sender, Control), "Please use only numbers.")
        Return 1
      End If
    Else
      errorProvider.SetError(CType(sender, Control), String.Empty)
      Return 0
    End If
  End Function
End Class