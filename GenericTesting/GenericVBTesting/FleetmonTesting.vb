
Imports System.Net
Imports GenericVBTesting.BoatTesting

Public Class FleetmonTesting
  Private _apiBaseCallAddress As String

  Public Sub New()
    _apiBaseCallAddress = System.Configuration.ConfigurationManager.AppSettings("FleetMonAPIBaseAddress") + "/{0}/?username=" + System.Configuration.ConfigurationManager.AppSettings("FleetMonAPIUser") _
    + "&api_key=" + System.Configuration.ConfigurationManager.AppSettings("FleetMonAPIKey") + "&format={1}"
  End Sub

  Public Function ReturnMyFleetShipsFromFleetmon(fleetMonAPICalltoMake As FleetMonAPICall, fleetMonAPIformatToReturn As FleetMonAPIReturnType) As IList(Of ShipDb)
    Try
      Dim specificAPICall = String.Format(_apiBaseCallAddress, fleetMonAPICalltoMake.ToString(), fleetMonAPIformatToReturn.ToString())
      'Dim staticAddress = "https://www.fleetmon.com/api/p/personal-v1/myfleet/?username=djangojazz&api_key=1cde332d14eb456826e0e87978fb7fc3679e788e&format=xml"

      Using client = New WebClient()
        Dim xdoc As XDocument = XDocument.Load(specificAPICall)
        Dim vessels = xdoc.Descendants("vessel")

        Return vessels.ToList().Select(Function(x) New ShipDb With
                                             {
                                              .MMSI = x.Element(NameOf(VesselModel.mmsinumber)).Value,
                                              .ShipName = x.Element(NameOf(VesselModel.name)).Value,
                                              .Latitude = x.Element(NameOf(VesselModel.latitude)).Value,
                                              .Longitude = x.Element(NameOf(VesselModel.longitude)).Value,
                                              .ShipTypeId = [Enum].Parse(GetType(ShipType), x.Parent.Element("tags").Value)
                                              }).ToList()
      End Using
    Catch ex As Exception
      Throw ex
    End Try
  End Function

End Class

Public Enum FleetMonAPICall
  base = 1
  myfleet = 2
End Enum

Public Enum FleetMonAPIReturnType
  xml = 1
  json = 2
End Enum