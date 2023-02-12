using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataGridUpdater
    {
   
        public static void UpdateDataGrid(object data, Page page)
        {
            var dataGrid = page.FindName("dataGrid") as DataGrid;
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = (System.Collections.IEnumerable)data;
        }

    }
}
