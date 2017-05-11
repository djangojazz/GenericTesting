Imports System.Xml.Serialization
Imports Microsoft.Maps.MapControl.WPF

Public Class BoatTesting
  Public Property DistanceThreshold As Double

  Sub New(distanceThresholdInput As Double)
    DistanceThreshold = distanceThresholdInput
  End Sub

  Public Enum ShipType
    Owned = 1
    Contractor = 2
    Other = 3
  End Enum

  Public Enum CatchType
    Rockfish = 1
    Shrimp = 2
    Salmon = 3
    Crab = 4
    DoverSole = 5
  End Enum

  Public Class ShipGroupingModel
    Public Property Location As Location
    Public Property ShipType As ShipType
    Public Property Ships As IList(Of ShipModel)
  End Class

  Public Class ShipModel
    Public Property MMSI As Integer
    Public Property ShipName As String
    Public Property ShipType As ShipType
    Public Property Location As Location
    Public Property BoatHale As IList(Of BoatHale)
  End Class


  <Serializable>
  Public Class ShipDb
    <XmlAttribute>
    Public Property ShipId As Integer
    <XmlAttribute>
    Public Property MMSI As Integer
    <XmlAttribute>
    Public Property ShipName As String
    <XmlAttribute>
    Public Property Latitude As Double
    <XmlAttribute>
    Public Property Longitude As Double
    <XmlAttribute>
    Public Property ShipTypeId As Integer
    Public Property LastUpdated As DateTime
    Public Property ShipVolumeId As Integer
    Public Property BoatHale As Double
    Public Property ExpectedVolume As Double
    Public Property CatchTypeID As Integer
  End Class


  Public Class BoatHale
    Public Property BoatHale As Double
    Public Property ExpectedVolume As Double
    Public Property CatchTypeID As CatchType
  End Class

  <Serializable>
  Public Class Chart
    <XmlAttribute>
    Public Property ChartName As String
    <XmlAttribute>
    Public Property MapRefreshInMinutes As Integer
    <XmlAttribute>
    Public Property ShipDetailsRefreshInSeconds As Integer
    <XmlElement>
    Public Property LocationGrid As LocationRect

    Public Overrides Function Equals(obj As Object) As Boolean
      Return TypeOf obj Is Chart AndAlso DirectCast(obj, Chart).ChartName = Me.ChartName
    End Function

  End Class

  Public Function TestLoadShipLocations() As IList(Of ShipModel)
    Return {
      MakeABoat(1, "Brett Home", ShipType.Contractor, 45.457302, -122.754326),
      MakeABoat(2, "Thai Roses", ShipType.Other, 45.486155, -122.747739)
    }

    'MakeABoat(3, "Brett Neighbor", ShipType.Owned, 45.4573, -122.75432),
    '  MakeABoat(4, "Another Neighbor", ShipType.Owned, 45.45725, -122.75431),
    '  MakeABoat(5, "Seattle", ShipType.Contractor, 47.6149942, -122.4759882),
    '  MakeABoat(6, "Seattle Neighbor", ShipType.Owned, 47.6149932, -122.4759882)
  End Function

  Private Function MakeABoat(mmsi As Integer, shipName As String, shipType As ShipType, latitude As Double, longitude As Double) As ShipModel
    Return New ShipModel With {
                              .MMSI = mmsi,
                              .ShipName = shipName,
                              .ShipType = shipType,
                              .Location = New Location() With {.Latitude = latitude, .Longitude = longitude}
                              }
  End Function

  Public Function DetectCollision(loc1 As Location, loc2 As Location) As Boolean
    Dim milesDistanceBetweenPoints = loc1.DistanceTo(loc2, DistanceUnit.Miles)

    Return ((DistanceThreshold * 2) > milesDistanceBetweenPoints)
  End Function

  Public Sub WriteOutRandomizer(count As Integer)
    Dim rand As New Random()
    Dim memNum As New HashSet(Of ShipModel)
    Dim memName As New HashSet(Of String)
    Dim randomNum As Integer
    Dim randomName As String
    Dim randomLat As Double
    Dim randomLong As Double
    Dim randomExt As Double

    While memNum.Count < count
      randomNum = rand.Next(102452151, 999452151)
      randomExt = rand.Next(1, 900000) / 1000000
      randomName = CType(rand.Next(), String)
      randomLat = rand.Next(CInt(30.000001), CInt(55.000001))
      randomLong = rand.Next(CInt(-142.000001), CInt(-115.000001))
      randomLat += randomExt
      randomLong += randomExt

      memNum.Add(New ShipModel With {.MMSI = randomNum, .ShipName = New RandomHelper().ReturnRandomName(rand, 6), .Location = New Location With {.Latitude = randomLat, .Longitude = randomLong}})
    End While


    Using sw As IO.StreamWriter = New IO.StreamWriter("Inserts.txt")
      memNum.ToList().ForEach(Sub(x) sw.WriteLine($"({x.MMSI}, '{x.ShipName}', {x.Location.Latitude}, { x.Location.Longitude}),"))
    End Using
  End Sub

  Dim _ships As List(Of ShipModel) = New List(Of ShipModel)

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
End Class
