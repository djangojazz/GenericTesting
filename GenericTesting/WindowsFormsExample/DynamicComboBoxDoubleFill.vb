Imports ADODataAccess
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions

Public Class DynamicComboBoxDoubleFill

  Private _people As List(Of Person) = New List(Of Person)
  Private _products As List(Of Product) = New List(Of Product)
  Private _SKUs As List(Of Sku) = New List(Of Sku)

  Private Sub DynamicComboBoxDoubleFill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Dim items = _SKUs

    _people = New List(Of Person)({
      New Person With {.PersonID = 1, .FirstName = "Emily", .LastName = "X", .ProductId = 1, .SkuId = 1},
      New Person With {.PersonID = 2, .FirstName = "Brett", .LastName = "X", .ProductId = 2, .SkuId = 3}
                                  })

    'Personally I don't like the binding to the Dataset in the designer.  I only do it because if I bind a 'datasource' to a list I get a data error for the datagridview that I need to handle
    'it would be much simple to just bind directly to my lists but I don't like handling the data error as it is annoying
    For Each p In _people
      Dim row As DataRow = ds.Tables("tPeople").NewRow
      row("PersonId") = p.PersonId
      row("FirstName") = p.FirstName
      row("LastName") = p.LastName
      row("ProductId") = p.ProductId
      row("SkuId") = p.SkuId
      ds.Tables("tPeople").Rows.Add(row)
    Next

    For Each row As DataGridViewRow In dgv.Rows
      Dim cells = row.Cells
      Dim productId = 0
      Dim personId = 0
      Dim SkuId = 0

      For Each cell As DataGridViewCell In cells
        If cell.ColumnIndex = 0 Then
          productId = cell.Value
        End If

        If cell.ColumnIndex = 1 Then
          personId = cell.Value
        End If

        If cell.ColumnIndex = 4 Then
          Dim skus = _SKUs.Where(Function(x) x.ProductId = productId).ToList().Select(Function(x) New With {Key .SkuId = x.SKUId, .SkuDesc = x.Description}).ToList()
          Dim combobox = CType(cell, DataGridViewComboBoxCell)
          combobox.DataSource = skus
          combobox.ValueMember = "SKUId"
          combobox.DisplayMember = "SkuDesc"
          combobox.Value = _people.SingleOrDefault(Function(x) x.PersonID = personId)?.SkuId
          'combobox.DataGridView.DataMember = "SKUId"
          'What should be done here to hook up values as pointers as 'Display Member' and 'Value member' are not available and CTYPe to DataGridViewComboBox is not available?
          'cell.Value = "SkuId"
          'cell.Displayed = "SkuDesc"
          'cell.DefaultNewRowValue = skus.First()
        End If
      Next
    Next
  End Sub
End Class