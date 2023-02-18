using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DataContext = this;
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
    }
}
