Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Threading
Imports System.Collections.ObjectModel
Imports ADODataAccess
Imports GenericVBTesting.Models
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Module1

  Private _talker As SQLTalker = New SQLTalker(GetTesterDatabase)
  Private _treeResults As New List(Of TreeTest)
  Private _products As New List(Of Product)

  Private example As New Lazy(Of String())(Function()
                                             Return "example split".Split(" "c)
                                           End Function)

  Sub Main()
    TaskFactoryCancellationMethod()

    Console.ReadLine()
  End Sub

  Private Sub TaskFactoryCancellationMethod()
    ' Define the cancellation token.
    Dim source As New CancellationTokenSource()
    Dim token As CancellationToken = source.Token

    Dim lockObj As New Object()
    Dim rnd As New Random

    Dim tasks As New List(Of Task(Of Integer()))
    Dim factory As New TaskFactory(token)
    For taskCtr As Integer = 0 To 10
      Dim iteration As Integer = taskCtr + 1
      tasks.Add(factory.StartNew(Function()
                                   Dim value, values(9) As Integer
                                   For ctr As Integer = 1 To 10
                                     SyncLock lockObj
                                       value = rnd.Next(0, 101)
                                     End SyncLock
                                     If value = 0 Then
                                       source.Cancel()
                                       Console.WriteLine("Cancelling at task {0}", iteration)
                                       Exit For
                                     End If
                                     values(ctr - 1) = value
                                   Next
                                   Return values
                                 End Function, token))

    Next
    Try
      Dim fTask As Task(Of Double) = factory.ContinueWhenAll(tasks.ToArray(),
                                                         Function(results)
                                                           Console.WriteLine("Calculating overall mean...")
                                                           Dim sum As Long
                                                           Dim n As Integer
                                                           For Each t In results
                                                             For Each r In t.Result
                                                               sum += r
                                                               n += 1
                                                             Next
                                                           Next
                                                           Return sum / n
                                                         End Function, token)
      Console.WriteLine("The mean is {0}.", fTask.Result)
    Catch ae As AggregateException
      For Each e In ae.InnerExceptions
        If TypeOf e Is TaskCanceledException Then
          Console.WriteLine("Unable to compute mean: {0}",
                                 CType(e, TaskCanceledException).Message)
        Else
          Console.WriteLine("Exception: " + e.GetType().Name)
        End If
      Next
    Finally
      source.Dispose()
    End Try
  End Sub

  Private Sub writeIt(header As String)
    Console.WriteLine(header)
    Console.WriteLine()
    _treeResults = DirectCast(DataConverter.ConvertTo(Of TreeTest)(_talker.GetData("SELECT Id, Val, ParentId, Created, Modified, Active From dbo.TreeTest")), List(Of TreeTest))
    _treeResults.ForEach(Sub(x) Console.WriteLine($"{x.Id} {x.Val} {x.ParentId} {x.Created} {x.Modified} {x.Active}"))
  End Sub
End Module
