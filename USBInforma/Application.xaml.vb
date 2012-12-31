''====================================================================
''====================================================================
''====================================================================
''!
''! @file Application.xaml.vb
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

Imports USBInforma.Infrastructure.Utils
Imports USBInforma.ViewModels
Imports USBInforma.Views

Class Application

	' Startup、Exit、DispatcherUnhandledException などのアプリケーション レベルのイベントは、
	' このファイルで処理できます。
	Public Const VERSION As String = "0.1"
	Public Const NAME As String = "USBInforma"

	Private Sub Application_Startup(sender As System.Object, e As System.Windows.StartupEventArgs)
		UIDispatcherHelper.UIDispatcher = Me.Dispatcher
		Dim mainView = New MainWindow()
		Dim mainWindowViewModel = New MainViewModel(mainView)
		mainView.DataContext = mainWindowViewModel
		mainView.Show()

	End Sub

	Private Sub Application_Exit(sender As System.Object, e As System.Windows.ExitEventArgs)

	End Sub

	Private Sub Application_SessionEnding(sender As System.Object, e As System.Windows.SessionEndingCancelEventArgs)

	End Sub

	Private Sub Application_DispatcherUnhandledException(sender As System.Object, e As System.Windows.Threading.DispatcherUnhandledExceptionEventArgs)

	End Sub

End Class
