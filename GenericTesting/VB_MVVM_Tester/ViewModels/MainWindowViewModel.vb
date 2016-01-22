

Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _stuff As ObservableCollection(Of Stuff)

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
