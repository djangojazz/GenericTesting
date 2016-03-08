Imports System.Diagnostics

Public Class GetCurrentThreads

  Public Sub GetThreads()
    Dim currentThreads As ProcessThreadCollection = Process.GetCurrentProcess().Threads

    For Each thread As ProcessThread In currentThreads
      Console.WriteLine($"Id: {thread.Id} ManagedThreadId: {Threading.Thread.CurrentThread.ManagedThreadId} StartAddress: {thread.StartAddress}")
    Next
  End Sub



End Class
