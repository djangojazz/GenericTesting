<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DelayBeforeAction
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
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
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.bDelayTest = New System.Windows.Forms.Button()
    Me.txtEntry = New System.Windows.Forms.TextBox()
    Me.txtTest = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'bDelayTest
    '
    Me.bDelayTest.Location = New System.Drawing.Point(31, 133)
    Me.bDelayTest.Name = "bDelayTest"
    Me.bDelayTest.Size = New System.Drawing.Size(163, 57)
    Me.bDelayTest.TabIndex = 0
    Me.bDelayTest.Text = "Delay And Fire"
    Me.bDelayTest.UseVisualStyleBackColor = True
    '
    'txtEntry
    '
    Me.txtEntry.Location = New System.Drawing.Point(31, 31)
    Me.txtEntry.Name = "txtEntry"
    Me.txtEntry.Size = New System.Drawing.Size(163, 20)
    Me.txtEntry.TabIndex = 1
    Me.txtEntry.Text = "1000"
    '
    'txtTest
    '
    Me.txtTest.Location = New System.Drawing.Point(31, 73)
    Me.txtTest.Name = "txtTest"
    Me.txtTest.Size = New System.Drawing.Size(163, 20)
    Me.txtTest.TabIndex = 2
    Me.txtTest.Text = "Test Text I have here to look at"
    '
    'DelayBeforeAction
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Controls.Add(Me.txtTest)
    Me.Controls.Add(Me.txtEntry)
    Me.Controls.Add(Me.bDelayTest)
    Me.Name = "DelayBeforeAction"
    Me.Text = "DelayBeforeAction"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents bDelayTest As Button
  Friend WithEvents txtEntry As TextBox
  Friend WithEvents txtTest As TextBox
End Class
