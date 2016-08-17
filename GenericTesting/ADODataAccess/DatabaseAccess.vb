Public Module DatabaseAccess
  Public Function GetTesterDatabase() As String
    Return "data source=(local);initial catalog=Tester;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;"
  End Function

  Public Function GetCentralTestDatabase() As String
    Return "data source=APC-Dev;initial catalog=PSG_APC_CENTRAL;Integrated Security=False;password=pa55word;user id=sqluser;Connect Timeout=40;"
  End Function
End Module
