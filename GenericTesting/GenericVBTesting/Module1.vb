Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Net

Module Module1

  Dim _ships As List(Of ShipModel) = New List(Of ShipModel)

  Enum Tester
    Hello = 1
    There = 2
    Buddy = 3
  End Enum

  Enum FleetMonAPICall
    base = 1
    myfleet = 2
  End Enum

  Enum FleetMonAPIReturnType
    xml = 1
    json = 2
  End Enum


  Private Sub UpdateShipsInformation()
    Dim bt = New BoatTesting(2)
    _ships = bt.TestLoadShipLocations().ToList()

    'Dim shipGroupingModels = New List(Of ShipGroupingModel)
    'Dim maxGroupFromShips As Func(Of Integer) = Function() _ships.ToList().Select(Function(X) X.Group).ToList().OrderByDescending(Function(x) x).FirstOrDefault()
    'Dim shipGroupAlreadyExists As Func(Of ShipModel, Boolean) = Function(x) shipGroupingModels.Select(Function(y) y.Ships).ToList().Exists(Function(x) x.)
    Dim ReturnPriorityBoat As Func(Of ShipModel, ShipModel, ShipModel) = Function(x, y) If(x.ShipType <= y.ShipType, x, y)

    'Dim ship = ReturnPriorityBoat(_ships(0), _ships(1))

    Dim groupings = New List(Of ShipGroupingModel)

    Dim CollectionToEmpty = _ships.ToList()
    Do While CollectionToEmpty.Count > 0
      Dim currentShip = CollectionToEmpty(0)
      Dim currentGroup As New ShipGroupingModel With {.Location = currentShip.Location, .ShipType = currentShip.ShipType, .Ships = New List(Of ShipModel)({currentShip})}
      'currentGroup.Ships.Add(currentShip)
      CollectionToEmpty.RemoveAt(0)

      For i As Integer = CollectionToEmpty.Count - 1 To 0 Step -1
        Dim shipToCompare = CollectionToEmpty(i)
        If bt.DetectCollision(currentShip.Location, shipToCompare.Location) Then
          If (currentGroup.ShipType > shipToCompare.ShipType) Then
            Dim priorityShip = ReturnPriorityBoat(currentShip, shipToCompare)
            currentGroup.Location = priorityShip.Location
            currentGroup.ShipType = priorityShip.ShipType
          End If

          currentGroup.Ships.Add(shipToCompare)
          CollectionToEmpty.RemoveAt(i)
        End If
      Next

      groupings.Add(currentGroup)
    Loop

    Dim modelGroup = groupings

  End Sub

  Public Class VesselModel
    Public Property name As Double
    Public Property mmsinumber As Integer
    Public Property latitude As Double
    Public Property longitude As Double
  End Class

  Public Class FleetMonCall
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

          Dim rootResponse = xdoc.Element("response")
          Dim vessels = rootResponse.Element("objects").Elements("object").Elements("vessel")

          Return vessels.ToList().Select(Function(x) New ShipDb With
                                               {
                                                .MMSI = x.Element(NameOf(VesselModel.mmsinumber)).Value,
                                                .ShipName = x.Element(NameOf(VesselModel.name)).Value,
                                                .Latitude = x.Element(NameOf(VesselModel.latitude)).Value,
                                                .Longitude = x.Element(NameOf(VesselModel.longitude)).Value
                                                }).ToList()
        End Using
      Catch ex As Exception
        Throw ex
      End Try
    End Function

  End Class

  Sub Main()

    Dim ships = New FleetMonCall().ReturnMyFleetShipsFromFleetmon(FleetMonAPICall.MyFleet, FleetMonAPIReturnType.Xml)

    'Dim xmlBlob = "<?xml version='1.0' encoding='utf-8'?><response><meta type=""hash""><limit type=""integer"">10000</limit><next type=""null""/><offset type=""integer"">0</offset><previous type=""null""/><total_count type=""integer"">18</total_count></meta><objects type=""list""><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign>CZ2591</callsign><course type=""integer"">155</course><destination>UCLUELET</destination><draught>4.0</draught><etatime>None</etatime><flag>CA|Canada</flag><heading>180.0</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Port Alberni (CA)</event><eventtime>2016-02-13T01:29:22+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-13 01:31:44+00:00</arrival><departure>2016-02-13 01:45:02+00:00</departure><locode>CAPAB</locode><name>Port Alberni</name></lastport><latitude type=""float"">49.236225</latitude><location>Port Alberni, CA</location><longitude type=""float"">-124.81581</longitude><mmsinumber type=""integer"">316003514</mmsinumber><name>OCEAN KING</name><navigationstatus>under way using engine</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-13 01:45:02+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/ocean-king_0_56290/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WDE7178</callsign><course type=""integer"">356</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>128.0</heading><imonumber type=""integer"">8807296</imonumber><lastevent type=""hash""><event>Entered port area, Westhaven Cove (US)</event><eventtime>2016-02-15T10:20:10+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-28 19:45:02+00:00</arrival><departure>2016-02-15 10:59:51+00:00</departure><locode type=""null""/><name>Westhaven Cove</name></lastport><latitude type=""float"">46.906378</latitude><location>Westhaven Cove, US</location><longitude type=""float"">-124.107008</longitude><mmsinumber type=""integer"">366425240</mmsinumber><name>JAMIE MARIE</name><navigationstatus>not available</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/jamie-marie_8807296_1083123.220x146.jpg|//img4.fleetmon.com/thumbnails/jamie-marie_8807296_1083123.570x1140.jpg</photos><positionreceived>2016-02-15 10:59:51+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/jamie-marie_8807296_2410078/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WDC5819</callsign><course type=""null""/><destination type=""null""/><draught>5.0</draught><etatime>2016-01-01 00:00:00+00:00</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""integer"">7948316</imonumber><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2016-02-11T23:08:17+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-11 21:12:32+00:00</arrival><departure>2016-02-15 15:00:57+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.167733</latitude><location>Warrenton, US</location><longitude type=""float"">-123.914427</longitude><mmsinumber type=""integer"">367046890</mmsinumber><name>PACIFIC FUTURE</name><navigationstatus>engaged in fishing</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/pacific-future_7948316_1164911.220x146.jpg|//img4.fleetmon.com/thumbnails/pacific-future_7948316_1164911.570x1140.jpg</photos><positionreceived>2016-02-15 15:36:36+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/pacific-future_7948316_2551795/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDC4154</callsign><course type=""integer"">0</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2016-02-14T19:52:44+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-14 19:52:44+00:00</arrival><departure>2016-02-14 19:55:45+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.167213</latitude><location>Warrenton, US</location><longitude type=""float"">-123.91598</longitude><mmsinumber type=""integer"">367019950</mmsinumber><name>MARIE KATHLEEN</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-14 19:55:45+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/marie-kathleen_0_2601808/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign>WYD3070</callsign><course type=""integer"">190</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>190.6</heading><imonumber type=""integer"">7932185</imonumber><lastevent type=""hash""><event>Entered port area, Ilwaco (US)</event><eventtime>2016-02-14T22:24:47+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2015-11-20 17:58:12+00:00</arrival><departure>2016-02-14 20:53:23+00:00</departure><locode>USAST</locode><name>Astoria</name></lastport><latitude type=""float"">46.45423</latitude><location>North Pacific Ocean, US</location><longitude type=""float"">-124.646417</longitude><mmsinumber type=""integer"">367187080</mmsinumber><name>OCEAN BEAUT</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/ocean-beaut_7932185_1098855.220x146.jpg|//img4.fleetmon.com/thumbnails/ocean-beaut_7932185_1098855.570x1140.jpg</photos><positionreceived>2016-02-15 15:36:22+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/ocean-beaut_7932185_3070288/</publicurl><speed>6.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign type=""null""/><course type=""integer"">4</course><destination type=""null""/><draught>4.0</draught><etatime>2015-11-30 00:00:00+00:00</etatime><flag>CA|Canada</flag><heading>4.9</heading><imonumber type=""null""/><lastevent type=""hash""><event>Left port area, Ucluelet (CA)</event><eventtime>2016-02-15T01:32:00+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-11 21:06:36+00:00</arrival><departure>2016-02-15 00:31:53+00:00</departure><locode type=""null""/><name>Ucluelet</name></lastport><latitude type=""float"">49.47734</latitude><location>North Pacific Ocean, CA</location><longitude type=""float"">-127.142535</longitude><mmsinumber type=""integer"">316003448</mmsinumber><name>ARTIC OCEAN</name><navigationstatus>moored</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:16:15+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/artic-ocean_0_3464941/</publicurl><speed>2.5</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDE2605</callsign><course type=""integer"">0</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2015-12-31T00:02:16+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2015-10-28 20:19:53+00:00</arrival><departure>2016-02-15 15:00:46+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.168545</latitude><location>Warrenton, US</location><longitude type=""float"">-123.914</longitude><mmsinumber type=""integer"">367327250</mmsinumber><name>ENDEAVOR</name><navigationstatus>not available</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:36:46+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/endeavor_0_8129020/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WDC7970</callsign><course type=""integer"">0</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Bay City (OR) (US)</event><eventtime>2016-02-10T20:06:51+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-10 20:06:51+00:00</arrival><departure>2016-02-13 21:37:24+00:00</departure><locode>USYIY</locode><name>Bay City (OR)</name></lastport><latitude type=""float"">45.555172</latitude><location>Oregon, Washington, Vancouver Coast and Shelf</location><longitude type=""float"">-123.912567</longitude><mmsinumber type=""integer"">367079690</mmsinumber><name>SWELL RIDER</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-13 21:37:24+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/swell-rider_0_8147245/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WDD8281</callsign><course type=""integer"">75</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Ilwaco (US)</event><eventtime>2016-02-13T22:35:19+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-13 22:35:19+00:00</arrival><departure>2016-02-15 14:59:14+00:00</departure><locode type=""null""/><name>Ilwaco</name></lastport><latitude type=""float"">46.303065</latitude><location>Ilwaco, US</location><longitude type=""float"">-124.04132</longitude><mmsinumber type=""integer"">367197230</mmsinumber><name>BUCK ANN</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/buck-ann_0_1150795.220x146.jpg|//img4.fleetmon.com/thumbnails/buck-ann_0_1150795.570x1140.jpg</photos><positionreceived>2016-02-15 15:35:14+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/buck-ann_0_8523691/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDD5675</callsign><course type=""integer"">136</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2016-02-15T08:18:20+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-03 05:25:35+00:00</arrival><departure>2016-02-15 14:59:33+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.16726</latitude><location>Warrenton, US</location><longitude type=""float"">-123.91624</longitude><mmsinumber type=""integer"">367161930</mmsinumber><name>PACIFIC CONQUEST</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:34:29+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/pacific-conquest_0_8630338/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDD4581</callsign><course type=""integer"">287</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Tongue Point (US)</event><eventtime>2016-02-13T06:09:00+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-13 06:09:00+00:00</arrival><departure>2016-02-15 14:57:13+00:00</departure><locode type=""null""/><name>Tongue Point</name></lastport><latitude type=""float"">46.190575</latitude><location>Tongue Point, US</location><longitude type=""float"">-123.746737</longitude><mmsinumber type=""integer"">367146590</mmsinumber><name>FORERUNNER CLATSOP</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/forerunner-clatsop_0_1221843.220x146.jpg|//img4.fleetmon.com/thumbnails/forerunner-clatsop_0_1221843.570x1140.jpg</photos><positionreceived>2016-02-15 15:36:12+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/forerunner-clatsop_0_8994064/</publicurl><speed>0.0</speed><type>Special Purpose</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDD2215</callsign><course type=""null""/><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Seattle (US)</event><eventtime>2015-11-17T19:12:51+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2015-11-17 19:12:51+00:00</arrival><departure>2016-02-15 14:58:38+00:00</departure><locode>USSEA</locode><name>Seattle</name></lastport><latitude type=""float"">47.656748</latitude><location>Seattle, US</location><longitude type=""float"">-122.379698</longitude><mmsinumber type=""integer"">367112420</mmsinumber><name>ADIR0NDACK</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:34:36+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/adir0ndack_0_9301724/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WSA9839</callsign><course type=""integer"">164</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2016-01-06T19:46:00+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-06 19:49:00+00:00</arrival><departure>2016-02-15 14:58:02+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.144228</latitude><location>Warrenton, US</location><longitude type=""float"">-123.862543</longitude><mmsinumber type=""integer"">368652000</mmsinumber><name>NICOLE MARIE</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:22:02+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/nicole-marie_0_9596268/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign>WDD7138</callsign><course type=""null""/><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Warrenton (US)</event><eventtime>2016-02-12T22:18:14+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-10 17:40:12+00:00</arrival><departure>2016-02-15 14:58:10+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.168965</latitude><location>Warrenton, US</location><longitude type=""float"">-123.913822</longitude><mmsinumber type=""integer"">367182380</mmsinumber><name>SEA VALLEY II</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:34:12+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/sea-valley-ii_0_9677244/</publicurl><speed>0.0</speed><type>Motor boat</type></vessel></object><object><note></note><tags type=""list""><value>PacificSeafood</value></tags><vessel><callsign>WDH8856</callsign><course type=""integer"">323</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>323.7</heading><imonumber type=""integer"">8012293</imonumber><lastevent type=""hash""><event>Entered port area, Ilwaco (US)</event><eventtime>2016-02-14T21:23:11+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-12 22:28:46+00:00</arrival><departure>2016-02-14 19:51:14+00:00</departure><locode>USAST</locode><name>Astoria</name></lastport><latitude type=""float"">46.540718</latitude><location>North Pacific Ocean, US</location><longitude type=""float"">-124.604543</longitude><mmsinumber type=""integer"">367662190</mmsinumber><name>CASSANDRA ANN</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos>//img4.fleetmon.com/thumbnails/cassandra-ann_8012293_1231059.220x146.jpg|//img4.fleetmon.com/thumbnails/cassandra-ann_8012293_1231059.570x1140.jpg</photos><positionreceived>2016-02-15 01:57:28+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/cassandra-ann_8012293_9707584/</publicurl><speed>7.2</speed><type>Trawler</type></vessel></object><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign>WDE9033</callsign><course type=""integer"">168</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>US|United States</flag><heading>168.8</heading><imonumber type=""null""/><lastevent type=""hash""><event>Entered port area, Westport (US)</event><eventtime>2016-02-15T15:00:52+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-28 00:06:30+00:00</arrival><departure>2016-02-15 07:44:25+00:00</departure><locode>USAST</locode><name>Astoria</name></lastport><latitude type=""float"">45.7123</latitude><location>North Pacific Ocean, US</location><longitude type=""float"">-123.998378</longitude><mmsinumber type=""integer"">367412590</mmsinumber><name>PEARL J</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:36:25+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/pearl-j_0_9884188/</publicurl><speed>4.9</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Other</value></tags><vessel><callsign>WDD2539</callsign><course type=""integer"">335</course><destination type=""null""/><draught type=""null""/><etatime>None</etatime><flag>AA|Alaska (US)</flag><heading>None</heading><imonumber type=""null""/><lastevent type=""hash""><event>Entered port area, Warrenton (US)</event><eventtime>2016-01-06T19:17:54+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-06 19:17:54+00:00</arrival><departure>2016-02-15 14:58:59+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">46.168248</latitude><location>Warrenton, US</location><longitude type=""float"">-123.91414</longitude><mmsinumber type=""integer"">303679000</mmsinumber><name>DEFIANT</name><navigationstatus>None</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:34:59+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/defiant_0_10066036/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object><object><note></note><tags type=""list""><value>Contractor</value></tags><vessel><callsign>WDI4590</callsign><course type=""integer"">23</course><destination type=""null""/><draught>3.0</draught><etatime>None</etatime><flag>US|United States</flag><heading>10.0</heading><imonumber type=""null""/><lastevent type=""hash""><event>Left port area, Ilwaco (US)</event><eventtime>2016-02-12T21:50:58+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-01-29 20:33:48+00:00</arrival><departure>2016-02-12 19:50:08+00:00</departure><locode type=""null""/><name>Warrenton</name></lastport><latitude type=""float"">47.330688</latitude><location>North Pacific Ocean, US</location><longitude type=""float"">-124.950252</longitude><mmsinumber type=""integer"">367700050</mmsinumber><name>OCEAN INVICTUS</name><navigationstatus>not available</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-15 15:28:18+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/ocean-invictus_0_10393128/</publicurl><speed>4.1</speed><type>Fishing vessel</type></vessel></object></objects></response>"
    'Dim testXmlBlob = "<response><meta type=""hash""><limit type=""integer"">10000</limit><next type=""null""/><offset type=""integer"">0</offset><previous type=""null""/><total_count type=""integer"">18</total_count></meta><objects type=""list""><object><note/><tags type=""list""><value>Other</value></tags><vessel><callsign>CZ2591</callsign><course type=""integer"">155</course><destination>UCLUELET</destination><draught>4.0</draught><etatime>None</etatime><flag>CA|Canada</flag><heading>180.0</heading><imonumber type=""null""/><lastevent type=""hash""><event>Moored, Port Alberni (CA)</event><eventtime>2016-02-13T01:29:22+00:00</eventtime></lastevent><lastport type=""hash""><arrival>2016-02-13 01:31:44+00:00</arrival><departure>2016-02-13 01:45:02+00:00</departure><locode>CAPAB</locode><name>Port Alberni</name></lastport><latitude type=""float"">49.236225</latitude><location>Port Alberni, CA</location><longitude type=""float"">-124.81581</longitude><mmsinumber type=""integer"">316003514</mmsinumber><name>OCEAN KING</name><navigationstatus>under way using engine</navigationstatus><nextport type=""null""/><photos type=""null""/><positionreceived>2016-02-13 01:45:02+00:00</positionreceived><publicurl>//www.fleetmon.com/vessels/ocean-king_0_56290/</publicurl><speed>0.0</speed><type>Fishing vessel</type></vessel></object></objects></response>"

    'client.DownloadString("https://www.fleetmon.com/api/p/personal-v1/myfleet/?username=djangojazz&api_key=1cde332d14eb456826e0e87978fb7fc3679e788e&format=xml")

    'Try the XDocument.Load with the rest URI directly and see if that works directly.


    ships.ToList().ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))


    Console.ReadLine()
  End Sub

  Private Sub FunWithGrouping()
    Dim dBships = New List(Of ShipDb)({
                                       New ShipDb With {.ShipId = 1, .MMSI = 1, .ShipName = "Test", .Latitude = 57.639259, .Longitude = -118.535018, .ShipVolumeId = 1, .BoatHale = 3500, .ExpectedVolume = 4000, .CatchTypeID = 5},
                                       New ShipDb With {.ShipId = 1, .MMSI = 1, .ShipName = "Test", .Latitude = 57.639259, .Longitude = -118.535018, .ShipVolumeId = 2, .BoatHale = 8000, .ExpectedVolume = 20000, .CatchTypeID = 3}
                                       }).ToList()

    'Dim shipsG = dBships.GroupBy(Function(x) New With {Key x.ShipId, Key x.MMSI})

    'Dim dBships = DataConverter.ConvertTo(Of ShipDb)(New SQLTalker().GetData("EXEC Ships.pShipsMockService 's', 100000"))
      Dim ships = dBships.GroupBy(Function(x) New With {Key x.ShipId, Key x.MMSI, Key x.ShipName, Key x.ShipTypeId, Key x.Latitude, Key x.Longitude}).Select(Function(x) New ShipModel With
                          {
                          .MMSI = x.Key.MMSI,
                          .ShipName = x.Key.ShipName,
                          .ShipType = DirectCast(x.Key.ShipTypeId, ShipType),
                          .Location = New Location() With {.Latitude = x.Key.Latitude, .Longitude = x.Key.Longitude},
                          .BoatHale = x.Select(Function(y) New BoatHale With {.BoatHale = y.BoatHale, .ExpectedVolume = y.ExpectedVolume, .CatchTypeID = DirectCast(y.CatchTypeID, CatchType)}).ToList()
                          }).ToList()
  End Sub

  Private Sub WriteOutRandomizer()
    Dim rand As New Random()
    Dim memNum As New HashSet(Of ShipModel)
    Dim memName As New HashSet(Of String)
    Dim randomNum As Integer
    Dim randomName As String
    Dim randomLat As Double
    Dim randomLong As Double
    Dim randomExt As Double

    While memNum.Count < 100
      randomNum = rand.Next(102452151, 999452151)
      randomExt = rand.Next(1, 900000) / 1000000
      randomName = rand.Next()
      randomLat = rand.Next(30.000001, 55.000001)
      randomLong = rand.Next(-142.000001, -115.000001)
      randomLat += randomExt
      randomLong += randomExt

      memNum.Add(New ShipModel With {.MMSI = randomNum, .ShipName = New RandomHelper().ReturnRandomName(rand, 6), .Location = New Location With {.Latitude = randomLat, .Longitude = randomLong}})
    End While


    'TODO write to disk

    'Dim data = DataConverter.ConvertTo(Of Ship)(New SQLTalker().GetData("EXEC dbo.pGetAllShips")).ToList()
    'data.ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))

    Using sw As IO.StreamWriter = New IO.StreamWriter("Inserts.txt")
      memNum.ToList().ForEach(Sub(x) sw.WriteLine($"({x.MMSI}, '{x.ShipName}', {x.Location.Latitude}, { x.Location.Longitude}),"))
    End Using
  End Sub

  Private Sub ReturnRandomName(rand As Random, alphas As String, sb As StringBuilder)
    For i As Integer = 1 To 6
      Dim idx As Integer = rand.Next(0, 25)
      sb.Append(alphas.Substring(idx, 1))
    Next

    sb.Append(" ")

    For i As Integer = 1 To 6
      Dim idx As Integer = rand.Next(0, 25)
      sb.Append(alphas.Substring(idx, 1))
    Next
  End Sub
End Module
