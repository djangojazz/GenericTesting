Imports ADODataAccess

Public Class ProductFormats
  Public Function LoadProductFormats() As Dictionary(Of Integer, String)
    Dim productFormats = New Dictionary(Of Integer, String)
    Using myReader As New APCLocal.Select.ProductFormats("DEV-APC1")
      Do While myReader.Read
        productFormats.Add(myReader.Int(APCLocal.Select.ProductFormats.EInts.ProductFormatID), myReader.Str(APCLocal.Select.ProductFormats.EStrings.ProductFormatDescription))
      Loop
    End Using

    Return productFormats
  End Function

  Public Function LoadProductFormatChanges() As List(Of ProductFormatChange)
    Dim productFormatChanges As New List(Of ProductFormatChange)

    Using myReader As New APCLocal.Select.ProductFormatChanges("DEV-APC1", Nothing, Nothing, Nothing)
      Do While myReader.Read
        productFormatChanges.Add(New ProductFormatChange With
          {
            .ProductFormatChangeId = myReader.Int(APCLocal.Select.ProductFormatChanges.EInts.ProductFormatChangeID),
            .ProductId = myReader.Int(APCLocal.Select.ProductFormatChanges.EInts.ProductId),
            .ParentProductFormatChangeId = myReader.Int(APCLocal.Select.ProductFormatChanges.EInts.ParentProductFormatChangeId),
            .ProductFormatId = myReader.Int(APCLocal.Select.ProductFormatChanges.EInts.ProductFormatID),
            .RecoveryRate = myReader.Dec(APCLocal.Select.ProductFormatChanges.ENbr.RecoveryRate),
            .UOM = myReader.Int(APCLocal.Select.ProductFormatChanges.EInts.UOM),
            .LastModifiedDate = myReader.Dte(APCLocal.Select.ProductFormatChanges.EDates.LastModifiedDate),
            .LastModifiedBy = myReader.Str(APCLocal.Select.ProductFormatChanges.EStrings.LastModifiedBy)
        })
      Loop
    End Using

    Return productFormatChanges
  End Function
End Class
