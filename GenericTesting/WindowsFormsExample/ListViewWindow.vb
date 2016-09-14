Imports ADODataAccess

Public Class ListViewWindow

  Private Structure SPerson
    Public PersonId As Integer
    Public FirstName As String
    Public LastName As String
  End Structure

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _people As New List(Of SPerson)

  Private Sub ListViewWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Cursor.Current = Cursors.WaitCursor
    Dim items = _talker.GetData("Select PersonId, FirstName, LastName from dbo.tePerson")

    Dim s = String.Empty
    For Each item As DataRow In items.Rows
      _people.Add(New SPerson With {.PersonId = CInt(item("PersonId")), .FirstName = CStr(item("FirstName")), .LastName = CStr(item("LastName"))})
    Next

    LoadDataListView(_people)
  End Sub

  Private Sub LoadDataListView(items As List(Of SPerson))
    If items?.Count > 0 Then
      lsv.Items.Clear()

      items.ForEach(Sub(x)
                      Dim lvi As ListViewItem = lsv.Items.Add(x.PersonId.ToString)
                      lvi.SubItems.Add(x.FirstName.ToString)
                      lvi.SubItems.Add(x.LastName.ToString)
                    End Sub)
    End If
  End Sub

  Private Sub bFilter_Click(sender As Object, e As EventArgs) Handles bFilter.Click

    If Not String.IsNullOrEmpty(tTest.Text) Then
      LoadDataListView(_people?.Where(Function(x) x.PersonId = CInt(tTest.Text))?.ToList())
    Else
      LoadDataListView(_people)
    End If


  End Sub
End Class