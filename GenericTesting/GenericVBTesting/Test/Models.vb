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
  Public NotInheritable Class DemandAS400LocationDistribution

    'PROPERTIES
    Public Property DemandAS400LocationDistributionID As Integer
    Public Property BranchId As Integer
    Public Property CompanyNbr As String
    Public Property CompanyName As String
    Public Property DivisionNbr As String
    Public Property DivisionName As String
    Public Property BranchNbr As String
    Public Property BranchName As String
    Public Property ParentDemandAS400LocationDistributionID As Integer
    Public Property CanRemove As Boolean = True

    Public Sub New()
    End Sub

    Public Sub New(branchId As Integer, Optional companyNbr As String = Nothing, Optional divisionNbr As String = Nothing, Optional branchNbr As String = Nothing, Optional branchName As String = Nothing)
      Me.BranchId = branchId

      If companyNbr IsNot Nothing And divisionNbr IsNot Nothing And branchNbr IsNot Nothing And branchName IsNot Nothing Then
        Me.CompanyNbr = companyNbr
        Me.DivisionNbr = divisionNbr
        Me.BranchNbr = branchNbr
        Me.BranchName = branchName
      End If
    End Sub

    Public Sub New(demandAS400LocationDistributionID As Integer, branchId As Integer, companyNbr As String, companyName As String, divisionNbr As String, divisionName As String, branchNbr As String, branchName As String, parentDemandAS400LocationDistributionID As Integer)
      Me.DemandAS400LocationDistributionID = demandAS400LocationDistributionID
      Me.BranchId = branchId
      Me.CompanyNbr = companyNbr
      Me.CompanyName = companyName
      Me.DivisionNbr = divisionNbr
      Me.DivisionName = divisionName
      Me.BranchNbr = branchNbr
      Me.BranchName = branchName
      Me.ParentDemandAS400LocationDistributionID = parentDemandAS400LocationDistributionID
    End Sub

    Public Overrides Function ToString() As String
      Return $"{CompanyNbr}-{DivisionNbr}-{BranchNbr} {BranchName}"
    End Function

  End Class


End Module
