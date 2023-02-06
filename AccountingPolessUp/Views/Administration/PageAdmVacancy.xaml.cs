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
        VacancyService _vacancyService = new VacancyService();
        List<Vacancy> _vacancies;
        public PageAdmVacancy()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_vacancyService.Get(),this);
        }
        public PageAdmVacancy(List<Vacancy> vacancies)
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_vacancyService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            _vacancies = vacancies;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ConfirmFilter(dataGrid, _finalProjectService.Get().Where(x => x.EmploymentId == _employment.Id), TextBoxName.Text,
            //    TextBoxDescription.Text, TextBoxGitHub.Text, TextBoxLink.Text, DateStart.Text, DateEnd.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Vacancy vacancy = dataGrid.SelectedItems[i] as Vacancy;
                DataNavigator.UpdateValueComboBox(_vacancies.FirstOrDefault(x => x.Id == vacancy.Id));
            }

            this.NavigationService.GoBack();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Vacancy vacancy = dataGrid.SelectedItems[i] as Vacancy;
                    if (vacancy != null)
                    {

                        _vacancyService.Delete(vacancy.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_vacancyService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditVacancy(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Vacancy vacancy = dataGrid.SelectedItems[i] as Vacancy;
                if (vacancy != null)
                {
                    EditFrame.Content = new PageEditVacancy(vacancy, this);

                }
            }
        }
    }
}
