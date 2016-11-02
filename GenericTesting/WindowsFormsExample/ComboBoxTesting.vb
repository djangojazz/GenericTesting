Public Class ComboBoxTesting

  Private _d As New Dictionary(Of Integer, String)

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    Dim ls = New List(Of String)({"A", "B", "C"})
    _d = New Dictionary(Of Integer, String) From {{1, "A"}, {2, "B"}, {301, "C"}}

    Dim SetupComboBox As Action(Of ComboBox, Dictionary(Of Integer, String)) = (Sub(x, y)
                                                                                  x.DataSource = New BindingSource(y, Nothing)
                                                                                    x.ValueMember = "Key"
                                                                                    x.DisplayMember = "Value"
                                                                                End Sub)

    ' Add any initialization after the InitializeComponent() call.
    Dim c = CType(dgv.Columns("cmb"), DataGridViewComboBoxColumn)
    c.DataSource = ls

    Dim c2 = CType(dgv.Columns("cmb2"), DataGridViewComboBoxColumn)
    c2.CellTemplate = New MyButtonCell()
    c2.DataSource = ls

    SetupComboBox(cmbTest, _d)

    dgv.CurrentCell = Me.dgv(2, 0)
  End Sub

  Private Sub cmbTest_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbTest.DrawItem
    Dim brush = Brushes.Black
    e.DrawBackground()
    'This has to be done to get the value as otherwise it shows a string interpretation of a dictionary entry
    e.Graphics.DrawString(CType(cmbTest.Items(If(e.Index >= 0, e.Index, 0)), KeyValuePair(Of Integer, String)).Value, e.Font, brush, e.Bounds, StringFormat.GenericDefault)
    e.DrawFocusRectangle()
  End Sub
End Class