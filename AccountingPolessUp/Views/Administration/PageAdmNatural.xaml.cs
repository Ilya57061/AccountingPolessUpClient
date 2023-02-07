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
    /// Логика взаимодействия для PageAdmNatural.xaml
    /// </summary>
    public partial class PageAdmNatural : Page
    {
        private readonly IndividualsService _individualsService = new IndividualsService();
        List<Individuals> _individuals;
        public PageAdmNatural()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        public PageAdmNatural(List<Individuals> individuals)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _individuals = individuals;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
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
            FilterManager.ConfirmFilter(dataGrid, _individualsService.Get(), FIO.Text, Phone.Text, DateOfBirth.Text, Mail.Text, BoxGender.Text, SocialNetwork.Text);
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
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_individualsService.Get(), this);
        }
    }
}
