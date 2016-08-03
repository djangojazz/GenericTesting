Imports ADODataAccess

Public Class ListViewWindow

  Private Structure SPerson
    Public PersonId As Integer
    Public FirstName As String
    Public LastName As String
  End Structure

  Private _talker = New SQLTalker(GetTesterDatabase)
  Private _people As DataTable

  Private Sub ListViewWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Cursor.Current = Cursors.WaitCursor
    _people = _talker.GetData("Select PersonId, FirstName, LastName from dbo.tePerson")
    LoadDataListView(_people.Select())
  End Sub

  Private Sub LoadDataListView(items As DataRow())
    If items?.Count > 0 Then
      lsv.Items.Clear()

      For Each item In items
        Dim lvi As ListViewItem = lsv.Items.Add(item("PersonId").ToString)
        lvi.SubItems.Add(item("FirstName").ToString)
        lvi.SubItems.Add(item("LastName").ToString)
      Next
    End If
  End Sub

  Private Sub bFilter_Click(sender As Object, e As EventArgs) Handles bFilter.Click

    If Not String.IsNullOrEmpty(tTest.Text) Then
      LoadDataListView(_people.Select($"PersonId = {tTest.Text}"))
    Else
      LoadDataListView(_people.Select())
    End If





  End Sub
End Class