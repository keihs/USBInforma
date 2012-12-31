''====================================================================
''====================================================================
''====================================================================
''!
''! @file MainViewModel.vb
''! @brief $description: $
''! @author KeiH
''! @date   2012/03/19
''! @version $Revision: $
''! @overview 
''!
''! Copyright (C) 2012 KeiH.  All rights reserved.
''!
''====================================================================
''====================================================================
''====================================================================

Imports System.Collections.ObjectModel
Imports System.Reactive.Linq
Imports System.Threading.Tasks
Imports USBInforma.Infrastructure.Commands
Imports USBInforma.Infrastructure.ViewModels
Imports USBInforma.Models
Imports USBInforma.Views
Imports USBInforma.Infrastructure.Utils

Namespace ViewModels
	Public Class MainViewModel
		Inherits MainViewModelBase

#Region " フィールド "
		' メインモデル
		Private ReadOnly _mainmodel As MainModel

		Private _mainView As MainWindow

		Private ReadOnly _PnPEntityMethod As Func(Of List(Of PnPEntity)) = AddressOf GetPnPEntity
#End Region	' フィールド

#Region " コンストラクタ "
		Sub New(mainView As MainWindow)
			' TODO: Complete member initialization 
			_mainView = mainView
			_mainmodel = New MainModel
		End Sub
#End Region	' コンストラクタ

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

		Public Property SelectedPnPEntityListIndex() As Integer
			Get
				Return _SelectedPnPEntityListIndex
			End Get
			Set(ByVal value As Integer)
				_SelectedPnPEntityListIndex = value
				OnPropertyChanged("SelectedPnPEntityListIndex")
			End Set
		End Property
		Private _SelectedPnPEntityListIndex As Integer

		Public Property SelectedPnPEntityListItem() As PnPEntity
			Get
				Return _SelectedPnPEntityListItem
			End Get
			Set(ByVal value As PnPEntity)
				_SelectedPnPEntityListItem = value
				OnPropertyChanged("SelectedPnPEntityListItem")
			End Set
		End Property
		Private _SelectedPnPEntityListItem As PnPEntity

#Region " コマンドプロパティ "
		''' <summary>
		''' 画面ロード時コマンド
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

		''' <summary>
		''' コピーコマンド
		''' </summary>
		Public ReadOnly Property CopyCommand() As ICommand
			Get
				If _CopyCommand Is Nothing Then
					_CopyCommand = New RelayCommand(AddressOf ExecuteCopy, AddressOf CanExecuteCopy)
				End If
				Return _CopyCommand
			End Get
		End Property
		Private _CopyCommand As ICommand

		''' <summary>
		''' 更新コマンド
		''' </summary>
		Public ReadOnly Property RefreshCommand() As ICommand
			Get
				If _RefreshCommand Is Nothing Then
					_RefreshCommand = New RelayCommand(AddressOf ExecuteRefresh)
				End If
				Return _RefreshCommand
			End Get
		End Property
		Private _RefreshCommand As ICommand

#End Region	' コマンドプロパティ

#End Region	' プロパティ

#Region " メソッド "

		''' <summary>
		''' 画面ロード時
		''' </summary>
		Private Sub ExecuteLoaded()
			BeginPnPEntityMethod()
		End Sub

		''' <summary>
		''' PnPEntity非同期取得
		''' </summary>
		Private Sub BeginPnPEntityMethod()
			Observable.FromAsyncPattern(Of List(Of PnPEntity))(AddressOf _PnPEntityMethod.BeginInvoke, AddressOf _PnPEntityMethod.EndInvoke)().
			   Subscribe(Sub(PnPEntityItem)
							 PnPEntityList = New ObservableCollection(Of PnPEntity)(PnPEntityItem)
							 OnPropertyChanged("SelectedPnPEntityListItem")
						 End Sub)
		End Sub

		''' <summary>
		''' PnPEntity取得
		''' </summary>
		Private Function GetPnPEntity() As List(Of PnPEntity)
			Return _mainmodel.GetPnPEntity()
		End Function

		''' <summary>
		''' PnPEntityの各値を連結
		''' </summary>
		Private Function ConcatPnPEntity(pnpentity As PnPEntity) As String
			Return pnpentity.VendorID & pnpentity.ProductID & pnpentity.SerialNumber
		End Function

#Region " コマンドメソッド "

		''' <summary>
		''' コピー出来る状態かどうか
		''' </summary>
		Private Function CanExecuteCopy(ByVal parm As Object) As Boolean
			Dim PnPEntityitem = TryCast(parm, PnPEntity)
			Return Not IsNothing(PnPEntityitem)
		End Function

		''' <summary>
		''' クリップボードへコピー
		''' </summary>
		Private Sub ExecuteCopy(ByVal parm As Object)
			Dim PnPEntityitem = TryCast(parm, PnPEntity)
			Clipboard.SetText(ConcatPnPEntity(PnPEntityitem))
			MsgBox("コピーしました。", MsgBoxStyle.OkOnly)
		End Sub

		''' <summary>
		''' PnPEntityを再取得
		''' </summary>
		Private Sub ExecuteRefresh()
			BeginPnPEntityMethod()
		End Sub

#End Region	' コマンドメソッド

#End Region	' メソッド

	End Class
End Namespace