''====================================================================
''====================================================================
''====================================================================
''!
''! @file WizardViewModelBase.vb
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