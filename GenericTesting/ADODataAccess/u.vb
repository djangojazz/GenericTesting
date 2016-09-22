Public Module u
  Public Enum EUOM
    Lbs = 1
    Ounces = 2
    Dozen = 3
    Bushel = 4
  End Enum

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

  Public Class Product
    Public Property ProductID As Integer
    Public Property ProductDesc As String
    Public Property SubTypeID As Integer
    Public Property SubTypeDescription As String
    Public Property FormID As Integer
    Public Property FormDescription As String
    Public Property StateID As Integer
    Public Property StateDescription As String
    Public Property GradeID As Integer
    Public Property GradeDescription As String
    Public Property SizeID As Integer
    Public Property SizeDescription As String
    Public Property CatchMethodID As Integer
    Public Property CatchDescription As String
    Public Property GovID As Integer
    Public Property GovDescription As String
    Public Property BrandID As Integer
    Public Property BrandDescription As String
    Public Property PackagingTypeID As Integer
    Public Property PackagingDescription As String
    Public Property UnitTypeID As Integer
    Public Property UnitType As String
    Public Property UOM As u.EUOM
    Public Property MethodOfCultivation As Integer
    Public Property CountryHarvestedID As Integer
    Public Property CountryProcessedID As Integer
    Public Property CountryHatchedID As Integer
    Public Property CountryRaisedID As Integer
    Public Property CatchDate As Date
    Public Property DerivedProductFormatChangeId As Integer
    Public Property DerivedProductFormatId As Integer
  End Class
End Module
