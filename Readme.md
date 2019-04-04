<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_OLAPSortByColumn/MainPage.xaml) (VB: [MainPage.xaml](./VB/DXPivotGrid_OLAPSortByColumn/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DXPivotGrid_OLAPSortByColumn/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_OLAPSortByColumn/MainPage.xaml.vb))
<!-- default file list end -->
# How to implement Sorting by Summary in OLAP mode


<p>The following example demonstrates how to implement Sorting by Summary in OLAP mode.</p><p>In this example, values of the Semester field are sorted by the Australia | Bendigo column summary values. To do this, two sort conditions represented by SortByCondition instances are created. One of them represents an OLAP member that corresponds to the 'Australia' value, while another corresponds to the 'Bendigo' value. These sort conditions are added to the Semester field's PivotGridField.SortByConditions collection to specify the column by which Semester values should be sorted. A data field that identifies the column is specified via the PivotGridField.SortByField property.</p><p>OLAP members corresponding to the Australia and Bendigo values are obtained using the PivotGridControl.GetFieldValueOlapMember method. Note that OLAP members can be obtained only for visible field values. For this reason, the Australia field value is expanded before initializing OLAP members in order to obtain the Bendigo OLAP member.</p><p>This sample uses the Adventure Works 2008 cube.<br />
</p><br />


<br/>


