Imports ADODataAccess
Imports System
Imports System.Text.RegularExpressions

Public Class SimpleDataGrid

  Private _lastValue As Object

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

    For i = 1 To 2
      Dim newRow As DataRow = ds.Tables("tBase").NewRow
      newRow("Id") = i
      newRow("Value") = i * 1000
      newRow("Percent") = (i * 0.22) * 100
      newRow("ProductId") = i + 5
      ds.Tables("tBase").Rows.Add(newRow)
    Next

    ds.AcceptChanges()

    Percent.DefaultCellStyle.Format = "##.##"
  End Sub

  Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
    Dim list As New List(Of DataGridViewRow)

    For Each cell As DataGridViewCell In dgv.SelectedCells
      list.Add(cell.OwningRow)
    Next
    Dim thing = ""

    list.ForEach(Sub(x) thing += x.ToString)
  End Sub

  Private Sub dataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating
    Dim headerText As String = dgv.Columns(e.ColumnIndex).HeaderText
    Dim colsToLookAt = ({"Percent", "Value"})

    'Abort if not in validated columns 
    If Not colsToLookAt.Contains(headerText) Then
      Return
    End If

    Dim val = e.FormattedValue.ToString().ToLower()

    'Determine Percent as special case
    If headerText.Equals("Percent") Then
      Dim regexPercent = New Regex("^([0-9]{1,2})(\.[0-9]{1,2})?$")


      If Not regexPercent.Match(val).Success Then
        dgv.Rows(e.RowIndex).ErrorText = "Percent must be numeric and in the format: ##.##"
        btnGetValues.Enabled = False
        e.Cancel = True
        Return
      End If
    Else
      'If it is something else in the listed columns to examine do a different regex pattern
      Dim regex = New Regex("^(?!.{8,})[0-9]{1,3}(?:,?[0-9]{3})*$")

      If Not regex.Match(val).Success Then
        dgv.Rows(e.RowIndex).ErrorText = "You are limited to numbers under a million by product and in the format: ###,### or ######"
        'btnGetValues.Enabled = False
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub dataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated
    dgv.Rows(e.RowIndex).ErrorText = String.Empty
    btnGetValues.Enabled = True
    Dim currentCell = DirectCast(sender, DataGridView)?.CurrentCell?.Value?.ToString

    If (_lastValue <> currentCell) Then
      lbly.Text = currentCell
      lblz.Text = "Needs change"
    Else
      lbly.Text = currentCell
      lblz.Text = "No change"
    End If

  End Sub


  Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
    Dim x = DirectCast(sender, DataGridView)?.CurrentCell?.Value.ToString
    _lastValue = x
    lblx.Text = x
  End Sub

  Private Sub btnGetValues_Click(sender As Object, e As EventArgs) Handles btnGetValues.Click
    Dim s = ""
    For Each row As DataGridViewRow In dgv.Rows
      s += row.Cells("TestDropDown")?.Value?.ToString + Environment.NewLine
    Next


    'If ds.HasChanges() Then
    '  For Each row As DataRow In ds.Tables("tBase").GetChanges().Rows
    '    Dim valId = CInt(If(row("Id")?.ToString() <> String.Empty, row("Id"), 0))
    '    s += $"Id: {valId} Value: {row("Value")} Percent:{row("Percent")}"
    '  Next
    'End If


    MessageBox.Show(s)
  End Sub
End Class