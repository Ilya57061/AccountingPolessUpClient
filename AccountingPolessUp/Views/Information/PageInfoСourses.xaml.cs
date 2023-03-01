using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoСourses.xaml
    /// </summary>
    public partial class PageInfoСourses : Page
    {
        TrainingCoursesService _trainingCoursesService = new TrainingCoursesService();
        public ObservableCollection<TrainingCourses> Courses { get; set; }
        public PageInfoСourses()
        {
            InitializeComponent();
            Courses = new ObservableCollection<TrainingCourses>(_trainingCoursesService.Get());
            DataContext = Courses;
        }
        private void HyperlinkCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hyperlink hyperlink = sender as Hyperlink;
                Run run = hyperlink.Inlines.FirstInline as Run;
                string text = run.Text;
                Process.Start(text);
            }
            catch (Exception)
            {
                Hyperlink hyperlink = sender as Hyperlink;
                hyperlink.IsEnabled = false;
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(this, Courses, Name.Text, Description.Text, DateStart.Text, DateEnd.Text, LectorFio.Text, LectorDescription.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(filter);
            DataContext = Courses;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
