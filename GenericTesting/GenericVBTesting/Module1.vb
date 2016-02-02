Imports System.Collections.ObjectModel
Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF

Module Module1

  Dim _ships = New List(Of ShipModel)

  Enum Tester
    Hello = 1
    There = 2
    Buddy = 3
  End Enum

  Private Sub UpdateShipsInformation()
    Dim bt = New BoatTesting(2)
    _ships = bt.TestLoadShipLocations()

    'Dim shipGroupingModels = New List(Of ShipGroupingModel)
    'Dim maxGroupFromShips As Func(Of Integer) = Function() _ships.ToList().Select(Function(X) X.Group).ToList().OrderByDescending(Function(x) x).FirstOrDefault()
    'Dim shipGroupAlreadyExists As Func(Of ShipModel, Boolean) = Function(x) shipGroupingModels.Select(Function(y) y.Ships).ToList().Exists(Function(x) x.)

    Dim groupings = New List(Of ShipGroupingModel)

    Dim CollectionToEmpty As New Collection(Of ShipModel)(_ships)
    'Dim iCurrentIteration As Integer = 1
    Do While CollectionToEmpty.Count > 0
      Dim currentGroup As New ShipGroupingModel With {.Ships = New List(Of ShipModel)} 'Just do the first Lat Long instead of a Key
      'With { .Group = iCurrentIteration}
      currentGroup.Ships.Add(CollectionToEmpty(0))
      CollectionToEmpty.RemoveAt(0)

      For i As Integer = CollectionToEmpty.Count - 1 To 0 Step -1
        If bt.DetectCollision(CollectionToEmpty(0).Location, CollectionToEmpty(i).Location) Then
          currentGroup.Ships.Add(CollectionToEmpty(i))
          CollectionToEmpty.RemoveAt(i)
        End If
      Next

      groupings.Add(currentGroup)
    Loop

    Dim modelGroup = groupings

  End Sub


  Sub Main()


    Console.ReadLine()
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
