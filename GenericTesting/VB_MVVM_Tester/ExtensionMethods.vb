Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml
Imports System.Xml.Serialization

Public Module ExtensionMethods

#Region "IEnumerable"

  <Extension>
  Public Sub ClearAndAddRange(Of T)(input As IList(Of T), array As IEnumerable(Of T))
    input.Clear()
    For Each o In array
      input.Add(o)
    Next
  End Sub

#End Region
End Module
