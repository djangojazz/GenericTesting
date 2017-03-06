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

  Sub Main()
    Dim ls = New List(Of DemandLocation)({
                                         New DemandLocation(1, "1", "1", "1", "Place A"),
                                         New DemandLocation(1, "1", "1", "2", "Place B"),
                                         New DemandLocation(1, "1", "1", "3", "Place C")
                                         })

    ls(2).IsUsed = True
    ls(0).IsUsed = True

    Dim itemsSelected = ls.Where(Function(x) x.IsUsed = True).Select(Function(x) x.ToString).ToList()
    Dim headerUpdated = If(itemsSelected.Any, String.Join(", ", itemsSelected), "No Items")

    Console.WriteLine(headerUpdated)

    'Dim allocations =
    '  New DemandAS400LocationDistributionDateAllocationCollection(
    '   New DemandAS400LocationDistributionDateDistributions(New DemandAS400LocationDistribution(1, "1", "1", "1", "Test"), DateTime.Now.Date.AddDays(-2).ToShortDateString,
    '      New DemandAS400LocationDistributionDateDistribution(23, 0.5),
    '      New DemandAS400LocationDistributionDateDistribution(49, 0.5)),
    '  New DemandAS400LocationDistributionDateDistributions(New DemandAS400LocationDistribution(1, "1", "1", "1", "Test"), DateTime.Now.Date.AddDays(-1).ToShortDateString,
    '      New DemandAS400LocationDistributionDateDistribution(23, 0.55),
    '      New DemandAS400LocationDistributionDateDistribution(49, 0.45)))

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

