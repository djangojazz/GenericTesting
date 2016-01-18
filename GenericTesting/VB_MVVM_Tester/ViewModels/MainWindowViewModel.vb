

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String

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
    Address = "7560 SW Lara St., Portland OR"
    LocationAddress = "Not there yet"

    GeocodeAddressCommand = New DelegateCommand(Of String)(AddressOf GeocodeAddress)
  End Sub

  Private Sub GeocodeAddress(input As String)
    LocationAddress = "Done"
    Address = "Done"
    'Using client As New GeocodeService.GeocodeServiceClient("CustomBinding_IGeocodeService")
    '  Dim request As New GeocodeService.GeocodeRequest()
    '  request.Credentials = New Credentials() With {
    '      .ApplicationId = TryCast(Application.Current.Resources("BingCredentials"), ApplicationIdCredentialsProvider).ApplicationId
    '    }
    '  request.Query = Address
    '  GeocodeResult = client.Geocode(request).Results(0)

    '  LocationAddress = GeocodeResult.Address.FormattedAddress
    '  Latitude = GeocodeResult.Locations(0).Latitude
    '  Longitude = GeocodeResult.Locations(0).Longitude
    '  Location = New Location(Latitude, Longitude)
    '  PinVisible = Visibility.Visible
    'End Using
  End Sub
End Class
