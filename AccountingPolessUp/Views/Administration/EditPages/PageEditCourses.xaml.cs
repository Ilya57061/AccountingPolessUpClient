using AccountingPolessUp.Helpers;
using AccountingPolessUp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditCourses.xaml
    /// </summary>
    public partial class PageEditCourses : Page
    {
        private TrainingCourses _cours;
        public PageEditCourses(TrainingCourses cours)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _cours = cours;
            BoxIsActive.SelectedIndex = _cours.IsActive ? 0 : 1;
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
            try
            {
                WriteData();
                DataAccess.Update(this, _cours);
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
                DataAccess.Create(this, _cours);
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
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
