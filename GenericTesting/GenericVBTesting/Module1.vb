Module Module1

  Class Ship
    Public Property ShipId() As Integer
    Public Property MMSI() As Integer
    Public Property ShipName() As String
    Public Property Location() As String
    Public Property Latitude() As Double
    Public Property Longitude() As Double
  End Class

  Sub Main()
    Dim ships = New List(Of Ship)() From
    {
      New Ship() With {.MMSI = 1, .ShipName = "Alpha"},
      New Ship() With {.MMSI = 2, .ShipName = "Beta"},
      New Ship() With {.MMSI = 3, .ShipName = "Zeta"},
      New Ship() With {.MMSI = 4, .ShipName = "Theta"}
    }

    ships.OrderByDescending(Function(x) x.MMSI).Take(2).ToList().ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))

    'Dim data = DataConverter.ConvertTo(Of Ship)(New SQLTalker().GetData("EXEC dbo.pGetAllShips")).ToList()
    'data.ForEach(Sub(x) Console.WriteLine($"{x.MMSI} {x.ShipName}"))

    Console.ReadLine()
  End Sub

End Module
