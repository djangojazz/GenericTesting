Namespace APCLocal
  Partial Public Class [Select]

    Public Class ReceivingPlanDetailByProductionId
      Implements IDisposable

      'VARIABLES
      Private MyReader As SqlClient.SqlDataReader
      Private MyConnection As SqlClient.SqlConnection

      'CONSTRUCTORS
      Public Sub New(ByVal IP As String, ByVal ProductionID As Integer)
        MyConnection = New SqlClient.SqlConnection(GetMyConnectionString(IP))
        MyConnection.Open()
        Dim oCmd As New System.Data.SqlClient.SqlCommand("APC_SP_SELECT_BoatHailDetailByProductionID", MyConnection)
        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.CommandTimeout = iTimeOut
        oCmd.Parameters.AddWithValue("@ProductionID", ProductionID)
        MyReader = oCmd.ExecuteReader
      End Sub

      'ENUMERATIONS
      Public Enum ENbr
        GrossPounds
        UnloadPounds
        NetPounds
        BaseCostPnd
        ProductionCostPnd
        LastIcedAmount
        HailPounds
      End Enum

      Public Enum EInts
        PKID
        ProductionID
        ProductID
        SubTypeID
        FormID
        StateID
        GradeID
        SizeID
        CatchMethodId
        GovId
        PackagingTypeID
        BrandID
        UnitTypeID
        Units
        MethodOfCultivation
        CountryHatched
        CountryRaised
        CountryHarvested
        CountryProcessed
        UOM
        HailDetailID
        LastModifiedBy
        QuotaSpeciesID
      End Enum

      Public Enum EStrings
        Brand
        Product
        CatchMethod
        Form
        GovIDDesc
        Grade
        Size
        State
        SubType
        Packaging
        UnitType
        AS400Item
        Gov
        AS400Description
      End Enum

      Public Enum EBools
        ByProduct
        Unprocessed
        LastIced
        IsComplete
      End Enum

      Public Enum EDates
        CatchDate
        DateLastModified
      End Enum

      'PROPERTIES

      Public ReadOnly Property Dec(ByVal Field As ENbr) As Decimal
        Get
          Return CDec(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Dbl(ByVal Field As ENbr) As Double
        Get
          Return CDbl(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Int(ByVal Field As EInts) As Integer
        Get
          Return CInt(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Str(ByVal Field As EStrings) As String
        Get
          Return MyReader(Field.ToString).ToString
        End Get
      End Property

      Public ReadOnly Property Bool(ByVal Field As EBools) As Boolean
        Get
          Return CBool(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Dte(ByVal Field As EDates) As Date
        Get
          Return CDate(MyReader(Field.ToString))
        End Get
      End Property


      Public Function Read() As Boolean
        Return MyReader.Read
      End Function

      Public Function IsClosed() As Boolean
        Return MyReader.IsClosed
      End Function

      Public Sub Close()
        MyReader.Close()
        MyConnection.Close()
      End Sub

      Private disposedValue As Boolean = False   'To detect redundant calls

      'IDisposable
      Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            MyConnection.Dispose()
          End If
        End If
        Me.disposedValue = True
      End Sub

#Region " IDisposable Support "
      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region
    End Class


  End Class
End Namespace