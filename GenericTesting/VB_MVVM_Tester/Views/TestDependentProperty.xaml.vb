Public Class TestDependentProperty
  Public Sub New()
    InitializeComponent()
  End Sub

  Public Shared ReadOnly TestProperty As DependencyProperty = DependencyProperty.Register("Test", GetType(String), GetType(TestDependentProperty), New UIPropertyMetadata(String.Empty))

  Public Property Test As String
    Get
      Return CType(GetValue(TestProperty), String)
    End Get
    Set
      SetValue(TestProperty, Value)
    End Set
  End Property
End Class
