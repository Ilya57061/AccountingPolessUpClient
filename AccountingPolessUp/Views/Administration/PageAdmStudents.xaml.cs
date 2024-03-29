﻿using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmStudents.xaml
    /// </summary>
    public partial class PageAdmStudents : Page
    {
        private readonly StudentService _studentService = new StudentService();
        List<Student> _students;
        public PageAdmStudents()
        {
            InitializeComponent();
            DataGridUpdater.AdmStudents = this;
            UpdateDataGrid();
            FilterComboBox.SetBoxIndividuals(BoxIndividuals);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedStudents();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _students, StudentCard.Text, Group.Text, BoxIndividuals.Text, CourseNumber.Text, University.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditStudents(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedStudents();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        public void UpdateDataGrid()
        {
            _students = _studentService.Get();
            DataGridUpdater.UpdateDataGrid(_students, this);
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
