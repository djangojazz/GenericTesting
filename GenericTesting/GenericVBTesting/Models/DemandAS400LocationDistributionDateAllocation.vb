Imports System.Xml.Serialization

<Serializable, XmlRoot("location")>
  Public NotInheritable Class DemandAS400LocationDistributionDateAllocation

    'PROPERTIES
    <XmlIgnore>
    Public Property DemandAS400LocationDistributionDateAllocationId As Integer
    <XmlAttribute>
    Public Property DemandAS400LocationDistributionID As Integer
    <XmlIgnore>
    Public Property DateAllocated As DateTime
    <XmlAttribute>
    Public Property PercentUsed As Decimal

    Public Sub New()
    End Sub


    Public Sub New(demandAS400LocationDistributionDateAllocationID As Integer, demandAS400LocationDistributionID As Integer, dateAllocated As DateTime, percentUsed As Decimal)
      Me.DemandAS400LocationDistributionDateAllocationId = demandAS400LocationDistributionDateAllocationID
      Me.DemandAS400LocationDistributionID = demandAS400LocationDistributionID
      Me.DateAllocated = dateAllocated
      Me.PercentUsed = percentUsed
    End Sub

    Public Overrides Function ToString() As String
      Return $"{DemandAS400LocationDistributionID}-{DateAllocated.ToShortDateString}-{PercentUsed}"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf obj Is DemandAS400LocationDistributionDateAllocation AndAlso DirectCast(obj, DemandAS400LocationDistributionDateAllocation).DemandAS400LocationDistributionDateAllocationId = Me.DemandAS400LocationDistributionDateAllocationId
    End Function

    Public Overrides Function GetHashCode() As Integer
      Return DemandAS400LocationDistributionDateAllocationId.GetHashCode()
    End Function

  End Class

  <Serializable, XmlRoot("distribution")>
  Public NotInheritable Class DemandAS400LocationDistributionDateAllocations

    <XmlIgnore>
    Public Property ParentDemandAS400LocationDistribution As DemandAS400LocationDistribution

    <XmlAttribute>
    Public Property DateAllocated As DateTime

    <XmlElement("location")>
    Public Property Locations As List(Of DemandAS400LocationDistributionDateAllocation)

    Public Sub New(parentDemandAS400LocationDistribution As DemandAS400LocationDistribution, dateAllocated As DateTime, ParamArray location() As DemandAS400LocationDistributionDateAllocation)
      Me.ParentDemandAS400LocationDistribution = parentDemandAS400LocationDistribution
      Me.DateAllocated = dateAllocated
      Me.Locations = location.ToList
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
      If TypeOf obj Is DemandAS400LocationDistributionDateAllocations Then
        Dim o = DirectCast(obj, DemandAS400LocationDistributionDateAllocations)
        Return (o.DateAllocated = Me.DateAllocated And o.ParentDemandAS400LocationDistribution?.DemandAS400LocationDistributionID = Me.ParentDemandAS400LocationDistribution?.DemandAS400LocationDistributionID).Value
      End If
    End Function

    Public Overrides Function GetHashCode() As Integer
      Return ParentDemandAS400LocationDistribution.GetHashCode()
    End Function
  End Class

  <Serializable, XmlRoot("distributions")>
  Public NotInheritable Class DemandAS400LocationDistributionDateAllocationCollection
    <XmlElement("distribution")>
    Public Property Distributions As New List(Of DemandAS400LocationDistributionDateAllocations)

    Public Sub New(ParamArray distribution() As DemandAS400LocationDistributionDateAllocations)
      Me.Distributions = distribution.ToList()
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
      If TypeOf obj Is DemandAS400LocationDistributionDateAllocationCollection Then
        Dim o = DirectCast(obj, DemandAS400LocationDistributionDateAllocationCollection)
        If o.Distributions.Any And Me.Distributions.Any Then
          Return (o?.Distributions(0)?.ParentDemandAS400LocationDistribution?.DemandAS400LocationDistributionID = Me.Distributions(0)?.ParentDemandAS400LocationDistribution?.DemandAS400LocationDistributionID).Value
        Else
          Return (Not o?.Distributions.Any And Not Me?.Distributions.Any).Value
        End If
      End If

      Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
      Return Distributions.GetHashCode()
    End Function
End Class