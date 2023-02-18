using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AccountingPolessUp.Helpers
{
    public static class DataNavigator
    {
        public static Page ChangePage { get; set; }
        public static string NameBox { get; set; }
        public static void UpdateValueComboBox(object obj)
        {
            ComboBox comboBox = ChangePage.FindName(NameBox) as ComboBox;
            comboBox.SelectedItem = obj;
        }
        public static void LineLeft(ScrollViewer scroll)
        {
            scroll.LineLeft();
        }
        public static void LineRight(ScrollViewer scroll)
        {
            scroll.LineRight();
        }
    }
}
