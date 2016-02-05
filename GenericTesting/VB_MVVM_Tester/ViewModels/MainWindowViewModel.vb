
Imports System.Collections.ObjectModel

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _stuff As ObservableCollection(Of Stuff)

  Enum ShipTyper
    Owned = 1
    Contractor = 2
    Other = 3
  End Enum

  Private _items As ObservableCollection(Of Stuff)
  Public Property Items() As ObservableCollection(Of Stuff)
    Get
      Return _items
    End Get
    Set(ByVal value As ObservableCollection(Of Stuff))
      _items = value
      OnPropertyChanged(NameOf(Items))
    End Set
  End Property


  Sub New()

    Items = New ObservableCollection(Of Stuff)(New List(Of Stuff)({New Stuff With {.Id = 1, .Value = "Stuff", .ShipType = ShipType.Owned, .MoreStuff = "More Stuff"}, New Stuff With {.Id = 2, .Value = "Another"}}))
  End Sub
End Class
