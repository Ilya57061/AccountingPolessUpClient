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
        FinalProjectService _finalProjectService = new FinalProjectService();
        public PageAdmFinalProject()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _finalProjectService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    FinalProject FinalProject = dataGrid.SelectedItems[i] as FinalProject;
                    if (FinalProject != null)
                    {

                        _finalProjectService.Delete(FinalProject.Id);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditFinalProject();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                FinalProject FinalProject = dataGrid.SelectedItems[i] as FinalProject;
                if (FinalProject != null)
                {

                    EditFrame.Content = new PageEditFinalProject(FinalProject);

                }
            }
        }
    }
}
