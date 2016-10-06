Class AdvancedComboBox
  Inherits ComboBox

  Public Shadows Property DrawMode() As System.Windows.Forms.DrawMode
    Get
      Return m_DrawMode
    End Get
    Set
      m_DrawMode = Value
    End Set
  End Property
  Private Shadows m_DrawMode As System.Windows.Forms.DrawMode
  Public Property HighlightColor() As Color
    Get
      Return m_HighlightColor
    End Get
    Set
      m_HighlightColor = Value
    End Set
  End Property
  Private m_HighlightColor As Color

  Public Sub New()
    'MyBase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.HighlightColor = Color.Gray
    'AddHandler Me.DrawItem, AddressOf AdvancedComboBox_DrawItem
  End Sub

  Private Sub AdvancedComboBox_DrawItem(sender As Object, e As DrawItemEventArgs)
    If e.Index < 0 Then
      Return
    End If

    Dim combo As ComboBox = TryCast(sender, ComboBox)
    If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
      e.Graphics.FillRectangle(New SolidBrush(HighlightColor), e.Bounds)
    Else
      e.Graphics.FillRectangle(New SolidBrush(combo.BackColor), e.Bounds)
    End If

    e.Graphics.DrawString(combo.Items(e.Index).ToString(), e.Font, New SolidBrush(combo.ForeColor), New Point(e.Bounds.X, e.Bounds.Y))

    e.DrawFocusRectangle()
  End Sub
End Class