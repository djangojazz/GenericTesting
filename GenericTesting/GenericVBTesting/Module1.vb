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

Module Module1

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _products As New List(Of Product)

  Private example As New Lazy(Of String())(Function()
                                             Return "example split".Split(" "c)
                                           End Function)

  Public Sub ExamineForReUseOfCommonMethod(o As Object)
    Select Case True
      Case TypeOf o Is X Or TypeOf o Is Y
        o.DoIt()
      Case TypeOf o Is Z
        o.DoItDifferent()
    End Select
  End Sub

  Public Class X
    Public Property Name As String

    Public Sub DoIt()
      Console.WriteLine("I am X's Do It!")
    End Sub
  End Class

  Public Class Y
    Public Property Name As String

    Public Sub DoIt()
      Console.WriteLine("I am Y's Do It!")
    End Sub
  End Class

  Public Class Z
    Public Property Name As String

    Public Sub DoItDifferent()
      Console.WriteLine("I am slightly different at Z!")
    End Sub
  End Class

  Sub Main()
    Dim p = New X With {.Name = "P"}
    Dim q = New Y With {.Name = "Q"}
    Dim r = New Z With {.Name = "R"}

    ExamineForReUseOfCommonMethod(p)
    ExamineForReUseOfCommonMethod(q)
    ExamineForReUseOfCommonMethod(r)
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

