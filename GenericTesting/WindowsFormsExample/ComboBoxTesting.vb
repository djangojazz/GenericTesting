Public Class ComboBoxTesting
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    Dim c = CType(dgv.Columns("cmb"), DataGridViewComboBoxColumn)
    c.DataSource = New List(Of String)({"A", "B", "C"})

    Dim c2 = CType(dgv.Columns("cmb2"), DataGridViewComboBoxColumn)
    c2.CellTemplate = New MyButtonCell()
    'c2.Cel
    c2.DataSource = New List(Of String)({"A", "B", "C"})

  End Sub
End Class