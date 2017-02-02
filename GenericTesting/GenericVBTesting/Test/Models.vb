Imports System.Xml.Serialization

Public Module Models
  Public Class POCO
    Public Property ID As Integer
    Public Property ParentID As Integer
    Public Property Value As String
  End Class

  Public Class POCO2
    Public Property ID As Integer
    Public Property Value As String
  End Class

  Public Function GetPOOCs() As List(Of POCO)
    Return New List(Of POCO)({
                             New POCO With {.ID = 1, .ParentID = 0, .Value = "A"},
                             New POCO With {.ID = 2, .ParentID = 1, .Value = "B"},
                             New POCO With {.ID = 3, .ParentID = 2, .Value = "C"}
                    })
  End Function

  Public Function GetPOOCs2() As List(Of POCO2)
    Return New List(Of POCO2)({New POCO2 With {.ID = 3, .Value = "C"}})
  End Function

  <Serializable, XmlRoot("location")>
  Public Class DemandAS400LocationDistributionDateDistribution
    <XmlAttribute>
    Public Property DemandAS400LocationDistributionID As Integer
    <XmlAttribute>
    Public Property PercentUsed As Double

    Public Sub New(demandAS400LocationDistributionID As Integer, percentUsed As Double)
      Me.DemandAS400LocationDistributionID = demandAS400LocationDistributionID
      Me.PercentUsed = percentUsed
    End Sub

    Public Sub New()
    End Sub
  End Class

  <Serializable, XmlRoot("distribution")>
  Public Class DemandAS400LocationDistributionDateDistributions

    <XmlAttribute>
    Public Property DateAllocated As DateTime

    <XmlElement("location")>
    Public Property Locations As List(Of DemandAS400LocationDistributionDateDistribution)

    Public Sub New(dateAllocated As DateTime, ParamArray location() As DemandAS400LocationDistributionDateDistribution)
      Me.DateAllocated = dateAllocated
      Me.Locations = location.ToList
    End Sub

    Public Sub New()
    End Sub
  End Class

  <Serializable, XmlRoot("distributions")>
  Public Class DemandAS400LocationDistributionDateDistributionCollection
    <XmlElement("distribution")>
    Public Property Distributions As List(Of DemandAS400LocationDistributionDateDistributions)

    Public Sub New(ParamArray distribution() As DemandAS400LocationDistributionDateDistributions)
      Me.Distributions = distribution.ToList()
    End Sub

    Public Sub New()
    End Sub
  End Class
End Module
