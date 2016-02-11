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
  Public Class ShipsDb
    Public Property Ships As List(Of ShipDb)
  End Class

  <Serializable>
  Public Class ShipDb
    Public Property ShipId As Integer
    Public Property MMSI As Integer
    Public Property ShipName As String
    Public Property Latitude As Double
    Public Property Longitude As Double
    Public Property ShipTypeId As Integer
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
      randomName = rand.Next()
      randomLat = rand.Next(30.000001, 55.000001)
      randomLong = rand.Next(-142.000001, -115.000001)
      randomLat += randomExt
      randomLong += randomExt

      memNum.Add(New ShipModel With {.MMSI = randomNum, .ShipName = New RandomHelper().ReturnRandomName(rand, 6), .Location = New Location With {.Latitude = randomLat, .Longitude = randomLong}})
    End While


    Using sw As IO.StreamWriter = New IO.StreamWriter("Inserts.txt")
      memNum.ToList().ForEach(Sub(x) sw.WriteLine($"({x.MMSI}, '{x.ShipName}', {x.Location.Latitude}, { x.Location.Longitude}),"))
    End Using
  End Sub
End Class
