﻿Public Module u
  Public Class ProductFormatChange
    Private p As Object()

    Public Property ProductFormatChangeId As Integer
    Public Property ProductId As Integer
    Public Property ParentProductFormatChangeId As Integer
    Public Property ProductFormatId As Integer
    Public Property RecoveryRate As Decimal
    Public Property UOM As Integer
    Public Property LastModifiedDate As DateTime
    Public Property LastModifiedBy As String
    Public Property Description As String
    Public Property Active_Flag As Boolean
  End Class
End Module
