using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_OLAPSortByColumn {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
        private void pivotGridControl1_OlapDataLoaded(object sender, RoutedEventArgs e) {

            // Expands the Australia column to be able to retrieve OLAP members 
            // that correspond to the nested columns.
            pivotGridControl1.ExpandValueAsync(true, new object[] { "Australia" }, res => {

                // Obtains OLAP members corresponding to the Australia and Bendigo values.
                PivotOlapMember countryMember = 
                    pivotGridControl1.GetFieldValueOlapMember(fieldCountry, 0);
                PivotOlapMember cityMember = 
                    pivotGridControl1.GetFieldValueOlapMember(fieldCity, 0);

                // Exits if the OLAP members were not obtained successfully.
                if (countryMember == null || cityMember == null)
                    return;

                // Locks the pivot grid from updating while the Sort by Summary
                // settings are being customized.
                pivotGridControl1.BeginUpdate();
                try {

                    // Specifies a data field whose summary values should be used to sort values
                    // of the Month field.
                    fieldMonth.SortByField = fieldSales;

                    // Specifies a column by which the Month field values should be sorted.
                    fieldMonth.SortByConditions.Add(
                        new SortByCondition(fieldCountry, "Australia", countryMember.UniqueName));
                    fieldMonth.SortByConditions.Add(
                        new SortByCondition(fieldCity, "Bendigo", cityMember.UniqueName));
                }
                finally {

                    // Unlocks the pivot grid and applies changes.
                    pivotGridControl1.EndUpdateAsync();
                }
            });
        }
    }
}