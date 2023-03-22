using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            InitializeComponent();

            _participants = _participantsService.Get();
            _customers = _customerService.Get();
            _parent = parent;
            _project = project;
            DataContext = project;
              
            BoxLocalPM.ItemsSource = _participants;
            BoxCustomer.ItemsSource = _customers;
            
            BoxCustomer.SelectedIndex = _customers.IndexOf(_customers.FirstOrDefault(c => c.Id == project.CustomerId));
            BoxLocalPM.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == project.idLocalPM));

            BoxStatus.SelectedIndex = _project.Status == "Завершён" ? 0 : 1;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditProject(Page parent)
        {
            InitializeComponent();

            _project = new Project();
            _customers = _customerService.Get();
            _participants = _participantsService.Get();
            _parent = parent;
                
            BoxCustomer.ItemsSource = _customers;
            BoxLocalPM.ItemsSource = _participants;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _project);

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
                DataAccess.Create(this, _project);

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
            _project.Description = Description.Text;
            _project.TechnicalSpecification = TechnicalSpecification.Text;

            _project.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            _project.CustomerId = _customers.FirstOrDefault(i => i == BoxCustomer.SelectedItem).Id;

            _project.DateStart = DateTime.Parse(DateStart.Text);
            _project.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);

            var selectedLocalPM = _participants.FirstOrDefault(i => i == BoxLocalPM.SelectedItem);
            if (selectedLocalPM != null)
                _project.idLocalPM = selectedLocalPM.Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
