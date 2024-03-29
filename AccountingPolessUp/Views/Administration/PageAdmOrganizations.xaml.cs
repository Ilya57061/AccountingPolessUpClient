﻿using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmOrganizations.xaml
    /// </summary>
    public partial class PageAdmOrganizations : Page
    {
        private readonly OrganizationService _organizationService = new OrganizationService();

        List<Organization> _organizations;

        public PageAdmOrganizations()
        {
            InitializeComponent();
            UpdateDataGrid();

            DataGridUpdater.AdmOrganizations = this;   
        }
        public PageAdmOrganizations(List<Organization> organizations)
        {
            InitializeComponent();

            DataGridUpdater.UpdateDataGrid(_organizations, this);
            DataGridUpdater.AdmOrganizations = this;

            _organizations = organizations;

            ColumSelect.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedOrganizations();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedOrganizations();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditOrganization(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedOrganizations();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _organizations, FullName.Text, Address.Text, Contacts.Text, Website.Text, FoundationDate.Text, BSR.Text.Replace('.', ','));
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            _organizations = _organizationService.Get();
            DataGridUpdater.UpdateDataGrid(_organizations, this);
        }
        private void DeleteSelectedOrganizations()
        {
            var messageBoxResult = MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo);

            if (dataGrid.SelectedItems.Count > 0 &&  messageBoxResult == MessageBoxResult.Yes)
            {
                foreach (Organization organization in dataGrid.SelectedItems)
                {
                    _organizationService.Delete(organization.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedOrganizations()
        {
            foreach (Organization organization in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_organizations.FirstOrDefault(x => x.Id == organization.Id));
            }

            NavigationService.GoBack();
        }
        private void EditSelectedOrganizations()
        {
            foreach (Organization organization in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditOrganization(organization, this);
                break;
            }
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
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        private void Number_PreviewTextDoubleInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DoubleValidator(e);
        }
    }
}
