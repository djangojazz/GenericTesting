Imports ADODataAccess
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions

Public Class DynamicComboBoxDoubleFillSO

  'Private _people As List(Of Person) = New List(Of Person)
  'Private _products As List(Of Product) = New List(Of Product)
  'Private _SKUs As List(Of Sku) = New List(Of Sku)
  Private _initialLoadDone As Boolean = False
  Private _currentRow As Integer? = Nothing

  Private Sub DynamicComboBoxDoubleFill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    dgv.AutoGenerateColumns = False

    For i = 1 To 2
      Dim row = ds.Tables("Country").NewRow
      row("ID") = i
      row("Name") = If(i = 1, "USA", "Canada")
      ds.Tables("Country").Rows.Add(row)
    Next

    For i = 1 To 4
      Dim row = ds.Tables("State").NewRow
      row("Id") = i
      row("Name") = If(i = 1, "Oregon", If(i = 2, "Washington", If(i = 3, "Alberta", "British Columbia")))
      row("CountryId") = If(i < 3, 1, 2)
      ds.Tables("State").Rows.Add(row)
    Next

    For i = 1 To 2
      Dim row = ds.Tables("Population").NewRow
      row("CountryId") = i
      row("StateId") = If(i = 1, 1, 3)
      row("Population") = i * 1000
      ds.Tables("Population").Rows.Add(row)
    Next

    dgv.AutoGenerateColumns = False
    dgv.DataSource = ds.Tables("Population")
    dgv.Refresh()


    _initialLoadDone = True
  End Sub

  Private Sub EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
    Dim grid = DirectCast(sender, DataGridView)
    If (grid.CurrentCell.ColumnIndex = 1) Then 'State column
      Dim combo = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
      If (grid.CurrentRow.Cells(0).Value IsNot DBNull.Value) Then
        Dim dvStates = New DataView(ds.Tables("State"), $"CountryId = '{grid.CurrentRow.Cells(0).Value}'", "Id ASC", DataViewRowState.CurrentRows)
        combo.DataSource = dvStates
        combo.ValueMember = "Id"
        combo.DisplayMember = "Name"
      Else
        combo.DataSource = Nothing
      End If
    End If
  End Sub

  Private Sub CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
    Dim grid = DirectCast(sender, DataGridView)
    If (e.ColumnIndex = 0 And e.RowIndex >= 0) Then 'Country Column
      grid.Rows(e.RowIndex).Cells(1).Value = DBNull.Value 'State Column 
    End If
  End Sub

  Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dgv.DataError

    MessageBox.Show("Error happened " _
        & e.Context.ToString())

    If (e.Context = DataGridViewDataErrorContexts.Commit) _
        Then
      MessageBox.Show("Commit error")
    End If
    If (e.Context = DataGridViewDataErrorContexts _
        .CurrentCellChange) Then
      MessageBox.Show("Cell change")
    End If
    If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        Then
      MessageBox.Show("parsing error")
    End If
    If (e.Context =
        DataGridViewDataErrorContexts.LeaveControl) Then
      MessageBox.Show("leave control error")
    End If

    If (TypeOf (e.Exception) Is ConstraintException) Then
      Dim view As DataGridView = CType(sender, DataGridView)
      view.Rows(e.RowIndex).ErrorText = "an error"
      view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
          .ErrorText = "an error"

      e.ThrowException = False
    End If
  End Sub

End Class