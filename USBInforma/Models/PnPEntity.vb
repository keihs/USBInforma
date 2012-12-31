''====================================================================
''====================================================================
''====================================================================
''!
''! @file PnPEntity.vb
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

Namespace Models
	Public Class PnPEntity

		Public Property Caption() As String
		Public Property Description() As String
		Public Property PNPDeviceID() As String
		Public Property SerialNumber() As String
		Public Property VendorID() As String
		Public Property ProductID() As String

		Public Sub New()
		End Sub

	End Class
End Namespace