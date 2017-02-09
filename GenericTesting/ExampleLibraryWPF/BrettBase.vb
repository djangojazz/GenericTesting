Public Class BrettBase
  Inherits UserControl

  Public Shared ReadOnly BrettStringProperty As DependencyProperty = DependencyProperty.Register("BrettString", GetType(String), GetType(BrettBase), New UIPropertyMetadata(String.Empty))

  Public Property BrettString As String
    Get
      Return DirectCast(GetValue(BrettStringProperty), String)
    End Get
    Set
      SetValue(BrettStringProperty, Value)
    End Set
  End Property
End Class
