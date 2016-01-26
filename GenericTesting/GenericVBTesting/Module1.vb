Imports System.Text

Module Module1

  Class Ship
    'Public Property ShipId() As Integer
    Public Property MMSI() As Integer
    Public Property ShipName() As String
    'Public Property Location() As String
    Public Property Latitude() As Double
    Public Property Longitude() As Double
  End Class

  Enum Tester
    Hello = 1
    There = 2
    Buddy = 3
  End Enum

  Sub Main()

    Dim value As Integer = 3

    Dim e = DirectCast(value, Tester)

    Console.WriteLine($"{e}")
    Console.ReadLine()

    'Dim ships = New List(Of Ship)() From
    '{
    '  New Ship() With {.MMSI = 1, .ShipName = "Alpha"},
    '  New Ship() With {.MMSI = 2, .ShipName = "Beta"},
    '  New Ship() With {.MMSI = 3, .ShipName = "Zeta"},
    '  New Ship() With {.MMSI = 4, .ShipName = "Theta"}
    '}

    'ships.OrderByDescending(Function(x) x.MMSI).Take(2).ToList().ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))
  End Sub

  Private Sub WriteOutRandomizer()
    Dim rand As New Random()
    Dim memNum As New HashSet(Of Ship)
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

      memNum.Add(New Ship With {.MMSI = randomNum, .ShipName = New RandomHelper().ReturnRandomName(rand, 6), .Latitude = randomLat, .Longitude = randomLong})
    End While

    'TODO write to disk

    'Dim data = DataConverter.ConvertTo(Of Ship)(New SQLTalker().GetData("EXEC dbo.pGetAllShips")).ToList()
    'data.ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))

    Using sw As IO.StreamWriter = New IO.StreamWriter("Inserts.txt")
      memNum.ToList().ForEach(Sub(x) sw.WriteLine($"({x.MMSI}, '{x.ShipName}', {x.Latitude}, { x.Longitude}),"))
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
