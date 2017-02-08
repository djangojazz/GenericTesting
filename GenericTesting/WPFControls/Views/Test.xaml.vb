Public Class Test
  Public Sub New()
    InitializeComponent()
    PART_TestLayout.DataContext = Me
  End Sub

  Public Shared ReadOnly TestTitleProperty As DependencyProperty = DependencyProperty.Register("TestTitle", GetType(String), GetType(Test), New UIPropertyMetadata(String.Empty))

  Public Property TestTitle As String
    Get
      Return CType(GetValue(TestTitleProperty), String)
    End Get
    Set
      SetValue(TestTitleProperty, Value)
    End Set
  End Property
End Class
