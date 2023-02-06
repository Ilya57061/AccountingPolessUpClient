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
    /// Логика взаимодействия для PageAdmCourses.xaml
    /// </summary>
    public partial class PageAdmCourses : Page
    {
        TrainingCoursesService _coursesService = new TrainingCoursesService();
        List<TrainingCourses> _trainingCourses;
        public PageAdmCourses()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_coursesService.Get(), this);
        }
        public PageAdmCourses(List<TrainingCourses> trainingCourses)
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_coursesService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            _trainingCourses = trainingCourses;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                TrainingCourses courses = dataGrid.SelectedItems[i] as TrainingCourses;
                DataNavigator.UpdateValueComboBox(_trainingCourses.FirstOrDefault(x => x.Id == courses.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    TrainingCourses TrainingCourses = dataGrid.SelectedItems[i] as TrainingCourses;
                    if (TrainingCourses != null)
                    {

                        _coursesService.Delete(TrainingCourses.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_coursesService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditCourses(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                TrainingCourses TrainingCourses = dataGrid.SelectedItems[i] as TrainingCourses;
                if (TrainingCourses != null)
                {
                    EditFrame.Content = new PageEditCourses(TrainingCourses, this);

                }
            }
        }
    }
}
