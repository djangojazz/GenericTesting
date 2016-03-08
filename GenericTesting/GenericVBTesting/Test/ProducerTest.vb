Imports System.Collections.Concurrent
Imports System.Windows.Threading
Imports GenericVBTesting.BoatTesting
Imports Microsoft.Maps.MapControl.WPF

Public NotInheritable Class ProducerTest

  Private Shared _instance As ProducerTest
  Private _producer As New Threading.Thread(AddressOf ThreadProcessing)
  Private _queue As New ConcurrentQueue(Of MapLocationToQueueDTO)
  Private _sleepDuration As Integer = 15I
  Private _chartName As String
  Private _dispatcher As Dispatcher
  Private _listings As New ConcurrentBag(Of SubscriptionToQueueDTO)
  Private _lock As New Object

  Private Sub New()
  End Sub

  Public CurrentlyProcessing As Boolean

  Public Shared ReadOnly Property Instance() As ProducerTest
    Get
      If _instance Is Nothing Then
        _instance = New ProducerTest
      End If
      Return _instance
    End Get
  End Property

  Public Sub Subscribe(subscriptionToQueueDTO As SubscriptionToQueueDTO, mapLocationToQueueDTO As MapLocationToQueueDTO)
    Dim listing = GetListingBySubscription(subscriptionToQueueDTO)

    If listing Is Nothing Then
      AddToConcurrentBag(subscriptionToQueueDTO)
    End If

    If Not CurrentlyProcessing Then CurrentlyProcessing = True
    If Not _producer.IsAlive Then _producer.Start()

    _queue.Enqueue(mapLocationToQueueDTO)
  End Sub

  Private Sub AddToConcurrentBag(subscriptionToQueueDTO As SubscriptionToQueueDTO)
    Dim listing = GetListingBySubscription(subscriptionToQueueDTO)

    If listing Is Nothing Then
      _listings.Add(subscriptionToQueueDTO)
    End If
  End Sub

  Public Sub Unsubscribe(subscriptionToQueueDTO As SubscriptionToQueueDTO)
    SyncLock _lock
      Dim listing = GetListingBySubscription(subscriptionToQueueDTO)
      Dim listingsNew = _listings.Where(Function(x) x.ChartName <> listing.ChartName).ToList()
      _listings = New ConcurrentBag(Of SubscriptionToQueueDTO)(listingsNew)
    End SyncLock

    If Not _listings.Any Then CurrentlyProcessing = False
  End Sub

  Private Sub ThreadProcessing()
    Do While (CurrentlyProcessing)
      Dim ToProcess As MapLocationToQueueDTO = Nothing
      _queue.TryDequeue(ToProcess)
      If Not CurrentlyProcessing Then Exit Sub

      If Not ToProcess Is Nothing Then
        Dim listing = GetListingBySubscription(ToProcess.SubscriptionToQueueDTO)
        Threading.Thread.Sleep(listing.SleepDuration)

        If _queue.Count = 0 And Not IsNothing(ToProcess) Then
          Dim ships = New List(Of ShipGroupingModel)(New List(Of ShipGroupingModel)({New ShipGroupingModel With {.Location = New Location(45.500111, -123.000111), .ShipType = BoatTesting.ShipType.Owned}}))
          listing.Dispatcher.BeginInvoke(ToProcess.ProducerCompleted, ships)
          If Not CurrentlyProcessing Then Exit Sub
        End If
      End If
    Loop
  End Sub

  Private Function GetListingBySubscription(subscriptionToQueueDTO As SubscriptionToQueueDTO) As SubscriptionToQueueDTO
    Return _listings.SingleOrDefault(Function(x) x.ChartName = subscriptionToQueueDTO.ChartName And x.Dispatcher.Thread.ManagedThreadId = subscriptionToQueueDTO.Dispatcher.Thread.ManagedThreadId)
  End Function
End Class
