Imports System.Collections.Concurrent
Imports System.ComponentModel

Public Class SL_BackgroundWorker_VB


  Private bw As BackgroundWorker = New BackgroundWorker
  Private restartWorker = False

  Public Sub New()
    InitializeComponent()

    bw.WorkerReportsProgress = True
    bw.WorkerSupportsCancellation = True
    AddHandler bw.DoWork, AddressOf bw_DoWork
    AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
    AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

  End Sub
  Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    DoLogic()
  End Sub

  Private Sub DoLogic()
    If Not bw.IsBusy = True Then
      bw.RunWorkerAsync()
    Else
      If (bw.IsBusy) Then
        bw.CancelAsync()
        restartWorker = True
      Else
        bw.RunWorkerAsync()
      End If
    End If
  End Sub

  Private Sub buttonCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    If bw.WorkerSupportsCancellation = True Then
      bw.CancelAsync()
    End If
  End Sub
  Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
    Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

    For i = 1 To 10
      If bw.CancellationPending = True Then
        e.Cancel = True
        Exit For
      Else
        ' Perform a time consuming operation and report progress.
        System.Threading.Thread.Sleep(500)
        bw.ReportProgress(i * 10)
      End If
    Next

  End Sub
  Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
    If e.Cancelled = True Then
      If restartWorker Then
        Me.tbProgress.Text = "Restarting!"
      Else
        Me.tbProgress.Text = "Cancelled!"
      End If

    ElseIf e.Error IsNot Nothing Then
      Me.tbProgress.Text = "Error: " & e.Error.Message
    Else
      Me.tbProgress.Text = "Done!"
    End If

    If restartWorker Then
      restartWorker = False
      DoLogic()
    End If
  End Sub
  Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
    Me.tbProgress.Text = e.ProgressPercentage.ToString() & "%"
  End Sub
End Class
