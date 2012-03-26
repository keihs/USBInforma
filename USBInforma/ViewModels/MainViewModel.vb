Imports System.Collections.ObjectModel
Imports USBInforma.Infrastructure.Commands
Imports USBInforma.Infrastructure.ViewModels
Imports USBInforma.Models
Imports USBInforma.Views

Namespace ViewModels
	Public Class MainViewModel
		Inherits MainViewModelBase

#Region " フィールド "
		' メインモデル
		Private ReadOnly _mainmodel As MainModel

		Private _mainView As MainWindow
#End Region

#Region " コンストラクタ "
		Sub New(mainView As MainWindow)
			' TODO: Complete member initialization 
			_mainView = mainView
			_mainmodel = New MainModel

			'Me.LoadedCommand = New RelayCommand(Sub()
			'										_mainmodel.GetPnPEntity()
			'									End Sub)
			'_mainmodel.GetPnPEntity()
		End Sub
#End Region

#Region " プロパティ "

		Public Property PnPEntityList() As ObservableCollection(Of PnPEntity)
			Get
				Return _PnPEntityList
			End Get
			Set(ByVal value As ObservableCollection(Of PnPEntity))
				_PnPEntityList = value
				OnPropertyChanged("PnPEntityList")
			End Set
		End Property
		Private _PnPEntityList As New ObservableCollection(Of PnPEntity)

#Region " コマンドプロパティ "
		''' <summary>
		''' 画面ロード時
		''' </summary>
		Public ReadOnly Property LoadedCommand() As ICommand
			Get
				If _LoadedCommand Is Nothing Then
					_LoadedCommand = New RelayCommand(AddressOf ExecuteLoaded)
				End If
				Return _LoadedCommand
			End Get
		End Property
		Private _LoadedCommand As ICommand
#End Region

#End Region

#Region " メソッド "
		Private Sub ExecuteLoaded()
			PnPEntityList = New ObservableCollection(Of PnPEntity)(_mainmodel.GetPnPEntity())
			'OnPropertyChanged("PnPEntityList")
		End Sub
#End Region

	End Class
End Namespace