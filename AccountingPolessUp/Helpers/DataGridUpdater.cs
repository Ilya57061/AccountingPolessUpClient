using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataGridUpdater
    {
        public static Page Page { get; set; }
        public static void UpdateDataGrid(object data)
        {
            var dataGrid = Page.FindName("dataGrid") as DataGrid;
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = (System.Collections.IEnumerable)data;
        }
    }
}
