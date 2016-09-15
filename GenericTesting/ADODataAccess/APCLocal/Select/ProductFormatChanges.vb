Namespace APCLocal
  Partial Public Class [Select]

    Public Class ProductFormatChanges
      Implements IDisposable

      'VARIABLES
      Private MyReader As SqlClient.SqlDataReader
      Private MyConnection As SqlClient.SqlConnection

      'CONSTRUCTORS
      Public Sub New(IP As String, Optional productFormatChangeId As Integer? = Nothing, Optional productFormatId As Integer? = Nothing, Optional productId As Integer? = Nothing)
        MyConnection = New SqlClient.SqlConnection(GetMyConnectionString(IP))
        MyConnection.Open()
        Dim oCmd As New SqlClient.SqlCommand("APC_SP_SELECT_ProductFormatChange", MyConnection)
        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.CommandTimeout = iTimeOut
        oCmd.Parameters.AddWithValue("@ProductFormatChangeId", If(productFormatChangeId, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@ProductFormatId", If(productFormatId, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@ProductId", If(productId, DirectCast(DBNull.Value, Object)))
        MyReader = oCmd.ExecuteReader
      End Sub

      'ENUMERATIONS
      Public Enum EInts
        ProductFormatChangeID
        ProductId
        ParentProductFormatChangeId
        ProductFormatID
        UOM
      End Enum

      Public Enum EStrings
        LastModifiedBy
      End Enum

      Public Enum EDates
        LastModifiedDate
      End Enum

      Public Enum ENbr
        RecoveryRate
      End Enum
      'PROPERTIES

      Public ReadOnly Property Int(ByVal Field As EInts) As Integer
        Get
          Return If(IsDBNull(MyReader(Field.ToString)), New Integer, CInt(MyReader(Field.ToString)))
        End Get
      End Property

      Public ReadOnly Property Str(ByVal Field As EStrings) As String
        Get
          Return If(IsDBNull(MyReader(Field.ToString)), Nothing, CStr(MyReader(Field.ToString)))
        End Get
      End Property

      Public ReadOnly Property Dte(ByVal Field As EDates) As Date
        Get
          Return If(IsDBNull(MyReader(Field.ToString)), New Date, CDate(MyReader(Field.ToString)))
        End Get
      End Property

      Public ReadOnly Property Dec(ByVal Field As ENbr) As Decimal
        Get
          Return CDec(MyReader(Field.ToString))
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