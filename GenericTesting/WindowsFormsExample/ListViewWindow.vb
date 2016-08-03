Imports ADODataAccess

Public Class ListViewWindow

  Private Structure SPerson
    Public PersonId As Integer
    Public FirstName As String
    Public LastName As String
  End Structure

  Private _talker = New SQLTalker(GetTesterDatabase)
  Private _people As New List(Of SPerson)

  Private Sub ListViewWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Cursor.Current = Cursors.WaitCursor
    Dim items = _talker.GetData("Select PersonId, FirstName, LastName from dbo.tePerson")
    For Each item In items.Rows
      Dim lvi = New ListViewItem(item("PersonId").ToString)
      lvi.SubItems.Add(item("FirstName").ToString)
      lvi.SubItems.Add(item("LastName").ToString)

      lsv.Items.Add(lvi)
      _people.Add(New SPerson With {.PersonId = item("PersonId"), .FirstName = item("FirstName"), .LastName = item("LastName")})
    Next


    'Using oRead As New APCLocal.Select.ProductionOutToAS400OrderDetail(u.CurrentServerIP, _productionID, productionOutId)
    '  Do While oRead.Read
    '    Dim lviNew As ListViewItem = lsvOrdersProduction.Items.Add(oRead.Int(APCLocal.Select.ProductionOutToAS400OrderDetail.EInts.ProductionOutID).ToString)
    '    lviNew.SubItems.Add(oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.CustomerNbr).Trim & "-" & oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.CustName).Trim)
    '    lviNew.SubItems.Add(oRead.Dbl(APCLocal.Select.ProductionOutToAS400OrderDetail.ENbr.OrderNbr).ToString)
    '    lviNew.SubItems.Add(oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.ItemNbr).Trim & "-" & oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.FIIDE1).Trim)
    '    lviNew.SubItems.Add(oRead.Dbl(APCLocal.Select.ProductionOutToAS400OrderDetail.ENbr.ExtCatchWgt).ToString("##,##0.00"))
    '    If oRead.Bool(APCLocal.Select.ProductionOutToAS400OrderDetail.EBools.OrderComplete) Then
    '      lviNew.ForeColor = Color.Gray
    '    End If
    '    Dim oTag As New SOrderProduction
    '    oTag.ProductionOutID = oRead.Int(APCLocal.Select.ProductionOutToAS400OrderDetail.EInts.ProductionOutID)
    '    oTag.Company = oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.CompanyNbr)
    '    oTag.Division = oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.DivisionNbr)
    '    oTag.Department = oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.DepartmentNbr)
    '    oTag.Customer = oRead.Str(APCLocal.Select.ProductionOutToAS400OrderDetail.EStrings.CustomerNbr)
    '    oTag.OrderNbr = oRead.Dbl(APCLocal.Select.ProductionOutToAS400OrderDetail.ENbr.OrderNbr)
    '    oTag.LineNbr = oRead.Dbl(APCLocal.Select.ProductionOutToAS400OrderDetail.ENbr.LineNbr)
    '    oTag.Weight = oRead.Dbl(APCLocal.Select.ProductionOutToAS400OrderDetail.ENbr.ExtCatchWgt)
    '    oTag.OrderDetailKey = oRead.Int(APCLocal.Select.ProductionOutToAS400OrderDetail.EInts.OrderDetailKey)
    '    lviNew.Tag = oTag
    '    _ProductionOrders.Add(oTag)
    '  Loop
    'End Using
  End Sub
End Class