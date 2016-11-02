Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Threading
Imports System.Collections.ObjectModel
Imports ADODataAccess
Imports GenericVBTesting.Models

Module Module1

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _products As New List(Of Product)

  Private example As New Lazy(Of String())(Function()
                                             Return "example split".Split(" "c)
                                           End Function)

  'Public Sub test()
  '  example.Value
  'End Sub

  Sub Main()
    Dim chars = New Char() {","c, " "c, "/"c}

    Using myReader As New APCLocal.Select.Products("DEV-APC1", True)
      Do While myReader.Read
        _products.Add(New Product With {.ProductId = myReader.Int(APCLocal.Select.Products.EInts.ProductID), .Description = myReader.Str(APCLocal.Select.Products.EStrings.Description)})
      Loop
    End Using

    Dim val = "SALAD"
    Dim val2 = "SHRIMP"

    Dim matchingProduct = _products.SingleOrDefault(Function(x) x.Description.Split(chars).First().ToUpper.Contains(val))
    'If that does not find anything try the second, else give up.  This could be done recursively potentially but how far do you want to take loose matching?
    If matchingProduct Is Nothing Then matchingProduct = _products.Where(Function(x) x.Description.Split(chars).First().ToUpper.Contains(val2))

    Console.ReadLine()
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module
