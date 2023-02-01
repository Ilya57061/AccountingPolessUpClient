using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Interaction logic for PageEditScheduleOfClasses.xaml
    /// </summary>
    public partial class PageEditScheduleOfClasses : Page
    {

        
        ScheduleOfClassesService _scheduleService = new ScheduleOfClassesService();
        TrainingCoursesService _trainingCoursesService = new TrainingCoursesService();
        List<TrainingCourses> _trainingCourses;
        ScheduleOfСlasses _schedule;
        public PageEditScheduleOfClasses(ScheduleOfСlasses schedule)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _trainingCourses = _trainingCoursesService.Get();
            DataContext = schedule;
            _schedule = schedule;
            BoxTrainingCourses.ItemsSource = _trainingCourses;
            BoxTrainingCourses.SelectedIndex = _trainingCourses.IndexOf(_trainingCourses.FirstOrDefault(r => r.Id == schedule.TrainingCoursesId));
        }
        public PageEditScheduleOfClasses()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _schedule = new ScheduleOfСlasses();
            _trainingCourses = _trainingCoursesService.Get();
            BoxTrainingCourses.ItemsSource = _trainingCourses;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _scheduleService.Update(_schedule);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _scheduleService.Create(_schedule);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void WriteData()
        {
            _schedule.Description = Description.Text;
            _schedule.DateStart = DateTime.Parse(DateStart.Text);
            _schedule.DateEnd = DateTime.Parse(DateEnd.Text);
            _schedule.WorkSpaceLink = WorkSpaceLink.Text;
            _schedule.TrainingCoursesId = _trainingCourses.FirstOrDefault(i => i == BoxTrainingCourses.SelectedItem).Id;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
