Public Class ResizingPracticeForDataGrids
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    For i = 1 To 2
      Dim row = ds.Tables("Main").NewRow
      row("ID") = i
      row("Desc") = If(i = 1, "Brett", "John")
      ds.Tables("Main").Rows.Add(row)
    Next

    dgv1.DataSource = ds.Tables("Main")
    dgv2.DataSource = ds.Tables("Main")
    dgv3.DataSource = ds.Tables("Main")
    dgv4.DataSource = ds.Tables("Main")
  End Sub
End Class