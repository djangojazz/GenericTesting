Imports ADODataAccess

Public Class TreeUpdate
  Private _length As Integer
  Private _type As Type
  Private _id As Integer
  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)

  Enum Type
    Create
    Update
    Delete
  End Enum

  Public Sub New(id As Integer, input As String, type As Type)
    ' This call is required by the designer.
    InitializeComponent()

    _length = input.Length
    _type = type
    _id = id

    txt.Text = input
    Me.Text = type.ToString()
    btn.Text = type.ToString()
  End Sub

  Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
    If txt.Text.Length <> _length Then
      MessageBox.Show("Length is wrong")
    Else
      If _type = Type.Create Then
        _talker.Procer($"Insert into TreeTest Values ('{txt.Text}', NULL, Getdate(), Getdate(), 1)")
      ElseIf _type = Type.Update Then
        _talker.Procer($"Update TreeTest Set Val = '{txt.Text}' Where Id = {_id}")
      Else
        _talker.Procer($"Delete TreeTest Where Id = {_id}")
      End If
    End If

    Me.Close()
  End Sub
End Class