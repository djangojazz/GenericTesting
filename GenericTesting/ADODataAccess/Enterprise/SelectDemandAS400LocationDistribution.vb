Imports System.Data.SqlClient

Namespace Enterprise

  Partial Public Class [Select]

    ''' <summary>
    ''' WRAPS PROCEDURE PSGsp_SELECT_Budget_AdPlacementsbyActive
    ''' </summary>
    Public Class DemandAS400LocationDistribution
      Implements IDisposable

      'VARIABLES
      Private MyReader As SqlClient.SqlDataReader
      Private MyConnection As SqlClient.SqlConnection

      'CONSTRUCTORS
      Public Sub New(Optional parentsOnly As Integer? = 0, Optional demandAS400LocationDistributionId As Integer? = Nothing)
        MyConnection = New SqlConnection("Data Source=Dev-Enterprise;initial catalog=PSG_ENTERPRISE;Integrated Security=True;")
        MyConnection.Open()
        Dim oCmd As New SqlCommand("vis.pSelectDemandAS400LocationDistribution", MyConnection) With {.CommandType = CommandType.StoredProcedure, .CommandTimeout = 60}
        oCmd.Parameters.AddWithValue("@ParentsOnly", If(parentsOnly, DirectCast(DBNull.Value, Object)))
        oCmd.Parameters.AddWithValue("@DemandAS400LocationDistributionId", If(demandAS400LocationDistributionId, DirectCast(DBNull.Value, Object)))
        MyReader = oCmd.ExecuteReader
      End Sub


      'ENUMERATIONS
      Public Enum EInts
        DemandAS400LocationDistributionId
        BranchId
        ParentDemandAS400LocationDistributionId
      End Enum

      Public Enum EStrings
        CompanyNbr
        CompanyName
        DivisionNbr
        DivisionName
        BranchNbr
        BranchName
      End Enum

      Public Enum EDecimels
        PercentDistribution
      End Enum


      'PROPERTIES
      Public ReadOnly Property Int(Field As EInts) As Integer?
        Get
          Return If(IsDBNull(MyReader(Field.ToString)), Nothing, CInt(MyReader(Field.ToString)))
        End Get
      End Property

      Public ReadOnly Property Str(ByVal Field As EStrings) As String
        Get
          Return CStr(MyReader(Field.ToString))
        End Get
      End Property

      Public ReadOnly Property Dec(ByVal Field As EDecimels) As Decimal?
        Get
          Return If(IsDBNull(MyReader(Field.ToString)), Nothing, CDec(MyReader(Field.ToString)))
        End Get
      End Property



      Public Function Read() As Boolean?
        Return MyReader.Read
      End Function

      Public Function IsClosed() As Boolean?
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