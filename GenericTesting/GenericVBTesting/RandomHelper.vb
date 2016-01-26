Imports System.Text

Public Class RandomHelper
  Public Function ReturnRandomName(rand As Random, length As Integer) As String
    Dim alphas As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Dim sb As StringBuilder = New StringBuilder

    For i As Integer = 1 To length
      Dim idx As Integer = rand.Next(0, 25)
      sb.Append(alphas.Substring(idx, 1))
    Next

    sb.Append(" ")

    For i As Integer = 1 To length
      Dim idx As Integer = rand.Next(0, 25)
      sb.Append(alphas.Substring(idx, 1))
    Next

    Return sb.ToString
  End Function
End Class
