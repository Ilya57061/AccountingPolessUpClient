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
            _individuals = _individualsService.Get();
            UpdateDataGrid();
        }
        public PageAdmNatural(List<Individuals> individuals)
        {
            InitializeComponent();
            ColumSelect.Visibility = Visibility.Visible;
            _individuals = individuals;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
            UpdateDataGrid();

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
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedIndividuals();
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
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
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
