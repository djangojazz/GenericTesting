Public Class MyButtonCell
  Inherits DataGridViewComboBoxCell
  Protected Overrides Sub Paint(graphics As Graphics, clipBounds As Rectangle, cellBounds As Rectangle, rowIndex As Integer, elementState As DataGridViewElementStates, value As Object,
    formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)

    ButtonRenderer.DrawButton(graphics, cellBounds, formattedValue.ToString(), New Font("Comic Sans MS", 9.0F, FontStyle.Bold), True, System.Windows.Forms.VisualStyles.PushButtonState.[Default])
  End Sub
End Class
