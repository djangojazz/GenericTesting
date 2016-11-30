<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DelayBeforeAction
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
    Me.components = New System.ComponentModel.Container()
    Me.txtWait = New System.Windows.Forms.TextBox()
    Me.txtTest = New System.Windows.Forms.TextBox()
    Me.bw = New System.ComponentModel.BackgroundWorker()
    Me.timer = New System.Windows.Forms.Timer(Me.components)
    Me.txtOut = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'txtWait
    '
    Me.txtWait.Location = New System.Drawing.Point(12, 12)
    Me.txtWait.Name = "txtWait"
    Me.txtWait.Size = New System.Drawing.Size(163, 20)
    Me.txtWait.TabIndex = 1
    Me.txtWait.Text = "1000"
    '
    'txtTest
    '
    Me.txtTest.Location = New System.Drawing.Point(12, 47)
    Me.txtTest.Name = "txtTest"
    Me.txtTest.Size = New System.Drawing.Size(163, 20)
    Me.txtTest.TabIndex = 2
    Me.txtTest.Text = "Test Text I have here to look at"
    '
    'bw
    '
    Me.bw.WorkerReportsProgress = True
    Me.bw.WorkerSupportsCancellation = True
    '
    'timer
    '
    '
    'txtOut
    '
    Me.txtOut.Location = New System.Drawing.Point(12, 93)
    Me.txtOut.Name = "txtOut"
    Me.txtOut.Size = New System.Drawing.Size(163, 20)
    Me.txtOut.TabIndex = 3
    '
    'DelayBeforeAction
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(195, 148)
    Me.Controls.Add(Me.txtOut)
    Me.Controls.Add(Me.txtTest)
    Me.Controls.Add(Me.txtWait)
    Me.Name = "DelayBeforeAction"
    Me.Text = "DelayBeforeAction"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtWait As TextBox
  Friend WithEvents txtTest As TextBox
  Friend WithEvents bw As System.ComponentModel.BackgroundWorker
  Friend WithEvents timer As Timer
  Friend WithEvents txtOut As TextBox
End Class
