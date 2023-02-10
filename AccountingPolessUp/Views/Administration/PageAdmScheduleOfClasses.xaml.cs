using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for PageAdmScheduleOfClasses.xaml
    /// </summary>
    public partial class PageAdmScheduleOfClasses : Page
    {
        private readonly ScheduleOfClassesService _scheduleOfClassesService = new ScheduleOfClassesService();
        public PageAdmScheduleOfClasses()
        {
            InitializeComponent();
            UpdateDataGrid();
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
            FilterManager.ConfirmFilter(dataGrid, _scheduleOfClassesService.Get(), Description.Text, DateStart.Text, DateEnd.Text, WorkSpaceLink.Text, BoxTrainingCourses.Text);
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
            DataGridUpdater.UpdateDataGrid(_scheduleOfClassesService.Get(), this);
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
    }
}
