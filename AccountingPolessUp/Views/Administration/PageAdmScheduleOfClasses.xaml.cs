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
            ButtonBack.Visibility = Visibility.Hidden;
            _scheduleOfClasses = _scheduleOfClassesService.Get();
            UpdateDataGrid();
            FilterComboBox.SetBoxCourses(BoxTrainingCourses);
        }
        public PageAdmScheduleOfClasses(TrainingCourses trainingCourses)
        {
            InitializeComponent();
            _trainingCourses = trainingCourses;
            _scheduleOfClasses = _scheduleOfClassesService.Get(_trainingCourses.Id);
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
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedSchedule();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _scheduleOfClasses, Description.Text, DateStart.Text, DateEnd.Text, WorkSpaceLink.Text, BoxTrainingCourses.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
                DataGridUpdater.UpdateDataGrid(_scheduleOfClasses, this);
        }
        private void DeleteSelectedSchedule()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
