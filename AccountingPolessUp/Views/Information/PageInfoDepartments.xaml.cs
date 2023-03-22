using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoDepartments.xaml
    /// </summary>
    public partial class PageInfoDepartments : Page
    {
        DepartmentService _departmentService = new DepartmentService();
        public ObservableCollection<Department> Departments { get; set; }
        public PageInfoDepartments()
        {
            InitializeComponent();
            Departments = new ObservableCollection<Department>(_departmentService.Get().Where(x => x.DateEnd == null && x.Status == "Работает"));
            DataContext = Departments;
            FilterComboBox.SetBoxOrganizations(BoxOrganization);
            FilterComboBox.SetBoxParticipants(BoxParticipant);
        }
        private void ButtonOpenPositions_Click(object sender, RoutedEventArgs e)
        {
            var selectedDepartment = (Department)((Button)sender).DataContext;
            this.NavigationService.Content = new PageInfoPositions(selectedDepartment.Id);

        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(this, Departments, FullName.Text, Description.Text, DateStart.Text, BoxOrganization.Text, BoxParticipant.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(filter);
            DataContext = Departments;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
