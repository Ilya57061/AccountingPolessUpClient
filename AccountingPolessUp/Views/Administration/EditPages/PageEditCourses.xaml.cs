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

        Page _parent;
        TrainingCoursesService _coursesService = new TrainingCoursesService();
        TrainingCourses _cours;
        public PageEditCourses(TrainingCourses cours,Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _cours = cours;
            BoxIsActive.SelectedIndex = _cours.IsActive ? 0 : 1;
            DataContext = cours;
            _parent = parent;
        }
        public PageEditCourses(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _cours = new TrainingCourses();
            _parent = parent;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _coursesService.Update(_cours);
                DataGridUpdater.UpdateDataGrid(_coursesService.Get(),_parent);
                this.NavigationService.GoBack();
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
                _coursesService.Create(_cours);
                DataGridUpdater.UpdateDataGrid(_coursesService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _cours.Name = Name.Text;
            _cours.Description = Description.Text;
            _cours.Link = Link.Text;
            _cours.LectorFIO = LectorFio.Text;
            _cours.LectorDescription = LectorDescription.Text;
            _cours.DateStart = DateTime.Parse(DateStart.Text);
            _cours.DateEnd = DateTime.Parse(DateEnd.Text);
            _cours.IsActive = bool.Parse(BoxIsActive.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
