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
    /// Логика взаимодействия для PageEditDepartments.xaml
    /// </summary>
    public partial class PageEditDepartments : Page
    {
        private DepartmentService _departmentService = new DepartmentService();
        private OrganizationService _organizationService = new OrganizationService();
        private ParticipantsService _participantsService = new ParticipantsService();

        private Department _department;
        private List<Organization> _organizations;
        private List<Participants> _participants;
        private Page _parent;

        public PageEditDepartments(Department department, Page parent)
        {
            InitializeComponent();

            _participants = _participantsService.Get();       
            _organizations = _organizationService.Get();
            _department = department;       
            DataContext = department;
            _parent = parent;

            BoxOrganizations.ItemsSource = _organizations;
            BoxDirector.ItemsSource = _participants;

            BoxOrganizations.SelectedItem = _organizations.FirstOrDefault(i => i.Id == department.OrganizationId);
            BoxDirector.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == _department.DirectorId));

            BoxStatus.SelectedIndex = _department.Status == "Работает" ? 0 : 1;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditDepartments(Page parent)
        {
            InitializeComponent();
            
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            _department = new Department();
            _participants = _participantsService.Get();
            _organizations = _organizationService.Get();
            _parent = parent;

            BoxOrganizations.ItemsSource = _organizations;
            BoxDirector.ItemsSource = _participants;

            AccessChecker.AccessOpenButton(this);
        }
        private void OpenOrganization_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxOrganizations.Name;

            _parent.NavigationService.Content = new PageAdmOrganizations(_organizations);
        }
        private void OpenDirector_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxDirector.Name;

            _parent.NavigationService.Content = new PageAdmMembers(_participants);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _department);
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
                DataAccess.Create(this, _department);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _department.FullName = FullName.Text;
            _department.Description = Description.Text;

            _department.DateStart = DateTime.Parse(DateStart.Text);
            _department.DateEnd = DateTime.TryParse(DateEnd.Text, out var dateExitResult) ? dateExitResult : (DateTime?)null;

            _department.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();

            _department.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganizations.SelectedItem).Id;

            var selectedDirector = _participants.FirstOrDefault(i => i == BoxDirector.SelectedItem);
            if (selectedDirector != null)
                _department.DirectorId = selectedDirector.Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
