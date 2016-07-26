Public Module InvoiceExample
  Public Class Invoice
    Public Property InvoiceDate As DateTime
    Public Property InvoiceType As Integer
    Public Property InvoiceAmount As Decimal
    Public Property NumberOfItems As Integer
  End Class

  Public Sub MainExample()
    Dim invoiceList As List(Of Invoice)

    invoiceList = New List(Of Invoice) From
                {New Invoice With
                      {
                        .InvoiceDate = New DateTime(2010, 4, 30),
                        .InvoiceType = 1,
                        .InvoiceAmount = 150,
                        .NumberOfItems = 8},
                New Invoice With
                      {
                        .InvoiceDate = New DateTime(2010, 4, 29),
                        .InvoiceType = 2,
                        .InvoiceAmount = 215,
                        .NumberOfItems = 7},
                New Invoice With
                      {
                        .InvoiceDate = New DateTime(2010, 4, 30),
                        .InvoiceType = 1,
                        .InvoiceAmount = 50,
                        .NumberOfItems = 2},
                New Invoice With
                      {
                        .InvoiceDate = New DateTime(2010, 4, 29),
                        .InvoiceType = 2,
                        .InvoiceAmount = 550,
                        .NumberOfItems = 5}}

    Dim query = invoiceList.
           GroupBy(Function(g) New With {Key g.InvoiceDate,
                                         Key g.InvoiceType}).
           Select(Function(group) New With {
              .InvoiceDate = group.Key.InvoiceDate,
              .InvoiceType = group.Key.InvoiceType,
              .TotalAmount = group.Sum(Function(a) a.InvoiceAmount),
              .TotalCount = group.Sum(Function(c) c.NumberOfItems)})

    For Each item In query
      Console.WriteLine("Invoice Date: {0} ({1}) TotalAmount: {2} TotalCount: {3}",
                          item.InvoiceDate.ToShortDateString(),
                          item.InvoiceType,
                          item.TotalAmount,
                          item.TotalCount)
    Next
  End Sub



End Module
