using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Interaction logic for PageAdmScheduleOfClasses.xaml
    /// </summary>
    public partial class PageAdmScheduleOfClasses : Page
    {
        private readonly ScheduleOfClassesService _scheduleOfClassesService = new ScheduleOfClassesService();
        List<ScheduleOfСlasses> _scheduleOfClasses;
        TrainingCourses _trainingCourses;
        public PageAdmScheduleOfClasses()
        {
            InitializeComponent();
            DataGridUpdater.AdmScheduleOfClasses = this;
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            FilterComboBox.SetBoxCourses(BoxTrainingCourses);
        }
        public PageAdmScheduleOfClasses(TrainingCourses trainingCourses)
        {
            InitializeComponent();
            DataGridUpdater.AdmScheduleOfClasses = this;
            BoxTrainingCourses.IsEnabled = false;
            _trainingCourses = trainingCourses;
            UpdateDataGrid();
            FilterComboBox.SetBoxCourses(BoxTrainingCourses);
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedSchedule();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditScheduleOfClasses(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
            ButtonCancel.Visibility = Visibility.Hidden;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedSchedule();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _scheduleOfClasses, Description.Text, DateStart.Text, DateEnd.Text, WorkSpaceLink.Text, BoxTrainingCourses.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            if (_trainingCourses == null) _scheduleOfClasses = _scheduleOfClassesService.Get();
            else _scheduleOfClasses = _scheduleOfClassesService.Get(_trainingCourses.Id);
            DataGridUpdater.UpdateDataGrid(_scheduleOfClasses, this);
        }
        private void DeleteSelectedSchedule()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (ScheduleOfСlasses schedule in dataGrid.SelectedItems)
                {
                    _scheduleOfClassesService.Delete(schedule.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedSchedule()
        {
            foreach (ScheduleOfСlasses schedule in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditScheduleOfClasses(schedule, this);
                break;
            }
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception)
            {
                MessageBox.Show("Ресурс не найден");
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
