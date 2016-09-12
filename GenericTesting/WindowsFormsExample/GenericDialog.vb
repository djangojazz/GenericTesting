Imports System.Collections.Generic

Public Class GenericDialog
  Public Sub New(title As String, array As List(Of String))
    InitializeComponent()

    Dim locationVert = 20

    Me.Text = title

    array.ForEach(Sub(x)
                    Dim b = New Button()
                    b.Name = x
                    b.Text = x
                    b.Width = 200
                    b.Height = 30
                    Me.Controls.Add(b)
                    b.Location = New Point(20, locationVert)

                    locationVert += 40
                  End Sub)

    Me.Height = (array.Count * 40) + 70

    Dim btn As Button = Nothing
    For Each ctrl As Control In Me.Controls
      If TypeOf ctrl Is Button Then
        btn = DirectCast(ctrl, Button)
        AddHandler btn.Click, Sub(sender, args) MessageBox.Show($"You clicked: {CType(sender, Button).Text}")
      End If
    Next
  End Sub

End Class