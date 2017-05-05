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

  Sub Main()

    Dim dt As DataTable = New DataTable()
    dt.Columns.Add(New DataColumn("Id", GetType(Integer)))
    dt.Columns.Add(New DataColumn("Id2", GetType(Integer)))
    dt.Columns.Add(New DataColumn("Id3", GetType(Integer)))

    For i = 1 To 5
      Dim row As DataRow = dt.NewRow
      row("Id") = i
      row("Id2") = i + 1
      row("Id3") = i + 2
      dt.Rows.Add(row)
    Next

    For Each row In dt.Select(Nothing, Nothing, DataViewRowState.CurrentRows)
      For Each column In dt.Columns
        Console.Write(vbTab & row(column).ToString())
      Next

      Dim rowState As String =
            System.Enum.GetName(row.RowState.GetType(), row.RowState)
      Console.WriteLine(vbTab & rowState)
    Next

    Dim x = 1
    Dim y = 2
    Dim z = 3

    Dim exists = If(dt.Select($"Id = {x} And Id2 = {y} And Id3 = {z}").Length > 0, True, False)
    'dt.Select().ToList().Exists(Function(a) a("Id") = x And a("Id2") = y And a("Id3") = z)

    Console.WriteLine(exists)

    'Dim ls = New List(Of String)

    'Using myReader As New APCLocal.Select.test("DEV-APC1")
    '  Do While myReader.Read
    '    ls.Add(APCLocal.Select.test.EStrings.ProductionPlanGroupDescription)
    '  Loop
    'End Using

    'Console.WriteLine(ls.Count)

    'Dim scores = New List(Of Integer)

    'For i = 0 To 4
    '  Dim previousScore = 0
    '  Dim score = (i + 1) * 100
    '  scores.Add(score)
    '  If ((i - 1) >= 0) Then
    '    previousScore = scores(i - 1)
    '  End If

    '  Console.WriteLine($"Current Score {score} Previous Score{previousScore}")
    'Next

    'Dim allocations =
    '  New DemandAS400LocationDistributionDateAllocationCollection(
    '   New DemandAS400LocationDistributionDateAllocations(New DemandAS400LocationDistribution(1, "1", "1", "1", "Test"), DateTime.Now.Date.AddDays(-2).ToShortDateString,
    '      New DemandAS400LocationDistributionDateAllocation(1, 23, DateTime.Now.Date.AddDays(-7), 0.5),
    '      New DemandAS400LocationDistributionDateAllocation(2, 49, DateTime.Now.Date.AddDays(-5), 0.5)),
    '  New DemandAS400LocationDistributionDateAllocations(New DemandAS400LocationDistribution(1, "1", "1", "1", "Test"), DateTime.Now.Date.AddDays(-1).ToShortDateString,
    '      New DemandAS400LocationDistributionDateAllocation(3, 23, DateTime.Now.Date.AddDays(-3), 0.55),
    '      New DemandAS400LocationDistributionDateAllocation(4, 49, DateTime.Now.Date.AddDays(-1), 0.45)))

    'Dim serialized = allocations.SerializeToXml()

    'Dim deserialized = serialized.DeserializeXml(Of DemandAS400LocationDistributionDateAllocationCollection)
    'Console.WriteLine($"{allocations.Distributions.OrderBy(Function(x) x.DateAllocated).FirstOrDefault()?.ParentDemandAS400LocationDistribution.ToString}  
    '  {allocations.Distributions.OrderBy(Function(x) x.DateAllocated).FirstOrDefault()?.DateAllocated.ToShortDateString} 
    '  {allocations.Distributions.OrderByDescending(Function(x) x.DateAllocated).FirstOrDefault()?.DateAllocated.ToShortDateString}")

    Console.ReadLine()
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module

