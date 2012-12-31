''====================================================================
''====================================================================
''====================================================================
''!
''! @file ViewModelBase.vb
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

Imports System.ComponentModel
Imports System.Windows.Input

Namespace ViewModels
	Public MustInherit Class ViewModelBase
		Implements INotifyPropertyChanged
		Implements IDataErrorInfo

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub

		Default Protected Overridable ReadOnly Property Item(ByVal propertyName As String) As String Implements IDataErrorInfo.Item
			Get
				Try
					Return GetValidationError(propertyName)
				Finally
					CommandManager.InvalidateRequerySuggested()
				End Try
			End Get
		End Property

		Protected Overridable ReadOnly Property [Error]() As String Implements IDataErrorInfo.[Error]
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		Protected Overridable Function GetValidationError(ByVal propertyName As String) As String
			Return Nothing
		End Function

		Public Event RequestClose As EventHandler

		Protected Sub OnRequestClose()
			RaiseEvent RequestClose(Me, EventArgs.Empty)
		End Sub

		Public MustOverride Function IsValid() As Boolean

	End Class
End Namespace