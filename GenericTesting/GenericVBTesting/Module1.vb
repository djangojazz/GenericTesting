Imports System.Text
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF
Imports System.Windows.Threading
Imports System.Collections.ObjectModel
Imports ADODataAccess
Imports GenericVBTesting.Models

Module Module1

  Private MyConnection As SqlClient.SqlConnection
  Private MyReader As SqlClient.SqlDataReader

  Private listings As New Dictionary(Of String, String)
  Private chartSettingsFileLocation = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\OpenEnterprise\ChartSettings.xml"

  Sub Main()

    Console.ReadLine()
  End Sub


End Module
