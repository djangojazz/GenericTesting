Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Class TestQueue
  ' Demonstrates:
  ' ConcurrentQueue<T>.Enqueue()
  ' ConcurrentQueue<T>.TryPeek()
  ' ConcurrentQueue<T>.TryDequeue()
  Shared Sub Main()
    ' Construct a ConcurrentQueue
    Dim cq As New ConcurrentQueue(Of KeyValuePair(Of Integer, Integer))

    ' Populate the queue
    For i As Integer = 0 To 500
      Dim divisiblity3 = (i Mod 3) = 0
      Dim divisiblity2 = (i Mod 2) = 0

      Dim group = If(divisiblity3, 3, If(divisiblity2, 2, 1))
      cq.Enqueue(New KeyValuePair(Of Integer, Integer)(group, i))
    Next

    ' Peek at the first element
    Dim result As KeyValuePair(Of Integer, Integer)
    If Not cq.TryPeek(result) Then
      Console.WriteLine("CQ: TryPeek failed when it should have succeeded")
    ElseIf result.Value <> 0 Then
      Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result)
    End If

    Dim outerSum As New KeyValuePair(Of Integer, Integer)
    Dim localSum As New KeyValuePair(Of Integer, Integer)

    ' An action to consume the ConcurrentQueue
    Dim fnc As Func(Of Integer, Integer) =
        Function()
          Dim localValue As KeyValuePair(Of Integer, Integer)
          While cq.TryDequeue(localValue)
            localSum = localValue
          End While
          'Interlocked.Add(outerSum, localSum)
        End Function

    ' Start 4 concurrent consuming actions
    Parallel.Invoke(
    Sub()
      fnc(1)
    End Sub)

    Console.WriteLine($"outerSum = {outerSum}, should be 49995000 {localSum}")
  End Sub
End Class