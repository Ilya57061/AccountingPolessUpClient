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
    /// Interaction logic for PageAdmAppInTheProject.xaml
    /// </summary>
    public partial class PageAdmAppInTheProject : Page
    {
        ApplicationsInTheProjectService _appService = new ApplicationsInTheProjectService();
        public PageAdmAppInTheProject()
        {
            InitializeComponent();
            DataGridUpdater.Page = this;
            DataGridUpdater.UpdateDataGrid(_appService.Get());
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    ApplicationsInTheProject Applications = dataGrid.SelectedItems[i] as ApplicationsInTheProject;
                    if (Applications != null)
                    {
                        _appService.Delete(Applications.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_appService.Get());
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditApplicationsInTheProject();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                ApplicationsInTheProject Applications = dataGrid.SelectedItems[i] as ApplicationsInTheProject;
                if (Applications != null)
                {
                    EditFrame.Content = new PageEditApplicationsInTheProject(Applications);

                }
            }
        }
    }
}
