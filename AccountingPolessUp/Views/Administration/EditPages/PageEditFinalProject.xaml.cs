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

        Page _parent;
        FinalProjectService _finalProjectService = new FinalProjectService();
        FinalProject _finalProject;
        Employment _employment;
        EmploymentService _employmentService = new EmploymentService();
        List<Employment> _employments;
        public PageEditFinalProject(FinalProject finalProject, Employment employment, Page parent)
        {
            InitializeComponent();
            _employments = _employmentService.Get();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _finalProject = finalProject;
            BoxEmployment.ItemsSource = _employments;
            DataContext = finalProject;
            _employment = employment;
            BoxEmployment.SelectedIndex = _employments.IndexOf(_employments.FirstOrDefault(p => p.Id == _finalProject.EmploymentId));
            _parent = parent;
        }
        public PageEditFinalProject(Employment employment,Page parent)
        {
            InitializeComponent();
            _employments = _employmentService.Get();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _finalProject = new FinalProject();
            _employment = employment;
            _parent = parent;
            BoxEmployment.ItemsSource = _employments;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _finalProjectService.Update(_finalProject);
                DataGridUpdater.UpdateDataGrid(_finalProjectService.GetByEmployment(_employment.Id), _parent);
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
                _finalProjectService.Create(_finalProject);
                DataGridUpdater.UpdateDataGrid(_finalProjectService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _finalProject.DateStart = DateTime.Parse(DateStart.Text);
            _finalProject.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            //_finalProject.EmploymentId = _employment.Id;
            _finalProject.Name = Name.Text;
            _finalProject.Description = Description.Text;
            _finalProject.GitHub = GitHub.Text;
            _finalProject.Links = Links.Text;
            var selectedEmployment = _employments.FirstOrDefault(i => i == BoxEmployment.SelectedItem);
            if (selectedEmployment != null)
                _finalProject.EmploymentId = selectedEmployment.Id;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
