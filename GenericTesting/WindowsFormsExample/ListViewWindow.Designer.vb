<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListViewWindow
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
    Me.lsv = New System.Windows.Forms.ListView()
    Me.PersonId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.FirstName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.LastName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.tTest = New System.Windows.Forms.TextBox()
    Me.lTest = New System.Windows.Forms.Label()
    Me.bFilter = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'lsv
    '
    Me.lsv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PersonId, Me.FirstName, Me.LastName})
    Me.lsv.Location = New System.Drawing.Point(24, 12)
    Me.lsv.Name = "lsv"
    Me.lsv.Size = New System.Drawing.Size(631, 97)
    Me.lsv.TabIndex = 0
    Me.lsv.UseCompatibleStateImageBehavior = False
    '
    'PersonId
    '
    Me.PersonId.Width = 50
    '
    'FirstName
    '
    Me.FirstName.Width = 150
    '
    'LastName
    '
    Me.LastName.Width = 150
    '
    'tTest
    '
    Me.tTest.Location = New System.Drawing.Point(155, 148)
    Me.tTest.Name = "tTest"
    Me.tTest.Size = New System.Drawing.Size(100, 20)
    Me.tTest.TabIndex = 1
    Me.tTest.Text = "1"
    '
    'lTest
    '
    Me.lTest.AutoSize = True
    Me.lTest.Location = New System.Drawing.Point(35, 155)
    Me.lTest.Name = "lTest"
    Me.lTest.Size = New System.Drawing.Size(52, 13)
    Me.lTest.TabIndex = 2
    Me.lTest.Text = "Test data"
    '
    'bFilter
    '
    Me.bFilter.Location = New System.Drawing.Point(335, 145)
    Me.bFilter.Name = "bFilter"
    Me.bFilter.Size = New System.Drawing.Size(75, 23)
    Me.bFilter.TabIndex = 3
    Me.bFilter.Text = "Filter It"
    Me.bFilter.UseVisualStyleBackColor = True
    '
    'ListViewWindow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(790, 359)
    Me.Controls.Add(Me.bFilter)
    Me.Controls.Add(Me.lTest)
    Me.Controls.Add(Me.tTest)
    Me.Controls.Add(Me.lsv)
    Me.Name = "ListViewWindow"
    Me.Text = "ListView"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents lsv As System.Windows.Forms.ListView
  Friend WithEvents PersonId As ColumnHeader
  Friend WithEvents FirstName As ColumnHeader
  Friend WithEvents LastName As ColumnHeader
  Friend WithEvents tTest As TextBox
  Friend WithEvents lTest As Label
  Friend WithEvents bFilter As Button
End Class
