Imports System.Collections.ObjectModel
Imports System.Xml.Serialization

<Serializable>
Public Class DemandPlanInquiry

  'PROPERTIES
  Public Property FIKey As Integer

  Public Property DemandDate As Date?

  Public Property LocationCollection As New List(Of Integer)

  Public Property ChartDatesCollection As New List(Of Integer)

End Class