Imports ADODataAccess

Public Class TreeView

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _selectedTreeTest As TreeTest = Nothing

  Private Sub TreeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim data = _talker.GetData("SELECT * From dbo.TreeTest")

    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(data), List(Of TreeTest))

    'TreeViewLoad()
  End Sub

  'Private Function ReturnNodeFromProductFormatChange(item As TreeTest) As TreeNode
  '  Dim genericNode = New TreeNode($"{item.Id} - {item.Val}")
  '  genericNode.Tag = item
  '  Return genericNode
  'End Function


  'Private Sub AttachChild(parentNode As TreeNode)
  '  Dim childProductFormatChange = _treeResults.SingleOrDefault(Function(x) x.ParentId = TryCast(parentNode.Tag, TreeTest).Id)

  '  If childProductFormatChange IsNot Nothing Then
  '    Dim childNode = ReturnNodeFromProductFormatChange(childProductFormatChange)

  '    AttachChild(childNode)
  '    parentNode.Nodes.Add(childNode)
  '  End If
  'End Sub

  'Private Sub TreeViewLoad()
  '  treeProductFormatChanges.Nodes.Clear()

  '  Dim ReturnActiveColor As Func(Of Boolean, Color) = Function(active) If(active, Color.Black, Color.LightGray)

  '  _treeResults.Where(Function(x) x.ParentId = 0) _
  '    .ToList() _
  '    .ForEach(Sub(x)
  '               Dim root = New TreeNode(x.Val.ToCharArray().Count.ToString)
  '               root.NodeFont = New Font("Tahoma", CType("12", Single), FontStyle.Bold, Nothing)
  '               root.ForeColor = ReturnActiveColor(x.Active)
  '               Dim parentNode = ReturnNodeFromProductFormatChange(x)
  '               parentNode.ForeColor = ReturnActiveColor(x.Active)
  '               AttachChild(parentNode)
  '               root.Nodes.Add(parentNode)
  '               treeProductFormatChanges.Nodes.Add(root)
  '             End Sub)

  '  treeProductFormatChanges.Sort()
  'End Sub

  Private Sub treeProductFormatChanges_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeProductFormatChanges.AfterSelect
    'Dim tagOnSelectedItem = treeProductFormatChanges?.SelectedNode?.Tag

    'If tagOnSelectedItem IsNot Nothing Then
    '  _selectedProductFormatChange = TryCast(tagOnSelectedItem, ProductFormatChange)

    '  mnuNewChildProductFormatChange.Visible = True
    '  mnuMaintainProductFormatChange.Visible = True
    '  mnuDeleteProductFormatChange.Visible = True
    'Else
    '  mnuNewChildProductFormatChange.Visible = False
    '  mnuMaintainProductFormatChange.Visible = False
    '  mnuDeleteProductFormatChange.Visible = False
    '  Return
    'End If

    'Dim productFormatChangesForProductId = _productFormatChanges?.Where(Function(x) x.ProductId = _selectedProductFormatChange.ProductId).ToList()

    'If productFormatChangesForProductId.Count = 1 Then mnuDeleteProductFormatChange.Visible = False
  End Sub

End Class