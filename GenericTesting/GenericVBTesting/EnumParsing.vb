Module EnumParsing
  Enum Colors As Integer
    None = 0
    Red = 1
    Green = 2
    Blue = 4
  End Enum

  Public Sub EnumParsing()
    Dim colorStrings() As String = {"0", "2", "8", "blue", "Blue", "Yellow", "Red, Green"}
    For Each colorString As String In colorStrings
      Dim colorValue As Colors
      If [Enum].TryParse(colorString, colorValue) Then
        If [Enum].IsDefined(GetType(Colors), colorValue) Or colorValue.ToString().Contains(",") Then
          Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString())
        Else
          Console.WriteLine("{0} is not an underlying value of the Colors enumeration.", colorString)
        End If
      Else
        Console.WriteLine("{0} is not a member of the Colors enumeration.", colorString)
      End If
    Next
  End Sub
End Module
