using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DevExpress.Web.ASPxPivotGrid;

namespace BindAndAddFields {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string connStr = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";
            string query = "SELECT TOP 30 e.LastName AS Employee, o.ShipCountry, " + 
                "o.ShipCity, o.Freight, o.OrderDate FROM Orders o " +
                "INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID " +
                "ORDER BY Freight DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connStr);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if(!IsPostBack && !IsCallback) {
                //ASPxPivotGrid1.DataSource = dataTable;
                //ASPxPivotGrid1.DataBind();

                //ASPxPivotGrid1.RetrieveFields();
                // create fields
                PivotGridField fieldEmployee = new PivotGridField();
                fieldEmployee.ID = "fieldEmployee";
                fieldEmployee.DataBinding = new DataSourceColumnBinding("Employee");
                fieldEmployee.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
                ASPxPivotGrid1.Fields.Add(fieldEmployee);

                PivotGridField fieldCountry = new PivotGridField();
                fieldCountry.ID = "fieldCountry";
                fieldCountry.DataBinding = new DataSourceColumnBinding("ShipCountry");
                fieldCountry.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                ASPxPivotGrid1.Fields.Add(fieldCountry);

                PivotGridField fieldCity = new PivotGridField();
                fieldCity.ID = "fieldCity";
                fieldCity.DataBinding = new DataSourceColumnBinding("ShipCity");
                fieldCity.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                ASPxPivotGrid1.Fields.Add(fieldCity);

                PivotGridField fieldFreight = new PivotGridField();
                fieldFreight.ID = "fieldFreight";
                fieldFreight.DataBinding = new DataSourceColumnBinding("Freight");
                fieldFreight.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                ASPxPivotGrid1.Fields.Add(fieldFreight);

                PivotGridField fieldOrderDate = new PivotGridField();
                fieldOrderDate.ID = "fieldOrderDate";
                fieldOrderDate.DataBinding = new DataSourceColumnBinding("OrderDate", DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth);
                fieldOrderDate.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                fieldOrderDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                fieldOrderDate.ValueFormat.FormatString = "MMM yyyy";
                ASPxPivotGrid1.Fields.Add(fieldOrderDate);
            }

            ASPxPivotGrid1.DataSource = dataTable;
            ASPxPivotGrid1.DataBind();
        }
    }
}
