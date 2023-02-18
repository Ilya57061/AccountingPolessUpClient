using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmWork.xaml
    /// </summary>
    public partial class PageAdmWork : Page
    {
        private EmploymentService _employmentService = new EmploymentService();
        private ParticipantsService _participantsService = new ParticipantsService();
        private List<Employment> _employments;

        public PageAdmWork()
        {
            InitializeComponent();
            DataGridUpdater.AdmWork = this;
            BoxMentors.ItemsSource = _participantsService.Get();
            UpdateDataGrid();
            FilterComboBox.SetBoxPositions(BoxPosition);
            FilterComboBox.SetBoxParticipants(BoxParticipants);
        }
        public PageAdmWork(List<Employment> employments)
        {
            InitializeComponent();
            DataGridUpdater.AdmWork = this;
            ColumSelect.Visibility = Visibility.Visible;
            _employments = employments;
            ButtonAdd.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxPositions(BoxPosition);
            FilterComboBox.SetBoxParticipants(BoxParticipants);
            FilterComboBox.SetBoxParticipants(BoxMentors);
            DataGridUpdater.UpdateDataGrid(_employments, this);
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
            DeleteSelectedEmployments();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditWork(this);
        }
        private void ButtonFinalProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFinalProjects();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedEmployment();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            string mentorId = string.IsNullOrEmpty(BoxMentors.Text) ? "" : _participantsService.GetByParticipantName(BoxMentors.Text).Id.ToString();

            FilterManager.ConfirmFilter(dataGrid, _employments, DateStart.Text, DateEnd.Text, BoxPosition.Text, BoxStatus.Text, StatusDescription.Text, mentorId, BoxParticipants.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        public void UpdateDataGrid()
        {
            try
            {
                _employments = _employmentService.Get();
                if (RoleValidator.User.Role.Name != "Admin")
                    _employments = _employments.Where(x => RoleValidator.RoleChecker((int)x.Position.Department.DirectorId) == true).ToList();
                DataGridUpdater.UpdateDataGrid(_employments, this);
            }
            catch (System.Exception)
            {

            }
           
        }
        private void DeleteSelectedEmployments()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Employment employment in dataGrid.SelectedItems)
                {
                    _employmentService.Delete(employment.Id);
                }
            }
            UpdateDataGrid();
        }
        private void OpenFinalProjects()
        {
            foreach (Employment employment in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmFinalProject(employment);
            }
        }
        private void EditSelectedEmployment()
        {
            foreach (Employment employment in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditWork(employment, this);
                break;
            }
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Employment employment = dataGrid.SelectedItems[i] as Employment;
                DataNavigator.UpdateValueComboBox(_employments.FirstOrDefault(x => x.Id == employment.Id));
            }

            this.NavigationService.GoBack();
        }
    }
}
