Imports System.ComponentModel

Namespace Models
	Public Class PropertyChangedBase
		Implements INotifyPropertyChanged

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub

	End Class
End Namespace