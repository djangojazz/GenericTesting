Namespace APCLocal
  Partial Public Class [Select]

    ''' <summary>
    ''' WRAPS PROCEDURE APC_SP_SELECT_CostingReceiveFromWarehouse
    ''' </summary>
    Public Class ProductionPlanGroup
      Implements IDisposable

      'VARIABLES
      Private MyReader As SqlClient.SqlDataReader
      Private MyConnection As SqlClient.SqlConnection

      'CONSTRUCTORS
      Public Sub New(IP As String, Optional ProductionPlanGroupID As Integer? = Nothing, Optional ProductionPlanID As Integer? = Nothing)
        MyConnection = New SqlClient.SqlConnection(GetMyConnectionString(IP))
        MyConnection.Open()
        Dim oCmd As New SqlClient.SqlCommand("APC_SP_SELECT_ProductionPlanGroup", MyConnection)
        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.CommandTimeout = iTimeOut
        oCmd.Parameters.AddWithValue("@ProductionPlanGroupID", If(ProductionPlanGroupID, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@ProductionPlanID", If(ProductionPlanID, DirectCast(DBNull.Value, Object)))
        MyReader = oCmd.ExecuteReader
      End Sub

      'ENUMERATIONS
      Public Enum ENbr
        EstimatedQuantity
        QuantityPerCrewHour
        EstimatedHoursToComplete
      End Enum

      Public Enum EInts
        RecordServerID
        ProductionPlanGroupID
        ProductionPlanID
        UOM
        ProductFormatId
        ProductID
        CreatedBy
        LastModifiedBy
      End Enum

      Public Enum EStrings
        ProductionDescription
        ProductionType
        HarvestedCountry
        ProcessedCountry
        HatchedCountry
        RaisedCountry
      End Enum

      Public Enum EDates
        DateCreated
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