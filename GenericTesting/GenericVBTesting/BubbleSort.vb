Public Module BubbleSort
  Public Sub BubbleSort(ByRef ArrayIn() As Long)
    Dim i, j As Integer
    Dim t As Long
    For i = UBound(ArrayIn) To 0 Step -1
      For j = 0 To i - 1
        If ArrayIn(j) > ArrayIn(j + 1) Then
          Call swap(ArrayIn(j), ArrayIn(j + 1))
        End If
      Next j
    Next i
  End Sub

  Private Sub swap(ByRef data1 As Long, ByRef data2 As Long)
    Dim temp As Long
    temp = data1
    data1 = data2
    data2 = temp
  End Sub
End Module
