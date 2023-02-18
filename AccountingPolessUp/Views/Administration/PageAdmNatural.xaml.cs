using AccountingPolessUp.Helpers;
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
    /// Логика взаимодействия для PageAdmNatural.xaml
    /// </summary>
    public partial class PageAdmNatural : Page
    {
        private readonly IndividualsService _individualsService = new IndividualsService();
        List<Individuals> _individuals;
        public PageAdmNatural()
        {
            InitializeComponent();
            DataGridUpdater.AdmNatural = this;
            UpdateDataGrid();
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmNatural(List<Individuals> individuals)
        {
            InitializeComponent();
            DataGridUpdater.AdmNatural = this;
            ColumSelect.Visibility = Visibility.Visible;
            _individuals = individuals;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
            DataGridUpdater.UpdateDataGrid(_individuals, this);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedIndividuals();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedIndividuals();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditIndividuals(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
            ButtonCancel.Visibility = Visibility.Hidden;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedIndividuals();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _individuals, FIO.Text, Phone.Text, DateOfBirth.Text, Mail.Text, BoxGender.Text, SocialNetwork.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void DeleteSelectedIndividuals()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var item in dataGrid.SelectedItems)
                {
                    Individuals individual = item as Individuals;
                    _individualsService.Delete(individual.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedIndividuals()
        {
            foreach (var item in dataGrid.SelectedItems)
            {
                Individuals individual = item as Individuals;
                DataNavigator.UpdateValueComboBox(_individuals.FirstOrDefault(x => x.Id == individual.Id));
            }
            this.NavigationService.GoBack();
        }
        private void EditSelectedIndividuals()
        {
            foreach (var item in dataGrid.SelectedItems)
            {
                Individuals individual = item as Individuals;
                if (individual != null)
                {
                    EditFrame.Content = new PageEditIndividuals(individual, this);
                }
            }
        }
        public void UpdateDataGrid()
        {
            _individuals = _individualsService.Get();
            DataGridUpdater.UpdateDataGrid(_individuals, this);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception)
            {

            }
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
