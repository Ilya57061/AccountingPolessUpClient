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
    /// Логика взаимодействия для PageAdmVacancy.xaml
    /// </summary>
    public partial class PageAdmVacancy : Page
    {
        private readonly VacancyService _vacancyService = new VacancyService();
        List<Vacancy> _vacancies;
        public PageAdmVacancy()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        public PageAdmVacancy(List<Vacancy> vacancies)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _vacancies = vacancies;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedVacancies();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedVacancies();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditVacancy(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedVacancies();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _vacancyService.Get(),Name.Text, Descriptions.Text, Responsibilities.Text, DateStart.Text, DateEnd.Text, StagesOfProject.Text,IsOpened.Text, PaymentRatio.Text, RatingCoefficient.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void Number_PreviewTextDoubleInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DoubleValidator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_vacancyService.Get(), this);
        }
        private void DeleteSelectedVacancies()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Vacancy vacancy in dataGrid.SelectedItems)
                {
                    _vacancyService.Delete(vacancy.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedVacancies()
        {
            foreach (Vacancy vacancy in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_vacancies.FirstOrDefault(x => x.Id == vacancy.Id));
            }

            this.NavigationService.GoBack();
        }
        private void EditSelectedVacancies()
        {
            foreach (Vacancy vacancy in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditVacancy(vacancy, this);
                break;
            }
        }
    }
}
