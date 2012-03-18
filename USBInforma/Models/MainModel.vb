﻿Imports System.Management
Imports System.IO

Namespace Models
	Public Class MainModel
		ReadOnly _path2 As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CIMV2" & "_Exception.log")

		Sub New()
		End Sub

		Public Function GetPnPEntity() As List(Of PnPEntity)
			Dim pnpEntityList As New List(Of PnPEntity)
			Dim pnpDeviceIDList As New List(Of PnPEntity)
			Try
				Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
				Dim queryObjs = From queryObj In searcher.Get() Where queryObj("Caption") Like "*:\" Select queryObj
				Dim serialNumber As String()

				For Each queryObj In queryObjs
					serialNumber = Split(queryObj("PNPDeviceID"), "\")
					serialNumber = Split(serialNumber(UBound(serialNumber)), "&")
					serialNumber = Split(serialNumber(UBound(serialNumber) - 1), "#")
					pnpEntityList.Add(New PnPEntity() With {
					.Caption = queryObj("Caption"),
					.PNPDeviceID = queryObj("PNPDeviceID"),
					.SerialNumber = serialNumber(UBound(serialNumber))
					  })
					Console.WriteLine("Caption: {0}", queryObj("Caption"))
					Console.WriteLine("PNPDeviceID: {0}", queryObj("PNPDeviceID"))
					Console.WriteLine("SerialNumber: {0}", serialNumber(UBound(serialNumber)))
					Console.WriteLine()
				Next

				queryObjs = From queryObj In searcher.Get() Where queryObj("Caption") Like "*USB 大容量記憶装置*" Select queryObj
				serialNumber = Nothing
				Dim vendorID As String()
				Dim productID As String()

				For Each queryObj In queryObjs
					serialNumber = Split(queryObj("PNPDeviceID"), "\")
					vendorID = Split(serialNumber(UBound(serialNumber) - 1), "&")
					vendorID = Split(vendorID(UBound(vendorID) - 1), "VID_")
					productID = Split(serialNumber(UBound(serialNumber) - 1), "&")
					productID = Split(productID(UBound(productID)), "PID_")
					pnpDeviceIDList.Add(New PnPEntity() With {
					 .SerialNumber = serialNumber(UBound(serialNumber)),
					 .VendorID = vendorID(UBound(vendorID)),
					 .ProductID = productID(UBound(productID))
					   })
					Console.WriteLine("VendorID: {0}", vendorID(UBound(vendorID)))
					Console.WriteLine("ProductID: {0}", productID(UBound(productID)))
					Console.WriteLine("SerialNumber: {0}", serialNumber(UBound(serialNumber)))
					Console.WriteLine()
				Next


				Return pnpEntityList
			Catch ex As ManagementException
				MessageBox.Show("An error occurred while querying for WMI data: " & ex.Message)
				Using writer As New StreamWriter(_path2, True)

					writer.WriteLine("Message:")
					writer.WriteLine(ex.Message)
					writer.WriteLine()
					writer.WriteLine("StackTrace:")
					writer.WriteLine(ex.StackTrace)
				End Using
				Return Nothing
			End Try
		End Function

	End Class
End Namespace