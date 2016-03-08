Imports System.Runtime.CompilerServices

Module Extensions

  <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="1")>
  <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId:="0")>
  <Extension, DebuggerStepThrough>
  Public Sub ClearAndAddRange(Of T)(input As IList(Of T), Array As IEnumerable(Of T))
    input.Clear()
    For Each o In Array
      input.Add(o)
    Next
  End Sub

End Module
