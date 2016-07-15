<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorChecking
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
    Me.components = New System.ComponentModel.Container()
    Me.lblOne = New System.Windows.Forms.Label()
    Me.lblTwo = New System.Windows.Forms.Label()
    Me.txtOne = New System.Windows.Forms.TextBox()
    Me.txtTwo = New System.Windows.Forms.TextBox()
    Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.lblTest = New System.Windows.Forms.Label()
    CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lblOne
    '
    Me.lblOne.AutoSize = True
    Me.lblOne.Location = New System.Drawing.Point(13, 24)
    Me.lblOne.Name = "lblOne"
    Me.lblOne.Size = New System.Drawing.Size(27, 13)
    Me.lblOne.TabIndex = 0
    Me.lblOne.Text = "One"
    '
    'lblTwo
    '
    Me.lblTwo.AutoSize = True
    Me.lblTwo.Location = New System.Drawing.Point(13, 74)
    Me.lblTwo.Name = "lblTwo"
    Me.lblTwo.Size = New System.Drawing.Size(28, 13)
    Me.lblTwo.TabIndex = 1
    Me.lblTwo.Text = "Two"
    '
    'txtOne
    '
    Me.txtOne.Location = New System.Drawing.Point(78, 21)
    Me.txtOne.Name = "txtOne"
    Me.txtOne.Size = New System.Drawing.Size(100, 20)
    Me.txtOne.TabIndex = 2
    '
    'txtTwo
    '
    Me.txtTwo.Location = New System.Drawing.Point(78, 71)
    Me.txtTwo.Name = "txtTwo"
    Me.txtTwo.Size = New System.Drawing.Size(100, 20)
    Me.txtTwo.TabIndex = 3
    '
    'errorProvider
    '
    Me.errorProvider.ContainerControl = Me
    '
    'lblTest
    '
    Me.lblTest.AutoSize = True
    Me.lblTest.Location = New System.Drawing.Point(16, 144)
    Me.lblTest.Name = "lblTest"
    Me.lblTest.Size = New System.Drawing.Size(35, 13)
    Me.lblTest.TabIndex = 4
    Me.lblTest.Text = "TEST"
    '
    'ErrorChecking
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Controls.Add(Me.lblTest)
    Me.Controls.Add(Me.txtTwo)
    Me.Controls.Add(Me.txtOne)
    Me.Controls.Add(Me.lblTwo)
    Me.Controls.Add(Me.lblOne)
    Me.Name = "ErrorChecking"
    Me.Text = "ErrorChecking"
    CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents lblOne As Label
  Friend WithEvents lblTwo As Label
  Friend WithEvents txtOne As TextBox
  Friend WithEvents txtTwo As TextBox
  Friend WithEvents errorProvider As ErrorProvider
  Friend WithEvents lblTest As Label
End Class
