Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxPivotGrid

Namespace BindAndAddFields

    Public Partial Class _Default
        Inherits Page

        Private ds As SqlDataSource

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ds = New SqlDataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\nwind.mdb", "SELECT TOP 30 e.LastName AS Employee, o.ShipCountry, " & "o.ShipCity, o.Freight, o.OrderDate FROM Orders o " & "INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID " & "ORDER BY Freight DESC")
            If Not IsPostBack AndAlso Not IsCallback Then
                'ASPxPivotGrid1.DataSource = dataTable;
                'ASPxPivotGrid1.DataBind();
                'ASPxPivotGrid1.RetrieveFields();
                ' create fields
                Dim fieldEmployee As PivotGridField = New PivotGridField()
                fieldEmployee.ID = "fieldEmployee"
                fieldEmployee.DataBinding = New DataSourceColumnBinding("Employee")
                fieldEmployee.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
                ASPxPivotGrid1.Fields.Add(fieldEmployee)
                Dim fieldCountry As PivotGridField = New PivotGridField()
                fieldCountry.ID = "fieldCountry"
                fieldCountry.DataBinding = New DataSourceColumnBinding("ShipCountry")
                fieldCountry.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                ASPxPivotGrid1.Fields.Add(fieldCountry)
                Dim fieldCity As PivotGridField = New PivotGridField()
                fieldCity.ID = "fieldCity"
                fieldCity.DataBinding = New DataSourceColumnBinding("ShipCity")
                fieldCity.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                ASPxPivotGrid1.Fields.Add(fieldCity)
                Dim fieldFreight As PivotGridField = New PivotGridField()
                fieldFreight.ID = "fieldFreight"
                fieldFreight.DataBinding = New DataSourceColumnBinding("Freight")
                fieldFreight.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
                ASPxPivotGrid1.Fields.Add(fieldFreight)
                Dim fieldOrderDate As PivotGridField = New PivotGridField()
                fieldOrderDate.ID = "fieldOrderDate"
                fieldOrderDate.DataBinding = New DataSourceColumnBinding("OrderDate", DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth)
                fieldOrderDate.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
                fieldOrderDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                fieldOrderDate.ValueFormat.FormatString = "MMM yyyy"
                ASPxPivotGrid1.Fields.Add(fieldOrderDate)
            End If

            ASPxPivotGrid1.DataSource = ds
            ASPxPivotGrid1.DataBind()
        End Sub
    End Class
End Namespace
