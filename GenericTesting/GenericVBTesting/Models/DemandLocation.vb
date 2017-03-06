Imports System.ComponentModel

Public NotInheritable Class DemandLocation
  Implements INotifyPropertyChanged

  'CONSTRUCTOR
  Public Sub New()
  End Sub
  Public Sub New(locationID As Integer, companyNbr As String, divisionNbr As String, branchNbr As String, branchName As String)
    Me.LocationID = locationID
    Me.CompanyNbr = companyNbr
    Me.DivisionNbr = divisionNbr
    Me.BranchNbr = branchNbr
    Me.BranchName = branchName
  End Sub


  'PROPERTIES
  Public Property LocationID As Integer

  Public Property CompanyNbr As String = String.Empty

  Public Property DivisionNbr As String = String.Empty

  Public Property BranchNbr As String = String.Empty

  Public Property BranchName As String = String.Empty

  Private _isUsed As Boolean

  Public Property IsUsed As Boolean
    Get
      Return _isUsed
    End Get
    Set(ByVal value As Boolean)
      _isUsed = value
      OnPropertyChanged(NameOf(IsUsed))
    End Set
  End Property

  'METHODS
  Public Overrides Function ToString() As String
    Return $"{CompanyNbr.Trim}-{DivisionNbr.Trim}-{BranchNbr.Trim} {BranchName.Trim}"
  End Function

  Public Overrides Function Equals(obj As Object) As Boolean
    Select Case True
      Case TypeOf obj Is Integer
        Return Nullable.Equals(Me.LocationID, CInt(obj))
      Case Else
        Dim othr As DemandLocation = TryCast(obj, DemandLocation)
        Return If(IsNothing(othr), False, Nullable.Equals(othr.LocationID, Me.LocationID))
    End Select
  End Function

  Public Overrides Function GetHashCode() As Integer
    Return LocationID.GetHashCode
  End Function

  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

  Public Sub OnPropertyChanged(ByVal info As String)
    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
  End Sub

End Class