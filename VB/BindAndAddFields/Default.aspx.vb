Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxPivotGrid

Namespace BindAndAddFields
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim connStr As String = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true"
			Dim query As String = "SELECT TOP 30 e.LastName AS Employee, o.ShipCountry, o.ShipCity, " & _
				"o.Freight, o.OrderDate FROM Orders o " & _
				"INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID " & _
				"ORDER BY Freight DESC"
			Dim adapter As New SqlDataAdapter(query, connStr)
			Dim dataTable As New DataTable()
			adapter.Fill(dataTable)

			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				' create fields
				Dim fieldEmployee As New PivotGridField()
				fieldEmployee.ID = "fieldEmployee"
                fieldEmployee.DataBinding = New DataSourceColumnBinding("Employee")
                fieldEmployee.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
				ASPxPivotGrid1.Fields.Add(fieldEmployee)

				Dim fieldCountry As New PivotGridField()
				fieldCountry.ID = "fieldCountry"
                fieldCountry.DataBinding = New DataSourceColumnBinding("ShipCountry")
                fieldCountry.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
				ASPxPivotGrid1.Fields.Add(fieldCountry)

				Dim fieldCity As New PivotGridField()
				fieldCity.ID = "fieldCity"
                fieldCity.DataBinding = New DataSourceColumnBinding("ShipCity")
                fieldCity.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
				ASPxPivotGrid1.Fields.Add(fieldCity)

				Dim fieldFreight As New PivotGridField()
				fieldFreight.ID = "fieldFreight"
                fieldFreight.DataBinding = New DataSourceColumnBinding("Freight")
                fieldFreight.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
				ASPxPivotGrid1.Fields.Add(fieldFreight)

				Dim fieldOrderDate As New PivotGridField()
				fieldOrderDate.ID = "fieldOrderDate"
                fieldOrderDate.DataBinding = New DataSourceColumnBinding("OrderDate", DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth)
                fieldOrderDate.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
				fieldOrderDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
				fieldOrderDate.ValueFormat.FormatString = "MMM yyyy"
                ASPxPivotGrid1.Fields.Add(fieldOrderDate)
            End If

			ASPxPivotGrid1.DataSource = dataTable
			ASPxPivotGrid1.DataBind()
		End Sub
	End Class
End Namespace
