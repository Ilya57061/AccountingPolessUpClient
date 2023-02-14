using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using AccountingPolessUp.Views.TextViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmRanks.xaml
    /// </summary>
    public partial class PageAdmRanks : Page
    {
        private readonly RankService _rankService = new RankService();
        List<Rank> _ranks;
        public PageAdmRanks()
        {
            InitializeComponent();
            DataGridUpdater.AdmRanks = this;
            UpdateDataGrid();
            FilterComboBox.SetBoxOrganizations(BoxOrganization);
        }
        public PageAdmRanks(List<Rank> ranks)
        {
            InitializeComponent();
            DataGridUpdater.AdmRanks = this;
            ColumSelect.Visibility = Visibility.Visible;
            _ranks = ranks;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxOrganizations(BoxOrganization);
            UpdateDataGrid();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedRanks();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedRanks();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditRank(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedRanks();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _ranks, RankName.Text, Description.Text, BoxOrganization.Text, MinMmr.Text, MaxMmr.Text);
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
        public void UpdateDataGrid()
        {
            _ranks = _rankService.Get();
            DataGridUpdater.UpdateDataGrid(_ranks, this);
        }
        private void DeleteSelectedRanks()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Rank rank in dataGrid.SelectedItems)
                {
                    _rankService.Delete(rank.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedRanks()
        {
            foreach (Rank rank in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_ranks.FirstOrDefault(x => x.Id == rank.Id));
            }

            this.NavigationService.GoBack();
        }
        private void EditSelectedRanks()
        {
            foreach (Rank rank in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditRank(rank, this);
                break;
            }
        }
        private void ButtonBonuses_Click(object sender, RoutedEventArgs e)
        {
            OpenBonuses();
        }
        private void OpenBonuses()
        {
            foreach (Rank rank in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmBonus(rank);
            }
        }
        private void ButtonDescription_Click(object sender, RoutedEventArgs e)
        {
            foreach (Rank rank in dataGrid.SelectedItems)
            {
                WindowRankDescription windowRank = new WindowRankDescription(rank);
                windowRank.Show();
            }

        }
    }
}
