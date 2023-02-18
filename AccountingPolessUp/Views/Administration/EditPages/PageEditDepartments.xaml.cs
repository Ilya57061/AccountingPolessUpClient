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
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _organizations = _organizationService.Get();
            _department = department;
            BoxDirector.ItemsSource = _participants;
            DataContext = department;
            BoxOrganizations.ItemsSource = _organizations;
            BoxStatus.SelectedIndex = _department.Status == "Работает" ? 0 : 1;
            BoxOrganizations.SelectedItem = _organizations.FirstOrDefault(i => i.Id == department.OrganizationId);
            BoxDirector.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == _department.DirectorId));
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditDepartments(Page parent)
        {
            InitializeComponent();
            _participants = _participantsService.Get();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _department = new Department();
            _organizations = _organizationService.Get();
            BoxOrganizations.ItemsSource = _organizations;
            _parent = parent;
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
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _departmentService.Update(_department);
                DataGridUpdater.AdmDepartments.UpdateDataGrid();
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
                _departmentService.Create(_department);
                DataGridUpdater.AdmDepartments.UpdateDataGrid();
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
