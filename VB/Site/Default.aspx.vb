Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim columnVisibilityManager As New ColumnVisibilityManager(gvGrid)
		Form.Controls.AddAt(0, columnVisibilityManager)
	End Sub
	Protected Sub OnCustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		If e.Parameters.IndexOf(ColumnVisibilityManager.CvmCallbackPrefix) = 0 Then
			ColumnVisibilityManager.ProcessCallback(TryCast(sender, ASPxGridView), e.Parameters)
		Else
			Throw New InvalidOperationException("Invalid callback parameters.")
		End If
	End Sub
End Class
