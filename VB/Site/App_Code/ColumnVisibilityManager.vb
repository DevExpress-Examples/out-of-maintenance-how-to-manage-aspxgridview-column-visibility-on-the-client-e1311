Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Public Class ColumnVisibilityManager
	Inherits WebControl
	Public Const CvmCallbackPrefix As String = "cvm!"
	Private gridView_Renamed As ASPxGridView

	Public Sub New(ByVal gridView As ASPxGridView)
		Me.gridView_Renamed = gridView
	End Sub

	Private ReadOnly Property GridView() As ASPxGridView
		Get
			Return gridView_Renamed
		End Get
	End Property

	Public Shared Sub ProcessCallback(ByVal gridView As ASPxGridView, ByVal callbackParam As String)
		callbackParam = callbackParam.Substring(CvmCallbackPrefix.Length)
		Dim indexOfSeparator As Integer = callbackParam.IndexOf("|"c)
		Dim isColumnVisible As Boolean = Byte.Parse(callbackParam.Substring(0, indexOfSeparator)) > 0
		Dim columnName As String = callbackParam.Substring(indexOfSeparator + 1)
		gridView.Columns(columnName).Visible = isColumnVisible
	End Sub

	Protected Overrides Sub CreateChildControls()
		Dim table As New Table()
		Controls.Add(table)
		For Each column As GridViewColumn In GridView.Columns
			Dim row As New TableRow()
			table.Rows.Add(row)
			Dim cell As New TableCell()
			row.Cells.Add(cell)
			CreateColumnVisibilitySwitch(cell, column)
		Next column
	End Sub
	Private Sub CreateColumnVisibilitySwitch(ByVal container As WebControl, ByVal column As GridViewColumn)
		Dim checkBox As New ASPxCheckBox()
		container.Controls.Add(checkBox)
		checkBox.Text = GetColumnCaption(column)
		checkBox.Checked = column.Visible
		checkBox.ClientSideEvents.CheckedChanged = CreateCheckedChangedEventHandler(column)
	End Sub

	' Utils
	Private Function CreateCheckedChangedEventHandler(ByVal column As GridViewColumn) As String
		Return String.Format("function(s, e) {{ Cvm_OnCheckedChanged('{0}', '{1}', s); }}", GridView.ClientID, GetColumnName(column))
	End Function
	Private Function GetColumnName(ByVal column As GridViewColumn) As String
		If (Not String.IsNullOrEmpty(column.Name)) Then
			Return column.Name
		Else
			Dim dataColumn As GridViewDataColumn = TryCast(column, GridViewDataColumn)
			If dataColumn IsNot Nothing Then
				Return dataColumn.FieldName
			End If
		End If
		Return String.Empty
	End Function
	Private Function GetColumnCaption(ByVal column As GridViewColumn) As String
		If (Not String.IsNullOrEmpty(column.Caption)) Then
			Return column.Caption
		Else
			Return GetColumnName(column)
		End If
	End Function
End Class