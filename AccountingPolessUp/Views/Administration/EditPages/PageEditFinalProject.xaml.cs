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
    /// Логика взаимодействия для PageEditFinalProject.xaml
    /// </summary>
    public partial class PageEditFinalProject : Page
    {

        
        FinalProjectService _finalProjectService = new FinalProjectService();
        EmploymentService _employmentService = new EmploymentService();
        List<Employment> _employments;
        FinalProject _finalProject;
        public PageEditFinalProject(FinalProject finalProject)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _finalProject = finalProject;
            DataContext = finalProject;
            _employments = _employmentService.Get();
            BoxEmployment.ItemsSource = _employments;
            BoxEmployment.SelectedIndex = _employments.IndexOf(_employments.FirstOrDefault(e => e.Id == finalProject.EmploymentId));
        }
        public PageEditFinalProject()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _finalProject = new FinalProject();
            _employments = _employmentService.Get();
            BoxEmployment.ItemsSource = _employments;
        }
        private void OpenEmployment_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _finalProjectService.Update(_finalProject);
                            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _finalProjectService.Create(_finalProject);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void WriteData()
        {
            _finalProject.DateStart = DateTime.Parse(DateStart.Text);
            _finalProject.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            _finalProject.EmploymentId = _employments.FirstOrDefault(i => i == BoxEmployment.SelectedItem).Id;
            _finalProject.Name = Name.Text;
            _finalProject.Description = Description.Text;
            _finalProject.GitHub=GitHub.Text;
            _finalProject.Links= Links.Text;

        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
