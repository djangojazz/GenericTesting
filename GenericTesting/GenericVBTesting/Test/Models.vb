Public Module Models
  Public Class POCO
    Public Property ID As Integer
    Public Property ParentID As Integer
    Public Property Value As String
  End Class

  Public Function GetPOOCs() As List(Of POCO)
    Return New List(Of POCO)({
                             New POCO With {.ID = 5, .ParentID = 0, .Value = "A"},
                             New POCO With {.ID = 8, .ParentID = 5, .Value = "B"},
                             New POCO With {.ID = 11, .ParentID = 8, .Value = "C"}
                    })
  End Function
End Module
