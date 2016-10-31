Imports ADODataAccess

Public Class TreeView

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _selectedTreeTest As TreeTest = Nothing
  Private _lastIndex As Integer

  Private Sub TreeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TreeViewLoad()
  End Sub

  Private Function ReturnNodeFromProductFormatChange(item As TreeTest) As TreeNode
    Dim genericNode = New TreeNode($"{item.Id} - {item.Val}")
    genericNode.Tag = item
    Return genericNode
  End Function


  Private Sub AttachChild(parentNode As TreeNode)
    Dim childProductFormatChange = _treeResults.SingleOrDefault(Function(x) x.ParentId = TryCast(parentNode.Tag, TreeTest).Id)

    If childProductFormatChange IsNot Nothing Then
      Dim childNode = ReturnNodeFromProductFormatChange(childProductFormatChange)

      AttachChild(childNode)
      parentNode.Nodes.Add(childNode)
    End If
  End Sub

  Private Sub TreeViewLoad()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    treeProductFormatChanges.Nodes.Clear()

    Dim ReturnActiveColor As Func(Of Boolean, Color) = Function(active) If(active, Color.Black, Color.LightGray)

    _treeResults.Where(Function(x) x.ParentId = 0) _
      .ToList() _
      .ForEach(Sub(x)
                 Dim root = New TreeNode(x.Val.ToCharArray().Count.ToString)
                 root.NodeFont = New Font("Tahoma", CType("12", Single), FontStyle.Bold, Nothing)
                 root.ForeColor = ReturnActiveColor(x.Active)
                 Dim parentNode = ReturnNodeFromProductFormatChange(x)
                 parentNode.ForeColor = ReturnActiveColor(x.Active)
                 AttachChild(parentNode)
                 root.Nodes.Add(parentNode)
                 treeProductFormatChanges.Nodes.Add(root)
               End Sub)

    treeProductFormatChanges.Nodes(_lastIndex).ExpandAll()
  End Sub

  Private Sub GetRootNode(node As TreeNode)
    If Not node.Parent Is Nothing Then
      GetRootNode(node.Parent)
    Else
      _lastIndex = node.Index
    End If
  End Sub

  Private Sub treeProductFormatChanges_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeProductFormatChanges.AfterSelect

    Dim tagOnSelectedItem = treeProductFormatChanges?.SelectedNode?.Tag
    

    If tagOnSelectedItem IsNot Nothing Then
      _selectedTreeTest = TryCast(tagOnSelectedItem, TreeTest)
      txt.Text = String.Empty
      GetRootNode(treeProductFormatChanges?.SelectedNode)

      mnuNewChildProductFormatChange.Visible = True
      mnuMaintainProductFormatChange.Visible = True
      mnuDeleteProductFormatChange.Visible = True
    Else
      mnuNewChildProductFormatChange.Visible = False
      mnuMaintainProductFormatChange.Visible = False
      mnuDeleteProductFormatChange.Visible = False
      Return
    End If
  End Sub

  Private Sub cmnuClicks(sender As Object, e As EventArgs) Handles treeProductFormatChanges.DoubleClick, mnuNewChildProductFormatChange.Click, mnuMaintainProductFormatChange.Click, mnuDeleteProductFormatChange.Click
    If _selectedTreeTest IsNot Nothing Then
      Select Case True
        Case sender Is mnuNewChildProductFormatChange : Using form As New TreeUpdate(0, "Hey", TreeUpdate.Type.Create) : End Using
        Case sender Is mnuMaintainProductFormatChange, sender Is treeProductFormatChanges
          Using form As New TreeUpdate(_selectedTreeTest.Id, _selectedTreeTest.Val, TreeUpdate.Type.Update)
            form.ShowDialog()
          End Using
        Case sender Is mnuDeleteProductFormatChange : Using form As New TreeUpdate(_selectedTreeTest.Id, _selectedTreeTest.Val, TreeUpdate.Type.Delete) : End Using
      End Select
    End If

    TreeViewLoad()
  End Sub
End Class