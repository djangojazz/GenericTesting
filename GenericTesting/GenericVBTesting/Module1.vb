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
    'Dim allowedValues = "abcdefghijklmnopqrstuvwxyz".ToCharArray()
    'Dim someGoodSomeBad = "#@#$#@okay@#$#@"

    'Dim onlyGood = New String(someGoodSomeBad.ToCharArray().Where(Function(x) allowedValues.Contains(x)).ToArray)

    'Console.WriteLine(onlyGood)

    Dim nProcess = New System.Diagnostics.Process()
    nProcess.Start($"D:\Learning\BasicsOfCompilerDesign.pdf")



    Console.ReadLine()
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module
