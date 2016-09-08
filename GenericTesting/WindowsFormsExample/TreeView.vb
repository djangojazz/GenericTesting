Imports ADODataAccess

Public Class TreeView
  Public Class ProductFormatChange
    'Public Sub New(productID As Integer, productFormatId As Integer, productFormatChangeId As Integer, parentProductFormatChangeId As Integer)
    '  Me.ProductId = productID
    '  Me.ProductFormatId = productFormatId
    '  Me.ProductFormatChangeId = productFormatChangeId
    '  Me.ParentProductFormatChangeId = parentProductFormatChangeId
    'End Sub

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
  Private _selectedProductFormatChange As ProductFormatChange = Nothing

  Private Sub TreeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    For Each uom As EUOM In [Enum].GetValues(GetType(EUOM))
      _UOMs.Add(CInt(uom), uom.ToString)
    Next

    _products = DirectCast(DataConverter.ConvertTo(Of Product)(_talker.GetData("Select ProductId,	Description, Active_Flag from dbo.tCentral_Product")), List(Of Product))

    Dim productFormats = _talker.GetData("Select ProductFormatId, ProductFormatDescription From dbo.tCentral_ProductFormat")
    For Each row As DataRow In productFormats.Rows
      _productFormats.Add(row("ProductFormatId"), row("ProductFormatDescription"))
    Next

    _productFormatChanges = DirectCast(DataConverter.ConvertTo(Of ProductFormatChange)(_talker.GetData("EXEC dbo.APC_SP_SELECT_ProductFormatChange 0, NULL, NULL")), List(Of ProductFormatChange))

    TreeViewLoad()
  End Sub

  Private Function ReturnNodeFromProductFormatChange(productFormatChange As ProductFormatChange) As TreeNode
    Dim productFormat = _productFormats.SingleOrDefault(Function(y) y.Key = productFormatChange.ProductFormatId)
    Dim uomDesc = _UOMs.SingleOrDefault(Function(y) y.Key = productFormatChange.UOM)
    Dim genericTag = productFormatChange
    Dim genericNode = New TreeNode($"{productFormat.Value} - {uomDesc.Value} - {(productFormatChange.RecoveryRate * 100).ToString("N2")}%")
    genericNode.Tag = genericTag
    Return genericNode
  End Function


  Private Sub AttachChild(parentNode As TreeNode)
    Dim parentTag = TryCast(parentNode.Tag, ProductFormatChange)
    If parentTag Is Nothing Then Throw New ArgumentException("Must have a tag of Type Tuple(Of Integer, Integer)")

    Dim productFormatChange = _productFormatChanges.SingleOrDefault(Function(x) x.ProductId = parentTag.ProductId AndAlso x.ParentProductFormatChangeId = parentTag.ParentProductFormatChangeId)
    Dim childProductFormatChange = _productFormatChanges.SingleOrDefault(Function(x) x.ProductId = parentTag.ProductId AndAlso x.ParentProductFormatChangeId = productFormatChange.ProductFormatChangeId)

    If childProductFormatChange IsNot Nothing Then
      Dim childNode = ReturnNodeFromProductFormatChange(childProductFormatChange)

      AttachChild(childNode)
      parentNode.Nodes.Add(childNode)
    End If
  End Sub

  Private Sub TreeViewLoad()
    treeProductFormatChanges.Nodes.Clear()

    Dim ReturnActiveColor As Func(Of Boolean, Color) = Function(active) If(active, Color.Black, Color.LightGray)

    _productFormatChanges.Where(Function(x) x.ParentProductFormatChangeId = 0) _
      .ToList() _
      .ForEach(Sub(x)
                 Dim root = New TreeNode(x.ProductDescription?.Trim?.ToUpper)
                 root.NodeFont = New Font("Tahoma", CType("12", Single), FontStyle.Bold, Nothing)
                 root.ForeColor = ReturnActiveColor(x.Active_Flag)
                 Dim parentNode = ReturnNodeFromProductFormatChange(x)
                 parentNode.ForeColor = ReturnActiveColor(x.Active_Flag)
                 AttachChild(parentNode)
                 root.Nodes.Add(parentNode)
                 treeProductFormatChanges.Nodes.Add(root)
               End Sub)

    treeProductFormatChanges.Sort()
  End Sub

  Private Sub treeProductFormatChanges_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeProductFormatChanges.AfterSelect
    Dim tagOnSelectedItem = treeProductFormatChanges?.SelectedNode?.Tag

    If tagOnSelectedItem IsNot Nothing Then
      _selectedProductFormatChange = TryCast(tagOnSelectedItem, ProductFormatChange)

      mnuNewChildProductFormatChange.Visible = True
      mnuMaintainProductFormatChange.Visible = True
      mnuDeleteProductFormatChange.Visible = True
    Else
      mnuNewChildProductFormatChange.Visible = False
      mnuMaintainProductFormatChange.Visible = False
      mnuDeleteProductFormatChange.Visible = False
      Return
    End If

    Dim productFormatChangesForProductId = _productFormatChanges?.Where(Function(x) x.ProductId = _selectedProductFormatChange.ProductId).ToList()

    If productFormatChangesForProductId.Count = 1 Then mnuDeleteProductFormatChange.Visible = False
  End Sub

End Class