Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_OLAPSortByColumn
    Partial Public Class MainPage
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub pivotGridControl1_OlapDataLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Expands the Australia column to be able to retrieve OLAP members 
            ' that correspond to the nested columns.
            pivotGridControl1.ExpandValueAsync(True, New Object() {"Australia"}, _
                                               Sub(res) SetSortByColumn(res))
        End Sub

        Private Sub SetSortByColumn(ByVal res As Object)

            ' Obtains OLAP members corresponding to the Australia and Bendigo values.
            Dim countryMember As PivotOlapMember = _
                pivotGridControl1.GetFieldValueOlapMember(fieldCountry, 0)
            Dim cityMember As PivotOlapMember = _
                pivotGridControl1.GetFieldValueOlapMember(fieldCity, 0)

            ' Exits if the OLAP members were not obtained successfully.
            If countryMember Is Nothing OrElse cityMember Is Nothing Then
                Return
            End If

            ' Locks the pivot grid from updating while the Sort by Summary
            ' settings are being customized.
            pivotGridControl1.BeginUpdate()
            Try
                ' Specifies a data field whose summary values should be used to sort values
                ' of the Month field.
                fieldMonth.SortByField = fieldSales

                ' Specifies a column by which the Month field values should be sorted.
                fieldMonth.SortByConditions.Add( _
                    New SortByCondition(fieldCountry, "Australia", countryMember.UniqueName))
                fieldMonth.SortByConditions.Add( _
                    New SortByCondition(fieldCity, "Bendigo", cityMember.UniqueName))
            Finally

                ' Unlocks the pivot grid and applies changes.
                pivotGridControl1.EndUpdateAsync()
            End Try
        End Sub
    End Class
End Namespace