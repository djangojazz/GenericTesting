Namespace APCLocal
  Friend Module Connection
    Public iTimeOut As Integer = 60

    Public Function GetMyConnectionString(ByVal IP As String) As String
      Return "data source=" & IP & ";initial catalog=APC_Local;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;"
    End Function

  End Module
End Namespace
