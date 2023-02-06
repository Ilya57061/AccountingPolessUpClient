using AccountingPolessUp.Helpers;
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
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmWork.xaml
    /// </summary>
    public partial class PageAdmWork : Page
    {
        EmploymentService _employmentService = new EmploymentService();
        public PageAdmWork()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_employmentService.Get(),this);
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _employmentService.Get(),DateStart.Text,DateEnd.Text,BoxPosition.Text,BoxStatus.Text, StatusDescription.Text,BoxMentors.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            DataGridUpdater.UpdateDataGrid(_employmentService.Get(), this);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Employment employment = dataGrid.SelectedItems[i] as Employment;
                    if (employment != null)
                    {
                        _employmentService.Delete(employment.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_employmentService.Get(),this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditWork(this);
        }
        private void ButtonFinalProject_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Employment employment = dataGrid.SelectedItems[i] as Employment;
                if (employment != null)
                {
                    this.NavigationService.Content = new PageAdmFinalProject(employment);
                }
            }

        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Employment employment = dataGrid.SelectedItems[i] as Employment;
                if (employment != null)
                {
                    EditFrame.Content = new PageEditWork(employment,this);

                }
            }
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
