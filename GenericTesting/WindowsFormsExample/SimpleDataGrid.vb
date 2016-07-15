Imports ADODataAccess
Imports System.Linq

Public Class SimpleDataGrid

  Public Class Product
    Public Property ProductID As Integer
    Public Property ProudctName As String
  End Class

  Private _products = New List(Of Product)
  Private _talker = New SQLTalker("(local)", "Tester")

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    With Me.dgv.Rows
      .Add(New String() {"1", "A"})
      .Add(New String() {"2", "B"})
      .Add(New String() {"3", "C"})
    End With

    _products = DataConverter.ConvertTo(Of Product)(_talker.GetData("Select * From dbo.Product"))
    Dim s = ""


  End Sub

  Public Sub DataGridView1_CurrentCellChanged1(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
    Static nPrevLineIndex As Integer = -1
    If nPrevLineIndex <> dgv.CurrentRow.Index Then
      nPrevLineIndex = dgv.CurrentRow.Index
      Dim val = dgv.CurrentRow.Cells("Value")?.Value?.ToString()

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

End Class