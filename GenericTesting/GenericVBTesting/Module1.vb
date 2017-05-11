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
Imports GenericVBTesting.Data.Objects.Serialization

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
    Dim dt = CreateDataTableAndFillit()
    Dim col = dt.Select("Id = 3").FirstOrDefault()

    Console.WriteLine(col("Val"))

    'col("Val") += "Brett"

    'Console.WriteLine(col("Val"))

    Console.ReadLine()
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module

