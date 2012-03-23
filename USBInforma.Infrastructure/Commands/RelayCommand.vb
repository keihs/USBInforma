Namespace Commands
	Public Class RelayCommand
		Implements ICommand

		Private ReadOnly _execute As Action(Of Object)
		Private ReadOnly _canExecute As Predicate(Of Object)

#Region "コンストラクタ"
		Public Sub New(ByVal execute As Action(Of Object))
			Me.New(execute, Nothing)
		End Sub

		Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
			If execute Is Nothing Then Throw New ArgumentNullException("execute")
			_execute = execute
			_canExecute = canExecute
		End Sub
#End Region

		Public Function CanExecute(ByVal parameter As Object) As Boolean Implements System.Windows.Input.ICommand.CanExecute
			Return (_canExecute Is Nothing) OrElse _canExecute(parameter)
		End Function

		Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
			AddHandler(ByVal value As EventHandler)
				AddHandler CommandManager.RequerySuggested, value
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				RemoveHandler CommandManager.RequerySuggested, value
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		Public Sub Execute(ByVal parameter As Object) Implements System.Windows.Input.ICommand.Execute
			_execute(parameter)
		End Sub
	End Class
End Namespace