<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128577294/21.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E421)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Pivot Grid for Web Forms - How to create fields and assign a data source at runtime

This example demonstrates how to create and configure [ASPxPivotGrid](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.ASPxPivotGrid) fields programmatically. 

Create a [PivotGridField](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.PivotGridField) instance. Then, set its [DataBinding](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotGridFieldBase.DataBinding) property to an instance of the [DataSourceColumnBinding](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.DataSourceColumnBinding) class to specify a PivotGrid’s field data binding to a data source column.
```cs
//...
PivotGridField fieldEmployee = new PivotGridField();
fieldEmployee.ID = "fieldEmployee";
fieldEmployee.DataBinding = new DataSourceColumnBinding("Employee");
fieldEmployee.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
ASPxPivotGrid1.Fields.Add(fieldEmployee);
```

## Files to Look At

- [Default.aspx](./CS/BindAndAddFields/Default.aspx) (VB: [Default.aspx](./VB/BindAndAddFields/Default.aspx))
- [Default.aspx.cs](./CS/BindAndAddFields/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/BindAndAddFields/Default.aspx.vb))

## Documentation

- [Fields](https://docs.devexpress.com/AspNet/7259/components/pivot-grid/binding-to-data/unbound-fieldshttps://docs.devexpress.com/AspNet/9464/components/pivot-grid/fundamentals/fields)
- [Binding to Data Overview](https://docs.devexpress.com/AspNet/7250/components/pivot-grid/binding-to-data)



