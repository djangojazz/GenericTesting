Imports ADODataAccess
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions

Public Class DynamicComboBoxDoubleFill

  Private _people As List(Of Person) = New List(Of Person)
  Private _products As List(Of Product) = New List(Of Product)
  Private _SKUs As List(Of Sku) = New List(Of Sku)
  Private _initialLoadDone As Boolean = False
  Private _currentRow As Integer? = Nothing

  Private Sub DynamicComboBoxDoubleFill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    dgv.AutoGenerateColumns = False

    _products = New List(Of Product)({
                                     New Product With {.ProductId = 1, .Description = "Offline"},
                                     New Product With {.ProductId = 2, .Description = "Online"}
                                     })

    Dim s = ""
    For Each o In _products
      Dim row As DataRow = ds.Tables("tProducts").NewRow
      row("ProductId") = o.ProductId
      row("Description") = o.Description
      ds.Tables("tProducts").Rows.Add(row)
    Next

    _SKUs = New List(Of Sku)({
     New Sku With {.SKUId = 1, .ProductId = 1, .Description = "Mail"},
     New Sku With {.SKUId = 2, .ProductId = 1, .Description = "Magazine"},
     New Sku With {.SKUId = 3, .ProductId = 2, .Description = "Email"},
     New Sku With {.SKUId = 4, .ProductId = 2, .Description = "APIRequest"}
    })

    _people = New List(Of Person)({
      New Person With {.PersonID = 1, .FirstName = "Emily", .LastName = "X", .ProductId = 1, .SkuId = 1},
      New Person With {.PersonID = 2, .FirstName = "Brett", .LastName = "X", .ProductId = 2, .SkuId = 3}
                                  })
    For Each p In _people
      Dim row As DataRow = ds.Tables("tPeople").NewRow
      row("PersonId") = p.PersonID
      row("FirstName") = p.FirstName
      row("LastName") = p.LastName
      row("ProductId") = p.ProductId
      row("SkuId") = p.SkuId
      ds.Tables("tPeople").Rows.Add(row)
    Next

    dgv.AutoGenerateColumns = False
    dgv.DataSource = ds.Tables("tPeople")
    dgv.Refresh()

    For Each row As DataGridViewRow In dgv.Rows
      ArrangeValuesForSKUComboBox(row)
    Next

    _initialLoadDone = True
  End Sub

  Private Sub ArrangeValuesForSKUComboBox(row As DataGridViewRow)
    Dim productId = CInt(row.Cells("ProductId")?.Value)
    Dim skus = _SKUs.Where(Function(x) x.ProductId = productId).ToList().Select(Function(x) New With {Key .SkuId = x.SKUId, .SkuDesc = x.Description}).ToList()

    Dim thing = row.Cells("SKU")
    Dim combobox = CType(thing, DataGridViewComboBoxCell)
    combobox.DataSource = skus
    combobox.ValueMember = "SKUId"
    combobox.DisplayMember = "SkuDesc"
    combobox.Value = skus.FirstOrDefault()?.SkuId
  End Sub

  Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
    If _initialLoadDone Then
      Dim headerText As String = TryCast(sender, DataGridView).Columns(e.ColumnIndex).HeaderText
      If headerText = "PRODUCT" Then
        ArrangeValuesForSKUComboBox(dgv?.CurrentRow)
      End If
    End If
  End Sub
End Class