
Public Class Person
  Public Property PersonID As Integer
  Public Property FirstName As String
  Public Property LastName As String
  Public Property ProductId As Integer
  Public Property SkuId As Integer
End Class

Public Class Product
  Public Property ProductId As Integer
  Public Property Description As String
  Public Property Active_Flag As Boolean
End Class

Public Class Order
  Public Property OrderId As Integer
  Public Property Description As String
End Class

Public Class PersonOrder
  Public Property PersonID As Integer
  Public Property FirstName As String
  Public Property LastName As String
  Public Property OrderId As Integer
End Class

Public Class Sku
  Public Property SKUId As Integer
  Public Property ProductId As Integer
  Public Property Description As String
End Class

Public Class TreeTest
  Public Property Id As Integer
  'Public Property Val As String
  'Public Property ParentId As Integer
  'Public Property Created As DateTime
  'Public Property Modified As DateTime
  'Public Property Active As Boolean
End Class