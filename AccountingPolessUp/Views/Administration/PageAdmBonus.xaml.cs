using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using AccountingPolessUp.Views.TextViews;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmBonus.xaml
    /// </summary>
    public partial class PageAdmBonus : Page
    {
        private BonusService _bonusService = new BonusService();
        private List<Bonus> _bonuses;
        private Rank _rank;

        public PageAdmBonus()
        {
            InitializeComponent();
            DataGridUpdater.AdmBonus = this;
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            BoxsSetData();
        }
        public PageAdmBonus(Rank rank)
        {
            InitializeComponent();
            ButtonAdd.Visibility = Visibility.Hidden;
            DataGridUpdater.AdmBonus = this;
            _rank = rank;
            BoxRank.IsEnabled = false;
            UpdateDataGrid();
            BoxsSetData();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedBonuses();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditBonus(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedBonus();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _bonuses, BonusName.Text, BoxRank.Text, BonusDescription.Text);
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
        private void DeleteSelectedBonuses()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Bonus bonus in dataGrid.SelectedItems)
                {
                    _bonusService.Delete(bonus.Id);
                }
                UpdateDataGrid();
            }
        }
        public void UpdateDataGrid()
        {
            if (_rank == null) _bonuses = _bonusService.Get();
            else _bonuses = _bonusService.Get(_rank.Id);
            DataGridUpdater.UpdateDataGrid(_bonuses, this);
        }
        private void EditSelectedBonus()
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                Bonus bonus = dataGrid.SelectedItem as Bonus;
                if (bonus != null)
                {
                    EditFrame.Content = new PageEditBonus(bonus, this);
                }
            }
        }
        private void BoxsSetData()
        {
            FilterComboBox.SetBoxRank(BoxRank);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            foreach (Bonus bonus in dataGrid.SelectedItems)
            {
                WindowDescription windowRank = new WindowDescription(bonus);
                windowRank.Show();
            }
        }
    }
}
