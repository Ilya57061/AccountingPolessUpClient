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
        FinalProjectService _finalProjectService = new FinalProjectService();
        Employment _employment;
        public PageAdmFinalProject(Employment employment)
        {
            InitializeComponent();
            DataGridUpdater.Page = this;
            _employment = employment;
            DataGridUpdater.UpdateDataGrid(_finalProjectService.Get().Where(x=>x.EmploymentId==employment.Id));
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
            DataGridUpdater.UpdateDataGrid(_finalProjectService.Get().Where(x => x.EmploymentId == _employment.Id));

        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditFinalProject(_employment);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                FinalProject FinalProject = dataGrid.SelectedItems[i] as FinalProject;
                if (FinalProject != null)
                {

                    EditFrame.Content = new PageEditFinalProject(FinalProject, _employment);

                }
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            Confirm();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Clear()
        {
            //ComboORG.SelectedItem = null;
            //TextBoxMaxMmr.Text = string.Empty;
            //TextBoxMinMmr.Text = string.Empty;
            //TextBoxSearch.Text = string.Empty;
            //dataGrid.ItemsSource = null;
            //dataGrid.Items.Clear();
            //dataGrid.ItemsSource = Ranks;
        }
        private void Confirm()
        {
            //IEnumerable<Rank> newRanks = Ranks;
            //if (ComboORG.SelectedItem != null)
            //{
            //    newRanks = newRanks.Where(x => x.OrganizationId == organizations.FirstOrDefault(o => o == ComboORG.SelectedItem).Id);
            //}
            //if (TextBoxSearch.Text != "")
            //{
            //    newRanks = newRanks.Where(x => x.RankName == TextBoxSearch.Text);
            //}
            //if (TextBoxMinMmr.Text != "")
            //{
            //    newRanks = newRanks.Where(x => x.MinMmr == int.Parse(TextBoxMinMmr.Text));
            //}
            //if (TextBoxMaxMmr.Text != "")
            //{
            //    newRanks = newRanks.Where(x => x.MaxMmr == int.Parse(TextBoxMaxMmr.Text));
            //}
            //dataGrid.ItemsSource = null;
            //dataGrid.Items.Clear();
            //dataGrid.ItemsSource = newRanks;
        }
    }
}
