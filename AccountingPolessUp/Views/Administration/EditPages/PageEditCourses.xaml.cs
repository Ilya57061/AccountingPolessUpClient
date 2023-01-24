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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditCourses.xaml
    /// </summary>
    public partial class PageEditCourses : Page
    {
        TrainingCoursesService _coursesService = new TrainingCoursesService();
        TrainingCourses _cours;
        public PageEditCourses(TrainingCourses cours)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _cours = cours;
            DataContext = cours;
        }
        public PageEditCourses()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _cours = new TrainingCourses(); 
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _coursesService.Update(_cours);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _coursesService.Create(_cours);
        }
        private void WriteData()
        {
            _cours.Name = Name.Text;
            _cours.Description = Description.Text;
            _cours.Link= Link.Text;
        }
    }
}
