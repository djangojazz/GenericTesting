Public Class MarkBase
  Inherits UserControl

  Public Shared ReadOnly TestProperty As DependencyProperty = DependencyProperty.Register("GetTheDamnValue", GetType(String), GetType(MarkBase), New UIPropertyMetadata(String.Empty))

  Public Property GetTheDamnValue As String
    Get
      Return DirectCast(GetValue(TestProperty), String)
    End Get
    Set(value As String)
      SetValue(TestProperty, value)
    End Set
  End Property

End Class
