Imports System.Windows.Threading
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF

Public Class SubscriptionToQueueDTO
  Public Property ChartName As String
  Public Property Dispatcher As Dispatcher
  Public Property SleepDuration As Integer

  Public Overrides Function Equals(obj As Object) As Boolean
    If TypeOf obj Is SubscriptionToQueueDTO Then
      Return DirectCast(obj, SubscriptionToQueueDTO).ChartName = Me.ChartName
    Else
      Return False
    End If
  End Function

  Public Overrides Function GetHashCode() As Integer
    Return ChartName.GetHashCode
  End Function

End Class

Public Class MapLocationToQueueDTO
  Public Property SubscriptionToQueueDTO As SubscriptionToQueueDTO
  Public Property DistanceThreshold As Double
  Public Property Location As LocationRect
  Public Property ProducerCompleted As Action(Of IList(Of ShipGroupingModel))
End Class