Imports ADODataAccess

Public Class TreeView
  Public Class ProductFormatChange
    Public Property ProductFormatChangeId As Integer
    Public Property ProductId As Integer
    Public Property ParentProductFormatChangeId As Integer
    Public Property ProductFormatId As Integer
    Public Property RecoveryRate As Decimal
    Public Property UOM As Integer
    Public Property LastModifiedDate As DateTime
    Public Property LastModifiedBy As String
    Public Property ProductDescription As String
    Public Property Active_Flag As Boolean
  End Class

  Public Enum EUOM
    Lbs = 1
    Ounces = 2
    Dozen = 3
    Bushel = 4
  End Enum

  Private _talker = New SQLTalker(GetCentralTestDatabase)
  Private _productFormatChanges As New List(Of ProductFormatChange)
  Private _products As New List(Of Product)
  Private _UOMs As New Dictionary(Of Integer, String)
  Private _productFormats As New Dictionary(Of Integer, String)

  Private Sub TreeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    For Each uom As EUOM In [Enum].GetValues(GetType(EUOM))
      _UOMs.Add(CInt(uom), uom.ToString)
    Next

    _products = DirectCast(DataConverter.ConvertTo(Of Product)(_talker.GetData("Select ProductId,	Description, Active_Flag from dbo.tCentral_Product WHERE ProductId In (21,22)")), List(Of Product))

    Dim productFormats = _talker.GetData("Select ProductFormatId, ProductFormatDescription From dbo.tCentral_ProductFormat")
    For Each row As DataRow In productFormats.Rows
      _productFormats.Add(row("ProductFormatId"), row("ProductFormatDescription"))
    Next

    _productFormatChanges = DirectCast(DataConverter.ConvertTo(Of ProductFormatChange)(_talker.GetData("EXEC dbo.APC_SP_SELECT_ProductFormatChange 0, NULL, NULL")), List(Of ProductFormatChange))

    TreeViewLoad()
  End Sub

  Private Structure Noder
    Public Property Key As String
    Public Property Text As String
    Public Property Active As Boolean
  End Structure

  Private Sub TreeViewLoad()
    treeProductFormatChanges.Nodes.Clear()

    Dim ReturnDescription As Func(Of ProductFormatChange, Noder) = Function(prod)
                                                                     Dim productFormat = _productFormats.SingleOrDefault(Function(y) y.Key = prod.ProductFormatId)
                                                                     Dim uomDesc = _UOMs.SingleOrDefault(Function(y) y.Key = prod.UOM)
                                                                     Return New Noder With {
                                                                        .Key = prod?.ProductFormatChangeId.ToString,
                                                                        .Text = $"{productFormat.Value} - {uomDesc.Value} - {(prod.RecoveryRate * 100).ToString("N2")}%",
                                                                        .Active = prod.Active_Flag
                                                                     }
                                                                   End Function

    Dim ReturnActiveColor As Func(Of Boolean, Color) = Function(active) If(active, Color.Black, Color.LightGray)

    _productFormatChanges.ForEach(Sub(x)
                                    Dim val = ReturnDescription(x)
                                    Dim parent = _productFormatChanges.FirstOrDefault(Function(y) y.ProductFormatChangeId = x.ParentProductFormatChangeId)
                                    Dim parentVal = If(parent IsNot Nothing,
                                      ReturnDescription(parent),
                                      New Noder With {
                                        .Key = _products.SingleOrDefault(Function(y) y.ProductId = x.ProductId)?.Description?.ToUpper,
                                        .Text = _products.SingleOrDefault(Function(y) y.ProductId = x.ProductId)?.Description?.ToUpper,
                                        .Active = _products.SingleOrDefault(Function(y) y.ProductId = x.ProductId)?.Active_Flag
                                      }
                                    )

                                    If parentVal.Key <> "0" Then
                                      Dim nodes As New List(Of TreeNode)
                                      nodes.AddRange(treeProductFormatChanges.Nodes.Find(parentVal.Key, True))

                                      If Not nodes.Any Then
                                        Dim pnode As TreeNode = treeProductFormatChanges.Nodes.Add(parentVal.Key, parentVal.Text)
                                        pnode.NodeFont = New Font("Tahoma", "12", FontStyle.Bold, Nothing)
                                        pnode.ForeColor = ReturnActiveColor(parentVal.Active)

                                        nodes.Add(pnode)
                                      End If

                                      Dim node As TreeNode = New TreeNode(val.Key)
                                      node.Text = val.Text
                                      node.ForeColor = ReturnActiveColor(parentVal.Active)
                                      nodes(0).Nodes.Add(node)
                                    End If
                                  End Sub)

    treeProductFormatChanges.Sort()
    treeProductFormatChanges.ExpandAll()
  End Sub

  End Class