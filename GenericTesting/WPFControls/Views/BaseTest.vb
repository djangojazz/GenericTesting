Public Class BaseTest
  Inherits UserControl

  Public Sub New()
  End Sub

#Region "TestTitle"
  Public Shared ReadOnly TestTitleProperty As DependencyProperty = DependencyProperty.Register("TestTitle", GetType(String), GetType(BaseTest), New UIPropertyMetadata(String.Empty))

  Public Property TestTitle As String
    Get
      Return CType(GetValue(TestTitleProperty), String)
    End Get
    Set
      SetValue(TestTitleProperty, Value)
    End Set
  End Property
#End Region
End Class
