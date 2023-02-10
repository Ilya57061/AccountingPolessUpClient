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
    /// Логика взаимодействия для PageAdmFinalProject.xaml
    /// </summary>
    public partial class PageAdmFinalProject : Page
    {
        private readonly FinalProjectService _finalProjectService = new FinalProjectService();
        Employment _employment;
        public PageAdmFinalProject(Employment employment)
        {
            InitializeComponent();
            _employment = employment;
            UpdateDataGrid();
        }
        public PageAdmFinalProject()
        {
            InitializeComponent();
            ButtonBack.Visibility = Visibility.Hidden;
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
            DeleteSelectedFinalProjects();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditFinalProject(_employment, this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedFinalProjects();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _finalProjectService.Get(), Name.Text, Description.Text, GitHub.Text, Links.Text, DateStart.Text, DateEnd.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            if (_employment == null)
                DataGridUpdater.UpdateDataGrid(_finalProjectService.Get(), this);
            else
                DataGridUpdater.UpdateDataGrid(_finalProjectService.GetByEmployment(_employment.Id), this);
        }
        private void DeleteSelectedFinalProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (FinalProject finalProject in dataGrid.SelectedItems)
                {
                    _finalProjectService.Delete(finalProject.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedFinalProjects()
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                FinalProject finalProject = dataGrid.SelectedItem as FinalProject;
                if (finalProject != null)
                {
                    EditFrame.Content = new PageEditFinalProject(finalProject, _employment, this);
                }
            }
        }
    }
}
