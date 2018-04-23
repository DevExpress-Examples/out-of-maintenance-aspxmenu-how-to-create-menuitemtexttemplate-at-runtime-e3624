Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Imports DevExpress.Web.ASPxEditors
Imports System.Web.UI
Imports System.Drawing


Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub ASPxMenu2_ItemDataBound(ByVal source As Object, ByVal e As DevExpress.Web.ASPxMenu.MenuItemEventArgs)
		Dim node As SiteMapNode = TryCast(e.Item.DataItem, SiteMapNode)
		If node IsNot Nothing Then
			e.Item.TextTemplate = New MenuItemTemplate(node)
		End If
	End Sub

	Private Class MenuItemTemplate
		Implements ITemplate
		Private node As SiteMapNode

		Public Sub New(ByVal node As SiteMapNode)
			Me.node = node
		End Sub

		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim lb As New ASPxLabel()
			lb.Text = node.Title
			container.Controls.Add(lb)

			If node("description") Is Nothing Then
				Return
			End If

			Dim dynBR As New System.Web.UI.HtmlControls.HtmlGenericControl("BR")
			container.Controls.Add(dynBR)

			Dim link As New ASPxHyperLink()
			link.NavigateUrl = node.Url
			link.Text = node("description")
			link.ForeColor = Color.Blue
			container.Controls.Add(link)


		End Sub
	End Class
End Class
