﻿
Imports System.Collections.ObjectModel
Imports VB_MVVM_Tester
Imports WPFControls
Imports WPFControls.WPFControls

Public Class MainWindowViewModel
  Inherits BaseViewModel

  Private _address As String
  Private _locationAddress As String
  Private _queueFinished As Boolean = False
  Private _result As String
  Private _testText As String
  Private _points As String
  Private _mouseMove As String

  Public Sub DoIt(result As String)
    MessageBox.Show(result)
  End Sub

  Sub New()
    TestText = "Line Chart Hello there"
    'TreeData = New ObservableCollection(Of TreeViewItem)({New TreeViewItem With {.Header = "Test"}})

    AvailableItems.ClearAndAddRange({
                                    New Stuff With {.Id = 1, .ShipType = ShipType.Owned, .Value = "Boat1"},
                                    New Stuff With {.Id = 2, .ShipType = ShipType.Other, .Value = "Boat2"},
                                    New Stuff With {.Id = 3, .ShipType = ShipType.Other, .Value = "Boat3"},
                                    New Stuff With {.Id = 4, .ShipType = ShipType.Other, .Value = "Boat4"}
                                    })
    TestList.ClearAndAddRange(New List(Of String)({"a", "b", "c"}))
  End Sub

  Public ReadOnly Property AvailableItems As New ObservableCollection(Of Stuff)
  Public ReadOnly Property Items As New ObservableCollection(Of Stuff)

  Public ReadOnly Property TreeData As New ObservableCollection(Of TreeViewItem)
  Public ReadOnly Property TestList As New ObservableCollection(Of String)

  Public Property TestText As String
    Get
      Return _testText
    End Get
    Set
      _testText = Value
      OnPropertyChanged(NameOf(TestText))
    End Set
  End Property

  Public Property MouseMove As String
    Get
      Return _mouseMove
    End Get
    Set
      _mouseMove = Value

      'Dim result As String = String.Empty
      'Dim result2 As String
      'Dim action As Action(Of String) = Nothing
      'ProducerConsumerFinished = Nothing
      Dim poc = New POCO With {.Desc = Value, .DescAction = Function(x) x}

      ProducerConsumer.Instance.queue.Enqueue(poc)

      poc.DescAction = Sub(x) TestText = x

      'If Not action Is Nothing Then
      '  TestText = act
      'End If

      'Dim result As New POCO
      'ProducerConsumer.Instance.queue.TryPeek(result)

      'If Not result Is Nothing Then
      '  TestText = $"{ProducerConsumer.Instance.queue.Count} {result.Desc}"
      'End If

      'TestText = ProducerConsumer.Instance.Thing.Desc

      '_queueFinished = ProducerConsumer.Instance.queue.Count = 0
      'If _queueFinished Then
      '  TestText = $"Done {DateTime.Now.ToString()}"
      'End If

      OnPropertyChanged(NameOf(MouseMove))
    End Set
  End Property

#Region "Commands"
  Public ReadOnly Property TestCommand As New DelegateCommand(Of Object)(AddressOf TestCommandExecute)
  Public ReadOnly Property AddCommand As New DelegateCommand(Of Object)(AddressOf AddCommandExecute)
  Public ReadOnly Property DeleteCommand As New DelegateCommand(Of Object)(AddressOf DeleteCommandExecute)

  Private Sub AddCommandExecute(obj As Collection(Of Object))
    If obj Is Nothing Then Exit Sub

    Dim itemsToRemove = New List(Of Stuff)

    For Each s In obj
      Items.Add(s)
      itemsToRemove.Add(s)
    Next

    AvailableItems.ClearAndAddRange(_AvailableItems.ToList().Where(Function(x) Not itemsToRemove.Contains(x)))
  End Sub

  Private Sub DeleteCommandExecute(obj As Collection(Of Object))
    If obj Is Nothing Then Exit Sub

    Dim itemsToRemove = New List(Of Stuff)

    For Each s In obj
      AvailableItems.Add(s)
      itemsToRemove.Add(s)
    Next

    Items.ClearAndAddRange(_Items.ToList().Where(Function(x) Not itemsToRemove.Contains(x)))
  End Sub

  Private Sub TestCommandExecute()
    TestList.Add($"{DateTime.Now.ToLongDateString}")
    TestText = "Line Chart Hello there" + DateTime.Now.ToLongTimeString
  End Sub

  Private Sub StartCommandProdConsExecute()
    'TestText = "Start"

    For i As Integer = 1 To 10
      'Dim singleton = ProducerConsumer.Instance
      ProducerConsumer.Instance.queue.Enqueue(New POCO With {.Id = i, .Desc = i.ToString()})
    Next

    Dim value = ProducerConsumer.Instance.Thing.Id
    'TestText = $"{value}"
  End Sub
#End Region

End Class
