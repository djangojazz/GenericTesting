Imports System.Data.SqlClient

Namespace Enterprise

  Partial Public NotInheritable Class [Select]

    Public Class DemandAS400LocationDistributionDateAllocation
      Implements IDisposable

      'VARIABLES
      Private MyReader As SqlDataReader
      Private MyConnection As SqlConnection

      'CONSTRUCTORS
      Public Sub New(Optional parentDemandAS400LocationDistributionId As Integer? = 0, Optional showXML As Boolean? = Nothing, Optional dateStart As DateTime? = Nothing, Optional dateEnd As DateTime? = Nothing, Optional demandAS400LocationDistributionId As Integer? = Nothing)
        MyConnection = New SqlConnection("Data Source=Dev-Enterprise;initial catalog=PSG_ENTERPRISE;Integrated Security=True;")
        MyConnection.Open()
        Dim oCmd As New SqlCommand("vis.pSelectDemandAS400LocationDistributionDateAllocation", MyConnection) With {.CommandType = CommandType.StoredProcedure, .CommandTimeout = 60}
        oCmd.Parameters.AddWithValue("@ParentDemandAS400LocationDistributionId", If(parentDemandAS400LocationDistributionId, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@ShowXML", If(showXML, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@DateStart", If(dateStart, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@DateEnd", If(dateEnd, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@DemandAS400LocationDistributionId", If(demandAS400LocationDistributionId, DirectCast(DBNull.Value, Object)))

        MyReader = oCmd.ExecuteReader
      End Sub


      'ENUMERATIONS
      Public Enum EInts
        DemandAS400LocationDistributionDateAllocationId
        ParentDemandAS400LocationDistributionId
        DemandAS400LocationDistributionId
        CreatedBy
      End Enum

      Public Enum EDates
        DateAllocated
      End Enum

      Public Enum EDecimals
        PercentUsed
      End Enum

      Public Enum EStrings
        xml
      End Enum

      'PROPERTIES
      Public ReadOnly Property Int(ByVal Field As EInts) As Integer
        Get
          Return CInt(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Dec(ByVal Field As EDecimals) As Decimal
        Get
          Return CDec(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Dte(ByVal Field As EDates) As Date
        Get
          Return CDate(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Str(ByVal Field As EStrings) As String
        Get
          Return CStr(MyReader(Field.ToString))
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