
Public Class Person
  Public Property PersonID As Integer
  Public Property FirstName As String
  Public Property LastName As String
  Public Property ProductId As Integer
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

