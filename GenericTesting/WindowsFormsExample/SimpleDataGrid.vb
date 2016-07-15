Imports ADODataAccess
Imports System.Linq

Public Class SimpleDataGrid

  Public Class Product
    Public Property ProductId As Integer
    Public Property ProductDescription As String
  End Class

  Private _products = New List(Of Product)
  Private _talker = New SQLTalker(GetTesterDatabase)

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()
    _products = DirectCast(DataConverter.ConvertTo(Of Product)(_talker.GetData("Select * From dbo.Product")), List(Of Product)).OrderBy(Function(x) x.ProductDescription)

    Dim s = ""
    For Each p In _products
      's += p.ProductDescription + Environment.NewLine
      Dim row As DataRow = ds.Tables("tProduct").NewRow
      row("ProductId") = p.ProductId
      row("Whatevs") = p.ProductDescription
      ds.Tables("tProduct").Rows.Add(row)
    Next

    For i = 1 To 3
      Dim newRow As DataRow = ds.Tables("tBase").NewRow
      newRow("Id") = i
      newRow("Value") = If(i = 1, "A", If(i = 2, "B", "C"))
      newRow("ProductId") = i + 5
      ds.Tables("tBase").Rows.Add(newRow)
    Next
  End Sub

  Public Sub DataGridView1_CurrentCellChanged1(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
    Static nPrevLineIndex As Integer = -1
    If nPrevLineIndex <> dgv.CurrentRow.Index Then
      nPrevLineIndex = dgv.CurrentRow.Index
      Dim val = dgv.CurrentRow.Cells("ValueDataGridViewTextBoxColumn")?.Value?.ToString()

      If Not val Is Nothing Then lbl.Text = nPrevLineIndex.ToString() + " Val: " + val
      'RaiseEvent CurrentRowChanged(nPrevLineIndex)
    End If
  End Sub

  Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
    Dim list As New List(Of DataGridViewRow)

    For Each cell As DataGridViewCell In dgv.SelectedCells
      list.Add(cell.OwningRow)
    Next
    Dim thing = ""

    list.ForEach(Sub(x) thing += x.ToString)
  End Sub

  Private Sub btnGetValues_Click(sender As Object, e As EventArgs) Handles btnGetValues.Click
    Dim s = ""
    For Each row As DataGridViewRow In dgv.Rows
      s += row.Cells("Id").ToString + Environment.NewLine
    Next
    MessageBox.Show(s)
  End Sub
End Class