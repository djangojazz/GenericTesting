Imports System.Runtime.CompilerServices
Imports Microsoft.Maps.MapControl.WPF

Public Module MapHelpers
  <Extension>
  Public Function DistanceTo(pos1 As Location, pos2 As Location, unit As DistanceUnit) As Double
    Dim R As Double = If((unit = DistanceUnit.Miles), 3960, 6371)
    Dim lat = ToRadians(pos2.Latitude - pos1.Latitude)
    Dim lng = ToRadians(pos2.Longitude - pos1.Longitude)
    Dim h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Cos(ToRadians(pos1.Latitude)) * Math.Cos(ToRadians(pos2.Latitude)) * Math.Sin(lng / 2) * Math.Sin(lng / 2)
    Dim h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)))
    Return R * h2
  End Function

  Public Function ToRadians(val As Double) As Double
    Return (Math.PI / 180) * val
  End Function

  Public Enum DistanceUnit
    Miles
    Kilometers
  End Enum

End Module
