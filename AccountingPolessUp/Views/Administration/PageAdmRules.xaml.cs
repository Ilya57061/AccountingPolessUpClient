﻿using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmRules.xaml
    /// </summary>
    public partial class PageAdmRules : Page
    {
        RegulationService _regulationService = new RegulationService();
        public PageAdmRules()
        {
            InitializeComponent();
            DataGridUpdater.Page = this;
            DataGridUpdater.UpdateDataGrid(_regulationService.Get());
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Regulation regulation = dataGrid.SelectedItems[i] as Regulation;
                    if (regulation != null)
                    {

                 _regulationService.Delete(regulation.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_regulationService.Get());
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditRules();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Regulation regulation = dataGrid.SelectedItems[i] as Regulation;
                if (regulation != null)
                {
                    EditFrame.Content = new PageEditRules(regulation);

                }
            }
        }
    }
}
