Imports System.Runtime.CompilerServices
Imports System.Text

Public Module BasicDataTable
  Public Function CreateDataTableAndFillit() As DataTable
    Dim dt As DataTable = New DataTable()
    dt.Columns.Add(New DataColumn("Id", GetType(Integer)))
    dt.Columns.Add(New DataColumn("Val", GetType(String)))

    For i = 1 To 5
      Dim dr As DataRow = dt.NewRow()
      dr("Id") = i
      dr("Val") = $"Val {i}"
      dt.Rows.Add(dr)
    Next

    Return dt
  End Function

  <Extension>
  Public Function EnumerateTable(dt As DataTable) As String
    Dim buffer As New StringBuilder()
    For Each dc As DataColumn In dt.Columns
      buffer.Append($"{dc.ColumnName}{vbTab}")
    Next
    buffer.Append(Environment.NewLine)
    For Each dr As DataRow In dt.Rows
      For Each dc As DataColumn In dt.Columns
        buffer.Append($"{dr(dc)}{vbTab}")
      Next
      buffer.Append(Environment.NewLine)
    Next
    Return buffer.ToString()
  End Function
End Module
