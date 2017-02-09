Imports System.ComponentModel

Public Class Test


  Public Sub New()
    InitializeComponent()
    PART_TestLayout.DataContext = Me
  End Sub

#Region "TestTitle"
  Public Shared ReadOnly TestTitleProperty As DependencyProperty = DependencyProperty.Register("TestTitle", GetType(String), GetType(Test), New UIPropertyMetadata(String.Empty, AddressOf TestChanged))

  Public Property TestTitle As String
    Get
      Return CType(GetValue(TestTitleProperty), String)
    End Get
    Set
      SetValue(TestTitleProperty, Value)
    End Set
  End Property

  Private Shared Sub TestChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
    Dim m = DirectCast(d, Test)
    m.PART_Text2.Text = $"Changed {DateTime.Now.ToLongTimeString}"
  End Sub
#End Region

End Class
