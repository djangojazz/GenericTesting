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

  <Serializable>
  Public Class DemandAS400LocationDistributionDateDistribution
    Public Property DemandAS400LocationDistributionDateDistributionID As Integer
    <XmlAttribute>
    Public Property DemandAS400LocationDistributionID As Integer
    <XmlAttribute>
    Public Property PercentUsed As Double
  End Class

  <Serializable>
  <XmlRoot("locations")>
  Public Class DemandAS400LocationDistributionDateDistributions

    <XmlAttribute>
    Public Property DateFrom As DateTime
    <XmlAttribute>
    Public Property DateTo As DateTime

    <XmlElement("location")>
    Public Property locations As List(Of DemandAS400LocationDistributionDateDistribution)
  End Class
End Module
