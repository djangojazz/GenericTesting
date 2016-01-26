

Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _stuff As ObservableCollection(Of Stuff)

  Enum ShipTyper
    Owned = 1
    Contractor = 2
    Other = 3
  End Enum

  'Public ReadOnly Property MyEnums As IEnumerable(Of Enums.ShipType)
  '  Get
  '    Return GetEnums()
  '  End Get
  'End Property

  'Private Shared Function GetEnums() As IEnumerable(Of Enums.ShipType)
  '  Dim things = [Enum].GetValues(GetType(Enums.ShipType)).Cast(Of Enums.ShipType)
  '  Return things
  'End Function

  'Private _enums As Enums.ShipType
  'Public Property Enums As Enums.ShipType
  '  Get
  '    Return _enums
  '  End Get
  '  Set(ByVal value As Enums.ShipType)
  '    _enums = value
  '    OnPropertyChanged(NameOf(Enums))
  '  End Set
  'End Property

  Public Property LocationAddress() As String
    Get
      Return _locationAddress
    End Get
    Set
      _locationAddress = Value
      OnPropertyChanged("LocationAddress")
    End Set
  End Property

  Public Property Address() As String
    Get
      Return _address
    End Get
    Set
      _address = Value
      OnPropertyChanged("Address")
    End Set
  End Property

  Public Property Stuff() As ObservableCollection(Of Stuff)
    Get
      Return _stuff
    End Get
    Set(ByVal value As ObservableCollection(Of Stuff))
      _stuff = value
      OnPropertyChanged(NameOf(Stuff))
    End Set
  End Property

  Public Property GeocodeAddressCommand() As ICommand
    Get
      Return m_GeocodeAddressCommand
    End Get
    Private Set
      m_GeocodeAddressCommand = Value
    End Set
  End Property
  Private m_GeocodeAddressCommand As ICommand

  Sub New()
    Stuff = New ObservableCollection(Of Stuff)(New List(Of Stuff)({New Stuff With {.Id = 1, .Value = "Stuff"}, New Stuff With {.Id = 2, .Value = "More Stuff"}}))
    GeocodeAddressCommand = New DelegateCommand(Of String)(AddressOf DoIt)
  End Sub

  Private Sub DoIt(input As String)
    LocationAddress = "Done"
    Address = "Done"
  End Sub
End Class
