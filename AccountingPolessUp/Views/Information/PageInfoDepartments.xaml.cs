using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Departments = new ObservableCollection<Department>(_departmentService.Get());
            DataContext = Departments;
            //FilterComboBox.SetBoxOrganizations(BoxOrganization);
        }
        private void ButtonOpenPositions_Click(object sender, RoutedEventArgs e)
        {
            var selectedDepartment = (Department)((Button)sender).DataContext;
            this.NavigationService.Content = new PageInfoPositions(selectedDepartment.Id);

        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ConfirmFilter(this, Ranks, RankName.Text, Description.Text, BoxOrganization.Text, MinMmr.Text, MaxMmr.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ClearControls(filter);
            //DataContext = Ranks;
        }
        private void Number_PreviewTextInput(object sender, RoutedEventArgs e)
        {

        }
    }
}
