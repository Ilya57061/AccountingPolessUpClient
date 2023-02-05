﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
   public static class DataNavigator
    {
        public static Page ChangePage { get; set; }
        public static string NameBox { get; set; }
        public static void UpdateValueComboBox(object obj)
        {
            var comboBox = ChangePage.FindName(NameBox) as ComboBox;
            comboBox.SelectedItem = obj;

        }
   
    }
}