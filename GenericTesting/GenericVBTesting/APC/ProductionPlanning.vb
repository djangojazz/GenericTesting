Imports System.Runtime.CompilerServices
Imports ADODataAccess.u

Module ProductionPlanning
  Private _enums As New Dictionary(Of Integer, String)

  Private Sub GetEnums()
    For Each e As EUOM In [Enum].GetValues(GetType(EUOM))
      _enums.Add(e, e.ToString)
    Next
  End Sub

  Sub New()
    GetEnums()
  End Sub


  Private Function GetDescription(productFormatChanges As List(Of ProductFormatChange), productFormats As Dictionary(Of Integer, String), productFormatChangeId As Integer) As String
    Dim productFormatChange = productFormatChanges.FirstOrDefault(Function(x) x.ProductFormatChangeId = productFormatChangeId)

    If productFormatChange IsNot Nothing Then
      Return $"Level {(GetLevel(productFormatChanges, productFormatChangeId))} - {Math.Round(CDbl(productFormatChange.RecoveryRate * 100), 2)}% - {_enums.Single(Function(x) x.Key = productFormatChange.UOM).Value} - {productFormats.SingleOrDefault(Function(z) z.Key = productFormatChange.ProductFormatId).Value}"
    Else
      Return $"NOTHING"
    End If
  End Function

  <Extension>
  Friend Function DetermineExistingProductFormatChangeLevels(productFormatChanges As List(Of ProductFormatChange), productFormats As Dictionary(Of Integer, String), productId As Integer) As Dictionary(Of Integer, String)
    Dim itemsFound = productFormatChanges.Where(Function(x) x.ProductId = productId).ToDictionary(
                                                                                          Function(y) y.ProductFormatId,
                                                                                          Function(y) GetDescription(productFormatChanges, productFormats, y.ProductFormatChangeId)
                                                                                          )
    Return If(itemsFound.Any, itemsFound, New Dictionary(Of Integer, String) From {{1, "NOTHING"}})
  End Function

  Private Function GetLevel(productFormatChanges As List(Of ProductFormatChange), id As Integer) As Integer
    Dim lvl As Integer = 0

    Do
      Dim ThisItem = productFormatChanges.SingleOrDefault(Function(x) x.ProductFormatChangeId = id)
      If ThisItem IsNot Nothing Then lvl += 1 : id = ThisItem.ParentProductFormatChangeId Else If lvl = 0 Then Return -1
    Loop While id <> 0

    Return lvl
  End Function

  <Extension>
  Friend Function ReturnHeirarchyValueOfProductFormatId(productFormatChanges As List(Of ProductFormatChange), productFormats As Dictionary(Of Integer, String), productId As Integer, productFormatId As Integer) As String
    Return If(productFormatChanges.GetLevelsOfProductFormatChanges(productFormats, productId).SingleOrDefault(Function(x) x.ProductFormatId = productFormats.SingleOrDefault(Function(y) y.Key = productFormatId).Key)?.Description, "NOTHING")
  End Function

  <Extension>
  Friend Function DetermineCalculationOfValueFromOneLevelToAnother(productFormatChanges As List(Of ProductFormatChange), startingProductFormatChange As Integer, endingProductFormatChange As Integer, inputValue As Double, childOrParent As Boolean) As Double
    Dim poco = productFormatChanges.FirstOrDefault(Function(x) x.ProductFormatChangeId = startingProductFormatChange)
    If poco Is Nothing Then Return -1

    If childOrParent Then inputValue *= poco.RecoveryRate Else inputValue /= poco.RecoveryRate

    If poco.ProductFormatChangeId = endingProductFormatChange Then Return inputValue

    If childOrParent Then
      Dim childProductFormatChangeId = If(productFormatChanges.SingleOrDefault(Function(x) x.ParentProductFormatChangeId = poco.ProductFormatChangeId)?.ProductFormatChangeId, -1)
      If childProductFormatChangeId = -1 Then Return -1
      Return DetermineCalculationOfValueFromOneLevelToAnother(productFormatChanges, childProductFormatChangeId, endingProductFormatChange, inputValue, True)
    Else
      Dim parentProductFormatChangeId = If(productFormatChanges.SingleOrDefault(Function(x) x.ProductFormatChangeId = poco.ParentProductFormatChangeId)?.ProductFormatChangeId, -1)
      If parentProductFormatChangeId = -1 Then Return -1
      Return DetermineCalculationOfValueFromOneLevelToAnother(productFormatChanges, parentProductFormatChangeId, endingProductFormatChange, inputValue, False)
    End If

  End Function

  <Extension>
  Friend Function GetLevelsOfProductFormatChanges(productFormatChanges As List(Of ProductFormatChange), productFormats As Dictionary(Of Integer, String), Optional productId As Integer? = Nothing) As List(Of ProductFormatChange)
    If productId IsNot Nothing Then
      Return productFormatChanges.Where(Function(x) x.ProductId = productId.Value).Select(Function(x) New ProductFormatChange With
      {
        .ProductFormatChangeId = x.ProductFormatChangeId,
        .ProductFormatId = x.ProductFormatId,
        .ProductId = x.ProductId,
        .Description = GetDescription(productFormatChanges, productFormats, x.ProductFormatChangeId)
      }).ToList()
    Else
      Return productFormatChanges.Select(Function(x) New ProductFormatChange With
      {
        .ProductFormatChangeId = x.ProductFormatChangeId,
        .ProductFormatId = x.ProductFormatId,
        .ProductId = x.ProductId,
        .Description = GetDescription(productFormatChanges, productFormats, x.ProductFormatChangeId)
      }).ToList()
    End If

  End Function
End Module
