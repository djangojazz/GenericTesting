Imports System.Runtime.CompilerServices

Public Module ExtensionMethods

  <Extension>
  Public Sub ClearAndAddRange(Of T)(input As IList(Of T), array As IEnumerable(Of T))
    input.Clear()
    For Each o In array
      input.Add(o)
    Next
  End Sub

End Module
