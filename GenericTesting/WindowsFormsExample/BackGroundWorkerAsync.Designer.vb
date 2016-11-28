<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BackGroundWorkerAsync
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.lvItems = New System.Windows.Forms.ListView()
    Me.btnStartProcess = New System.Windows.Forms.Button()
    Me.txtCount = New System.Windows.Forms.TextBox()
    Me.btnRestart = New System.Windows.Forms.Button()
    Me.btnStopWork = New System.Windows.Forms.Button()
    Me.bwList = New System.ComponentModel.BackgroundWorker()
    Me.pbList = New System.Windows.Forms.ProgressBar()
    Me.SuspendLayout()
    '
    'lvItems
    '
    Me.lvItems.Location = New System.Drawing.Point(13, 52)
    Me.lvItems.Name = "lvItems"
    Me.lvItems.Size = New System.Drawing.Size(677, 360)
    Me.lvItems.TabIndex = 0
    Me.lvItems.UseCompatibleStateImageBehavior = False
    '
    'btnStartProcess
    '
    Me.btnStartProcess.Location = New System.Drawing.Point(13, 439)
    Me.btnStartProcess.Name = "btnStartProcess"
    Me.btnStartProcess.Size = New System.Drawing.Size(75, 23)
    Me.btnStartProcess.TabIndex = 1
    Me.btnStartProcess.Text = "Start Process"
    Me.btnStartProcess.UseVisualStyleBackColor = True
    '
    'txtCount
    '
    Me.txtCount.Location = New System.Drawing.Point(426, 439)
    Me.txtCount.Name = "txtCount"
    Me.txtCount.Size = New System.Drawing.Size(100, 20)
    Me.txtCount.TabIndex = 2
    Me.txtCount.Text = "100"
    '
    'btnRestart
    '
    Me.btnRestart.Location = New System.Drawing.Point(127, 439)
    Me.btnRestart.Name = "btnRestart"
    Me.btnRestart.Size = New System.Drawing.Size(75, 23)
    Me.btnRestart.TabIndex = 3
    Me.btnRestart.Text = "Restart Process"
    Me.btnRestart.UseVisualStyleBackColor = True
    '
    'btnStopWork
    '
    Me.btnStopWork.Location = New System.Drawing.Point(250, 439)
    Me.btnStopWork.Name = "btnStopWork"
    Me.btnStopWork.Size = New System.Drawing.Size(75, 23)
    Me.btnStopWork.TabIndex = 4
    Me.btnStopWork.Text = "Stop Process"
    Me.btnStopWork.UseVisualStyleBackColor = True
    '
    'bwList
    '
    Me.bwList.WorkerReportsProgress = True
    Me.bwList.WorkerSupportsCancellation = True
    '
    'pbList
    '
    Me.pbList.Location = New System.Drawing.Point(12, 13)
    Me.pbList.Name = "pbList"
    Me.pbList.Size = New System.Drawing.Size(678, 23)
    Me.pbList.TabIndex = 5
    '
    'BackGroundWorkerAsync
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(702, 493)
    Me.Controls.Add(Me.pbList)
    Me.Controls.Add(Me.btnStopWork)
    Me.Controls.Add(Me.btnRestart)
    Me.Controls.Add(Me.txtCount)
    Me.Controls.Add(Me.btnStartProcess)
    Me.Controls.Add(Me.lvItems)
    Me.Name = "BackGroundWorkerAsync"
    Me.Text = "BackGroundWorkerAsync"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents lvItems As ListView
  Friend WithEvents btnStartProcess As Button
  Friend WithEvents txtCount As TextBox
  Friend WithEvents btnRestart As Button
  Friend WithEvents btnStopWork As Button
  Friend WithEvents bwList As System.ComponentModel.BackgroundWorker
  Friend WithEvents pbList As ProgressBar
End Class
