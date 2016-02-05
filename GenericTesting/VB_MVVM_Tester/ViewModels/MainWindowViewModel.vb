
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

  Private _marqueeViewModel As MarqueeViewModel

  Public Property MarqueeViewModel() As MarqueeViewModel
    Get
      Return _marqueeViewModel
    End Get
    Set(ByVal value As MarqueeViewModel)
      _marqueeViewModel = value
      OnPropertyChanged(NameOf(MarqueeViewModel))
    End Set
  End Property

  Private _marqueeText As String

  Public Property MarqueeText As String
    Get
      Return _marqueeText
    End Get
    Set(ByVal value As String)
      _marqueeText = value
      MarqueeViewModel.MarqueeText = _marqueeText
      OnPropertyChanged(NameOf(MarqueeText))
    End Set
  End Property

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
    MarqueeViewModel = New MarqueeViewModel("made up", New Duration(New TimeSpan(0, 0, 5)))
    MarqueeText = "(MMSI 111111111) (ShipName Anne Sleuth) (ShipType Owned) (Location 47.356129,-128.818148,0) ; (MMSI 111112211) (ShipName Bon Voyage) (ShipType Contractor) (Location 48.376129,-129.818148,0) ; (MMSI 111111111) (ShipName Anne Sleuth) (ShipType Owned) (Location 47.356129,-128.818148,0) ; (MMSI 111112211) (ShipName Bon Voyage) (ShipType Contractor) (Location 48.376129,-129.818148,0) ; "
    Stuff = New ObservableCollection(Of Stuff)(New List(Of Stuff)({New Stuff With {.Id = 1, .Value = "Stuff"}, New Stuff With {.Id = 2, .Value = "More Stuff"}}))
    GeocodeAddressCommand = New DelegateCommand(Of String)(AddressOf DoIt)
  End Sub

  Private Sub DoIt(input As String)
    LocationAddress = "Done"
    Address = "Done"
  End Sub
End Class
