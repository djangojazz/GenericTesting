Imports ADODataAccess
Imports System.Linq
Imports System.Text.RegularExpressions

Public Class DataGridDynamic

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _people As DataTable = New DataTable
  Private _orders As List(Of Order) = New List(Of Order)
  Private _countries As New List(Of Country)
  Private _details As New List(Of ReceivingPlanDetail)

  Private Sub DataGridDynamic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      Using myReader As New APCLocal.Select.Countries("DEV-APC1", 0)
        Do While myReader.Read
          Dim o As DataRow = data.Tables("tCountries").NewRow
          o("CountryId") = myReader.Int(APCLocal.Select.Countries.EInts.CountryID)
          o("Country") = myReader.Str(APCLocal.Select.Countries.EStrings.Name)
          data.Tables("tCountries").Rows.Add(o)
          '_countries.Add(New Country() With {.CountryId = myReader.Int(APCLocal.Select.Countries.EInts.CountryID), .Country = myReader.Str(APCLocal.Select.Countries.EStrings.Name)})
        Loop
      End Using

      Using myReader As New APCLocal.Select.ReceivingPlanDetailByProductionId("DEV-APC1", 441)
        Do While myReader.Read
          Dim o As DataRow = data.Tables("tHail").NewRow
          o("HailDetailId") = myReader.Int(APCLocal.Select.ReceivingPlanDetailByProductionId.EInts.HailDetailID)
          o("Weight") = myReader.Dec(APCLocal.Select.ReceivingPlanDetailByProductionId.ENbr.HailPounds)
          o("Harvested") = myReader.Int(APCLocal.Select.ReceivingPlanDetailByProductionId.EInts.CountryHarvested)
          o("Processed") = myReader.Int(APCLocal.Select.ReceivingPlanDetailByProductionId.EInts.CountryProcessed)
          o("CatchDate") = myReader.Dte(APCLocal.Select.ReceivingPlanDetailByProductionId.EDates.CatchDate)
          data.Tables("tHail").Rows.Add(o)
        Loop
      End Using

      dgvHail.AutoGenerateColumns = False
      dgvHail.DataSource = data.Tables("tHail")

      _people = _talker.GetData("Select PersonId, FirstName, LastName, OrderId, OrderDesc from dbo.vPersonOrders")
      dgv.AutoGenerateColumns = False
      dgv.DataSource = _people

      _orders = DirectCast(DataConverter.ConvertTo(Of Order)(_talker.GetData("Select OrderId, PersonId, Description From dbo.teOrder")), List(Of Order))

      OrderId.DataSource = _orders
      OrderId.DisplayMember = "Description"
      OrderId.ValueMember = "OrderId"
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
      Dim view = New DataView(_people, $"PersonId = '{tTest.Text}'", "PersonId ASC", DataViewRowState.CurrentRows)
      dgv.DataSource = view
    Else
      dgv.DataSource = _people
    End If

  End Sub

  Private Sub btnGetIt_Click(sender As Object, e As EventArgs) Handles btnGetIt.Click
    Dim s = String.Empty

    For Each row As DataRow In _people.Rows
      s += $"OrderId: {row("OrderId").ToString()} Person: {row("FirstName").ToString()} {row("LastName").ToString()}" + Environment.NewLine
    Next

    MessageBox.Show(s)
  End Sub

  Private Sub CheckRowsAreDone()
    For Each row As DataGridViewRow In dgv.Rows
      Dim num = 0

      For i = 0 To row.Cells.Count - 1
        Dim val = If(Not String.IsNullOrEmpty(row?.Cells(i)?.Value?.ToString), 1, -1)
        num += val
      Next

      If num > -(row.Cells.Count) And num < (row.Cells.Count) Then btnGetIt.Enabled = False : Exit Sub Else btnGetIt.Enabled = True
    Next
  End Sub

  Private Sub CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating
    Dim headerText As String = TryCast(sender, DataGridView).Columns(e.ColumnIndex).HeaderText
    Dim colsToLookAt = ({"ORDER", "PersonID", "FirstName", "LastName"})

    'Abort if not in validated columns 
    If Not colsToLookAt.Contains(headerText) Then Return

    Dim textValue = e.FormattedValue.ToString().ToLower()

    If textValue.Length = 0 Then Return

    If headerText.Equals(colsToLookAt(0)) Then
      If String.IsNullOrEmpty(textValue) Then
        TryCast(sender, DataGridView).Rows(e.RowIndex).ErrorText = "You must Select a product To be used"
        bDoIt.Enabled = False
        e.Cancel = True
        Return
      End If

    ElseIf headerText.Equals(colsToLookAt(1)) Then

      If Not (New Regex("[0-9]").Match(textValue).Success) Then
        TryCast(sender, DataGridView).Rows(e.RowIndex).ErrorText = "Field needs to be a number."
        bDoIt.Enabled = False
        e.Cancel = True
        Return
      End If
    Else
      If (New Regex("[0-9]").Match(textValue).Success) Then
        TryCast(sender, DataGridView).Rows(e.RowIndex).ErrorText = "You should not be using numbers in a name"
        bDoIt.Enabled = False
        e.Cancel = True
      End If
    End If


  End Sub

  Private Sub CellEndedValidation(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated
    TryCast(sender, DataGridView).Rows(e.RowIndex).ErrorText = String.Empty
    bDoIt.Enabled = True
    CheckRowsAreDone()
  End Sub
End Class