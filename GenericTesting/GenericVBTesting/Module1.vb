﻿Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Threading
Imports System.Collections.ObjectModel

Module Module1

  Private MyConnection As SqlClient.SqlConnection
  Private MyReader As SqlClient.SqlDataReader

  Public Class POCO
    Public Property ID As Integer
    Public Property Value As String
  End Class

  Private listings As New Dictionary(Of String, String)
  Private chartSettingsFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\OpenEnterprise\ChartSettings.xml"
  Dim _ships As List(Of ShipModel) = New List(Of ShipModel)
  Private _dispatcher As Dispatcher

  Enum Tester
    Hello = 1
    There = 2
    Buddy = 3
  End Enum

  Public Enum ShipType
    PacificSeafood = 1
    Contractor = 2
    Other = 3
  End Enum

  Public Property ShipLocations As ObservableCollection(Of ShipGroupingModel)

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

  Private Function GiveAnonymous() As Object
    Return New With {Key .a = "a", .b = "b"}
  End Function

  Sub Main()
    Dim text = "123.1212"


    Console.WriteLine(text.Split("."c).GetUpperBound(0))

    Console.ReadLine()
  End Sub

  Private Sub sqlTesting()
    Dim sqlTalker = New SQLTalker(GetMyConnectionString)

    Dim dt = sqlTalker.TestSelectProductionHeaderPlanning(Now.Date.AddDays(-1), Now.Date, -10)

    For Each row In dt.Rows
      Console.WriteLine(row(0))
    Next
  End Sub

  Public Function GetMyConnectionString() As String
    Return "data source=APC-DEV\TEST;initial catalog=APC_Local;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;"
  End Function

  Private Sub TestGetNull(ByVal IP As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ProductionState As Integer?)
    MyConnection = New SqlClient.SqlConnection(GetMyConnectionString())
    MyConnection.Open()
    Dim oCmd As New SqlClient.SqlCommand("APC_SP_SELECT_ProductionHeadersProductionPlan", MyConnection)
    oCmd.CommandType = CommandType.StoredProcedure
    oCmd.CommandTimeout = 60
    oCmd.Parameters.AddWithValue("@StartDate", StartDate.ToString("MM/dd/yyyy 00:00"))
    oCmd.Parameters.AddWithValue("@EndDate", EndDate.ToString("MM/dd/yyyy 23:59"))
    oCmd.Parameters.AddWithValue("@ProductionState", If(ProductionState, DirectCast(DBNull.Value, Object)))
    MyReader = oCmd.ExecuteReader
  End Sub

  Private Sub UpdateShipCollection(newShipCollection As IList(Of ShipGroupingModel))
    ShipLocations.ClearAndAddRange(newShipCollection)
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
