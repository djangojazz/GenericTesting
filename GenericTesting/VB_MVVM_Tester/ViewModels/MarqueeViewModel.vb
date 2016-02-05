Public Class MarqueeViewModel
  Inherits BaseViewModel

  Public Sub New(text As String, duration As Duration)
    MarqueeText = text
    MarqueeTimeSpan = duration
  End Sub

  Private _marqueeText As String

  Public Property MarqueeText As String
    Get
      Return _marqueeText
    End Get
    Set(ByVal value As String)
      _marqueeText = value
      OnPropertyChanged(NameOf(MarqueeText))
    End Set
  End Property

  Private _marqueeTimeSpan As Duration

  Public Property MarqueeTimeSpan As Duration
    Get
      Return _marqueeTimeSpan
    End Get
    Set(ByVal value As Duration)
      _marqueeTimeSpan = value
      OnPropertyChanged(NameOf(MarqueeTimeSpan))
    End Set
  End Property
End Class
