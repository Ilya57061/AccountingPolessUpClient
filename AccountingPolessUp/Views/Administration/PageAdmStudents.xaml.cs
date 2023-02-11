using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
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

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmStudents.xaml
    /// </summary>
    public partial class PageAdmStudents : Page
    {
        private readonly StudentService _studentService = new StudentService();
        public PageAdmStudents()
        {
            InitializeComponent();
            UpdateDataGrid();
            FilterComboBox.SetBoxIndividuals(BoxIndividuals);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedStudents();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _studentService.Get(), StudentCard.Text, Group.Text, BoxIndividuals.Text, CourseNumber.Text, University.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditStudents(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedStudents();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_studentService.Get(), this);
        }
        private void DeleteSelectedStudents()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Student student in dataGrid.SelectedItems)
                {
                    _studentService.Delete(student.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedStudents()
        {
            foreach (Student student in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditStudents(student, this);
                break;
            }
        }
    }
}
