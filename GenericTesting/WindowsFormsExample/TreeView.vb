Imports ADODataAccess

Public Class TreeView
  Public Class ProductFormatChange
    Public Property ProductFormatChangeId As Integer
    Public Property ProductFormatChangeDescription As String
    Public Property ProductId As Integer
    Public Property ParentProductFormatChangeId As Integer
    Public Property ProductFormatId As Integer
    Public Property RecoveryRate As Decimal
    Public Property UOM As Integer
  End Class

  Private _talker = New SQLTalker(GetCentralTestDatabase)
  Private _productChangeFormats As New List(Of ProductFormatChange)
  Private _products As New List(Of Product)
  Private _UOMs As New Dictionary(Of Integer, String)
  Private _productFormats As New Dictionary(Of Integer, String)

  Private Sub TreeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    _products = DirectCast(DataConverter.ConvertTo(Of Product)(_talker.GetData("Select ProductId,	Description from dbo.tCentral_Product WHERE Active_Flag = 1")), List(Of Product))
    Dim productFormats = _talker.GetData("Select ProductFormatId, ProductFormatDescription From dbo.tCentral_ProductFormat")

    For Each row As DataRow In productFormats.Rows
      _productFormats.Add(row("ProductFormatId"), row("ProductFormatDescription"))
    Next

    _UOMs = New Dictionary(Of Integer, String) From {{1, "Lbs"}, {2, "Ounces"}, {3, "Dozen"}, {4, "Bushel"}}
    _productChangeFormats = DirectCast(DataConverter.ConvertTo(Of ProductFormatChange)(_talker.GetData("SELECT ProductFormatChangeId, ProductFormatChangeDescription, ProductId, ParentProductFormatChangeId, ProductFormatId, RecoveryRate, UOM from dbo.tCentral_ProductFormatChange")), List(Of ProductFormatChange))


    TreeViewLoad()
  End Sub

  Private Sub TreeViewLoad()
    Dim ReturnDescription As Func(Of ProductFormatChange, String) = Function(prod)
                                                                      Dim productFormat = _productFormats.SingleOrDefault(Function(y) y.Key = prod.ProductFormatId)
                                                                      Dim uomDesc = _UOMs.SingleOrDefault(Function(y) y.Key = prod.UOM)
                                                                      Return $"{prod.ProductFormatChangeDescription} - ProductFormat: {productFormat.Value} - UOM: {uomDesc.Value}"
                                                                    End Function

    _productChangeFormats.ForEach(Sub(x)
                                    Dim desc = ReturnDescription(x)
                                    Dim parent = _productChangeFormats.FirstOrDefault(Function(y) y.ProductFormatChangeId = x.ParentProductFormatChangeId)
                                    Dim parentDescription = If(parent IsNot Nothing, ReturnDescription(parent), _products.SingleOrDefault(Function(y) y.ProductId = x.ProductId)?.Description?.ToUpper?.Trim)

                                    If parentDescription IsNot Nothing Then
                                      Dim node As New List(Of TreeNode)
                                      node.AddRange(treeProductFormats.Nodes.Find(parentDescription, True))
                                      If Not node.Any Then
                                        node.Add(treeProductFormats.Nodes.Add(parentDescription, parentDescription))
                                      End If
                                      node(0).Nodes.Add(desc, desc)
                                    End If
                                  End Sub)

    treeProductFormats.ExpandAll()
End Sub

End Class