Namespace Models
	Public Class RequestCloseBase

		Public Event RequestClose As EventHandler

		Protected Sub OnRequestClose()
			RaiseEvent RequestClose(Me, EventArgs.Empty)
		End Sub

	End Class
End Namespace