Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Threading
Imports System.Collections.ObjectModel
Imports ADODataAccess
Imports GenericVBTesting.Models
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Data.SqlClient
Imports System.IO

Module Module1

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _products As New List(Of Product)

  Public Sub WriteTextToFile(text As String, location As String)
    Using sw = New StreamWriter(location)
      sw.Write(text)
    End Using
  End Sub

  Public Enum test
    A = 1
    B = 2
    C = 3
  End Enum

  Sub Main()
    Dim dt = CreateDataTableAndFillit(1, 3, "Test")
    Dim dt2 = CreateDataTableAndFillit(1, 2, "More")
    Dim t As New List(Of Tuple(Of Integer, Integer, Integer))
    Dim newRow = dt.NewRow
    newRow("Id") = 1
    newRow("Val") = "Test 12"
    dt.Rows.Add(newRow)

    Dim stuff = dt.Select().Select(Function(x) New With {Key .Id = CInt(x("Id")), .Val = CStr(x("Val"))}).ToList()
    Dim stuff2 = dt2.Select().Select(Function(x) New With {Key .Id = CInt(x("Id")), .Val = CStr(x("Val"))}).ToList()

    t = stuff.GroupBy(Function(x) x.Id).Select(Function(x) New Tuple(Of Integer, Integer, Integer)(x.Key, x.Count(Function(y) Not String.IsNullOrEmpty(y.Val)), 0)).ToList()

    Dim combined = t.GroupJoin(stuff2, Function(x) x.Item1, Function(y) y.Id, Function(a, b) New With {.Id = a.Item1, .Val = a.Item2, .ValMore = b.FirstOrDefault()?.Val}).ToList()



    Console.ReadLine()
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module

