using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для PageAdmCourses.xaml
    /// </summary>
    public partial class PageAdmCourses : Page
    {
        private readonly TrainingCoursesService _coursesService = new TrainingCoursesService();
        List<TrainingCourses> _trainingCourses;
        public PageAdmCourses()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        public PageAdmCourses(List<TrainingCourses> trainingCourses)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _trainingCourses = trainingCourses;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            foreach (TrainingCourses courses in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_trainingCourses.FirstOrDefault(x => x.Id == courses.Id));
            }
            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedCourses();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditCourses(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedCourses();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _coursesService.Get(), Name.Text, Description.Text, Link.Text, LectorFio.Text, LectorDescription.Text, DateStart.Text, DateEnd.Text, IsActive.Text);
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
        private void DeleteSelectedCourses()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (TrainingCourses TrainingCourses in dataGrid.SelectedItems)
                {
                    _coursesService.Delete(TrainingCourses.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedCourses()
        {
            foreach (TrainingCourses TrainingCourses in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditCourses(TrainingCourses, this);
                break;
            }
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_coursesService.Get(), this);
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
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
        private void ButtonSchedule_Click(object sender, RoutedEventArgs e)
        {
            OpenSchedule();
        }
        private void OpenSchedule()
        {
            foreach (TrainingCourses trainingCourses in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmScheduleOfClasses(trainingCourses);
            }
        }
    }
}
