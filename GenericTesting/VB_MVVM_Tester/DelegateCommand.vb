﻿Imports System
Imports System.Windows.Input

Public Class DelegateCommand(Of T)
  Implements ICommand
  Private _execute As Action(Of T)

  Public Sub New(execute As Action(Of T))
    _execute = execute
  End Sub

  'Public Function CanExecute(parameter As Object) As Boolean
  '  Return True
  'End Function

  Public Event CanExecuteChanged As EventHandler
  Private Event ICommand_CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

  'Public Sub Execute(parameter As Object)
  '  _execute.Invoke(DirectCast(parameter, T))
  'End Sub

  Private Function ICommand_CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
    Return True
  End Function

  Private Sub ICommand_Execute(parameter As Object) Implements ICommand.Execute
    _execute.Invoke(DirectCast(parameter, T))
  End Sub
End Class