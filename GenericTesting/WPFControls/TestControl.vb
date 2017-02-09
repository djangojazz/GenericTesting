Public Class TestControl
  Inherits Control

  Public Sub New()

  End Sub

  Public Shared ReadOnly TestProperty As DependencyProperty = DependencyProperty.Register("Test", GetType(String), GetType(TestControl), New UIPropertyMetadata(String.Empty))

  Public Property Test As String
    Get
      Return DirectCast(GetValue(TestProperty), String)
    End Get
    Set
      SetValue(TestProperty, Value)
    End Set
  End Property
End Class
