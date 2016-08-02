Imports ADODataAccess
Imports System.Linq

Public Class DataGridDynamic

  Private _talker = New SQLTalker(GetTesterDatabase)
  Private _people = New DataTable
  Private _orders = New List(Of Order)

  Private Sub DataGridDynamic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      _people = _talker.GetData("Select PersonID, FirstName, LastName, OrderId from dbo.tePerson")
      dgv.DataSource = _people

      _orders = DirectCast(DataConverter.ConvertTo(Of Order)(_talker.GetData("Select OrderId, Description From dbo.teOrder")), List(Of Order))

      Dim s = ""
      For Each o In _orders
        Dim row As DataRow = ds.Tables("tOrders").NewRow
        row("OrderId") = o.OrderId
        row("Description") = o.Description
        ds.Tables("tOrders").Rows.Add(row)
      Next
    Catch ex As Exception

      lTest.Text = ex.InnerException.ToString
    End Try
  End Sub
  Private Sub dgvError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
    If (e.Context = (DataGridViewDataErrorContexts.Formatting Or DataGridViewDataErrorContexts.PreferredSize)) Then
      e.ThrowException = False
    End If
  End Sub

  Private Sub bDoIt_Click(sender As Object, e As EventArgs) Handles bDoIt.Click
    If Not String.IsNullOrEmpty(tTest.Text) Then
      Dim view = New DataView(_people, $"OrderId = '{tTest.Text}'", "PersonId ASC", DataViewRowState.CurrentRows)
      dgv.DataSource = view
    Else
      dgv.DataSource = _people
    End If

  End Sub

  Private Sub btnGetIt_Click(sender As Object, e As EventArgs) Handles btnGetIt.Click
    Dim s = String.Empty
    For Each row As DataRow In _people?.Rows
      s += $"OrderId: {row("OrderId").ToString} Person: {row("FirstName").ToString}" + Environment.NewLine
    Next

    MessageBox.Show(s)
  End Sub
End Class