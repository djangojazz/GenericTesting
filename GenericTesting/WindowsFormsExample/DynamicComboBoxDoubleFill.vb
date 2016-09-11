Imports ADODataAccess
Imports System.Linq

Public Class DynamicComboBoxDoubleFill

  Private _people = New List(Of Person)
  Private _products = New List(Of Product)
  Private _Skus = New List(Of Sku)

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

    _Skus = New List(Of Sku)({
     New Sku With {.SKUId = 1, .ProductId = 1, .Description = "Mail"},
     New Sku With {.SKUId = 2, .ProductId = 1, .Description = "Magazine"},
     New Sku With {.SKUId = 3, .ProductId = 2, .Description = "Email"},
     New Sku With {.SKUId = 4, .ProductId = 2, .Description = "APIRequest"}
    })

    _people = New List(Of Person)({
      New Person With {.PersonID = 1, .FirstName = "Emily", .LastName = "X", .ProductId = 1},
      New Person With {.PersonID = 2, .FirstName = "Brett", .LastName = "X", .ProductId = 2}
                                  })

    'Personally I don't like the binding to the Dataset in the designer.  I only do it because if I bind a 'datasource' to a list I get a data error for the datagridview that I need to handle
    'it would be much simple to just bind directly to my lists but I don't like handling the data error as it is annoying
    For Each p In _people
      Dim row As DataRow = ds.Tables("tPeople").NewRow
      row("PersonId") = p.PersonId
      row("FirstName") = p.FirstName
      row("LastName") = p.LastName
      row("ProductId") = p.ProductId
      ds.Tables("tPeople").Rows.Add(row)
    Next

    'For Each row As DataGridViewRow In dgv.Rows
    '  Dim cells = row.Cells
    '  For Each cell As DataGridViewCell In cells
    '    If cell.ColumnIndex = 4 Then

    '    End If
    '  Next
    'Next
  End Sub
End Class