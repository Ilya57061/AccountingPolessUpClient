using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для PageEditProject.xaml
    /// </summary>
    public partial class PageEditProject : Page
    {

        Page _parent;
        ProjectService _projectService = new ProjectService();
        CustomerService _customerService = new CustomerService();

        List<Customer> _customers;
        Project _project;
        public PageEditProject(Project project, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _project = project;
            _customers = _customerService.Get();
            DataContext = project;
            BoxCustomer.ItemsSource = _customers;
            BoxCustomer.SelectedIndex = _customers.IndexOf(_customers.FirstOrDefault(c => c.Id == project.CustomerId));
            _parent = parent;
        }
        public PageEditProject(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _project= new Project();
            _customers = _customerService.Get();
            BoxCustomer.ItemsSource = _customers;
            _parent = parent;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _projectService.Update(_project);
                DataGridUpdater.UpdateDataGrid(_projectService.Get(), _parent);
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
                _projectService.Create(_project);
                DataGridUpdater.UpdateDataGrid(_projectService.Get(), _parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void OpenCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxCustomer.Name;
            _parent.NavigationService.Content = new PageAdmCustomer(_customers);
        }
        private void WriteData()
        {
            _project.Fullname = Fullname.Text;
            _project.Status = Status.Text;
            _project.Description= Description.Text;
            _project.TechnicalSpecification=TechnicalSpecification.Text;
            _project.idLocalPM = int.Parse(idLocalPM.Text);
            _project.CustomerId=_customers.FirstOrDefault(i=>i==BoxCustomer.SelectedItem).Id;
            _project.DateStart = DateTime.Parse(DateStart.Text);
            _project.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
