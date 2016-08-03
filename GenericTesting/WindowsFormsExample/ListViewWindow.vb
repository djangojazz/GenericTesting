Imports ADODataAccess

Public Class ListViewWindow

  Private Structure SPerson
    Public PersonId As Integer
    Public FirstName As String
    Public LastName As String
  End Structure

  Private _talker = New SQLTalker(GetTesterDatabase)
  Private _people As New List(Of SPerson)

  Private Sub ListViewWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Cursor.Current = Cursors.WaitCursor
    Dim items = _talker.GetData("Select PersonId, FirstName, LastName from dbo.tePerson")

    Dim s = String.Empty
    For Each item In items.Rows
      _people.Add(New SPerson With {.PersonId = item("PersonId"), .FirstName = item("FirstName"), .LastName = item("LastName")})
    Next

    LoadDataListView(_people)
  End Sub

  Private Sub LoadDataListView(items As List(Of SPerson))
    If items?.Count > 0 Then
      lsv.Items.Clear()

      items.ForEach(Sub(x)
                      Dim lvi As ListViewItem = lsv.Items.Add(x.PersonId)
                      lvi.SubItems.Add(x.FirstName)
                      lvi.SubItems.Add(x.LastName)
                    End Sub)
    End If
  End Sub

  Private Sub bFilter_Click(sender As Object, e As EventArgs) Handles bFilter.Click

    If Not String.IsNullOrEmpty(tTest.Text) Then
      LoadDataListView(_people?.Where(Function(x) x.PersonId = tTest.Text)?.ToList())
    Else
      LoadDataListView(_people)
    End If


  End Sub
End Class