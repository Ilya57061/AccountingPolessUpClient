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
        private ProjectService _projectService = new ProjectService();
        private CustomerService _customerService = new CustomerService();
        private ParticipantsService _participantsService = new ParticipantsService();
        private List<Customer> _customers;
        private List<Participants> _participants;
        private Project _project;
        private Page _parent;

        public PageEditProject(Project project, Page parent)
        {
            _parent = parent;
            _project = project;
            InitializeComponent();
            _participants = _participantsService.Get();
            _customers = _customerService.Get();
            DataContext = project;
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            BoxStatus.SelectedIndex = _project.Status == "Завершён" ? 0 : 1;
            BoxLocalPM.ItemsSource = _participants;
            BoxCustomer.ItemsSource = _customers;
            BoxCustomer.SelectedIndex = _customers.IndexOf(_customers.FirstOrDefault(c => c.Id == project.CustomerId));
            BoxLocalPM.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == project.idLocalPM));
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditProject(Page parent)
        {
            _parent = parent;
            _project = new Project();
            InitializeComponent();
            _customers = _customerService.Get();
            _participants = _participantsService.Get();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            BoxCustomer.ItemsSource = _customers;
            BoxLocalPM.ItemsSource = _participants;
            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _projectService.Update(_project);
                DataGridUpdater.AdmProjects.UpdateDataGrid();
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
                _projectService.Create(_project);
                DataGridUpdater.AdmProjects.UpdateDataGrid();
                this.NavigationService.GoBack();
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
            _project.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            _project.Description = Description.Text;
            _project.TechnicalSpecification = TechnicalSpecification.Text;
            _project.CustomerId = _customers.FirstOrDefault(i => i == BoxCustomer.SelectedItem).Id;
            _project.DateStart = DateTime.Parse(DateStart.Text);
            _project.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            var selectedLocalPM = _participants.FirstOrDefault(i => i == BoxLocalPM.SelectedItem);
            if (selectedLocalPM != null)
                _project.idLocalPM = selectedLocalPM.Id;
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
