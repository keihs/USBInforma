''====================================================================
''====================================================================
''====================================================================
''!
''! @file UIDispatcherHelper.vb
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

Imports System.Threading
Imports System.Windows.Threading

Namespace Utils
	Public NotInheritable Class UIDispatcherHelper
		Private Sub New()
		End Sub
		Public Shared Property UIDispatcher() As Dispatcher
			Get
				Return m_UIDispatcher
			End Get
			Set(ByVal value As Dispatcher)
				m_UIDispatcher = value
			End Set
		End Property
		Private Shared m_UIDispatcher As Dispatcher

		Public Shared Sub Invoke(ByVal action As Action)
			If IsNeedDispatcher() Then
				action()
				Return
			End If
			UIDispatcher.Invoke(DispatcherPriority.Normal, action)
		End Sub

		Public Shared Sub Invoke(Of T)(ByVal action As Action(Of T), ByVal arg As T)
			If IsNeedDispatcher() Then
				action(arg)
				Return
			End If
			UIDispatcher.Invoke(DispatcherPriority.Normal, action, arg)
		End Sub

		Public Shared Sub BeginInvoke(ByVal action As Action)
			If IsNeedDispatcher() Then
				action()
				Return
			End If
			UIDispatcher.BeginInvoke(DispatcherPriority.Normal, action)
		End Sub

		Public Shared Sub BeginInvoke(Of T)(ByVal action As Action(Of T), ByVal arg As T)
			If IsNeedDispatcher() Then
				action(arg)
				Return
			End If
			UIDispatcher.BeginInvoke(DispatcherPriority.Normal, action, arg)
		End Sub

		Private Shared Function IsNeedDispatcher() As Boolean
			Return UIDispatcher Is Nothing OrElse UIDispatcher.Thread Is Thread.CurrentThread
		End Function

	End Class
End Namespace