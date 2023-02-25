using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmEducationalPortals.xaml
    /// </summary>
    public partial class PageAdmEducationalPortals : Page
    {
        private readonly EducationalPortalsService _educationalPortalsService = new EducationalPortalsService();
        List<EducationalPortals> _educationalPortals;
        public PageAdmEducationalPortals()
        {
            InitializeComponent();
            DataGridUpdater.AdmEducationalPortals = this;
            UpdateDataGrid();
            FilterComboBox.SetBoxDepartments(BoxDepartment);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedEducationalPortals();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditEducationalPortals(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedEducationalPortals();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _educationalPortals, BoxDepartment.Text, Name.Text, Description.Text, Link.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void DeleteSelectedEducationalPortals()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (EducationalPortals educationalPortal in dataGrid.SelectedItems)
                {
                    _educationalPortalsService.Delete(educationalPortal.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedEducationalPortals()
        {
            foreach (EducationalPortals educationalPortal in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditEducationalPortals(educationalPortal, this);
            }
        }
        public void UpdateDataGrid()
        {
            _educationalPortals = _educationalPortalsService.Get();
            DataGridUpdater.UpdateDataGrid(_educationalPortals, this);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception)
            {
                MessageBox.Show("Ресурс не найден");
            }
        }
    }
}
