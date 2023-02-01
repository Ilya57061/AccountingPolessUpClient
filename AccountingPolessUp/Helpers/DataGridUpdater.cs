﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataGridUpdater
    {
        public static void UpdateDataGrid(Page page, object data)
        {
            var dataGrid = page.FindName("dataGrid") as DataGrid;
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = (System.Collections.IEnumerable)data;
        }
    }
}