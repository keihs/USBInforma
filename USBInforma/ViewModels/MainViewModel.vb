Imports USBInforma.Models
Imports USBInforma.Infrastructure.Commands
Imports USBInforma.Views

Namespace ViewModels
	Public Class MainViewModel

		Private _mainView As MainWindow
		Private ReadOnly _mainmodel As MainModel

		Sub New(mainView As MainWindow)
			' TODO: Complete member initialization 
			_mainView = mainView
			_mainmodel = New MainModel

			LoadedCommand = New RelayCommand(AddressOf ExecuteLoaded)
			_mainmodel.GetPnPEntity()
		End Sub

		''' <summary>
		''' 画面ロード時
		''' </summary>
		Public Property LoadedCommand() As ICommand
		'	Get
		'		If _LoadedCommand Is Nothing Then
		'			_LoadedCommand = New RelayCommand(AddressOf ExecuteLoaded)
		'		End If
		'		Return _LoadedCommand
		'	End Get
		'End Property
		'Private _LoadedCommand As ICommand

		Private Sub ExecuteLoaded()
			_mainmodel.GetPnPEntity()
		End Sub

	End Class
End Namespace