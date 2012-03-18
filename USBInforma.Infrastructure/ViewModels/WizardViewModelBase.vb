Imports USBInforma.Infrastructure.Models

Namespace ViewModels
	Public Class WizardViewModelBase
		Inherits PropertyChangedBase

		Public Event RequestClose As EventHandler

		Protected Sub OnRequestClose()
			RaiseEvent RequestClose(Me, EventArgs.Empty)
		End Sub

	End Class
End Namespace