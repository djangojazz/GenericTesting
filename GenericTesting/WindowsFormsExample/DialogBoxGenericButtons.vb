Imports ADODataAccess
Imports System.Linq

Public Class DialogBoxGenericButtons

  Private _firstValue As String
  'Public Property FirstValue() As String
  '  Get
  '    Return _firstValue
  '  End Get
  '  Private Set
  '    _firstValue = Value
  '  End Set
  'End Property

  'Private _secondValue As String
  'Public Property SecondValue() As String
  '  Get
  '    Return _secondValue
  '  End Get
  '  Private Set
  '    _secondValue = Value
  '  End Set
  'End Property

  Public Sub New(firstValue As String, secondValue As String)
    InitializeComponent()

    '_firstValue = firstValue
    '_secondValue = secondValue
    b1.Text = firstValue
    b2.Text = secondValue
  End Sub

  Private Sub HandleClicks(sender As Object, e As EventArgs) Handles b1.Click, b2.Click
    Select Case True
      Case sender Is b1 : MessageBox.Show($"You selected {b1.Text}") : Close()
      Case sender Is b2 : MessageBox.Show($"You selected {b2.Text}") : Close()
    End Select


  End Sub
End Class