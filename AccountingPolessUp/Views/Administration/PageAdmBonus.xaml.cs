using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmBonus.xaml
    /// </summary>
    public partial class PageAdmBonus : Page
    {
        private readonly BonusService _bonusService = new BonusService();
        List<Bonus> _bonuses;
        Rank _rank;

        public PageAdmBonus()
        {
            InitializeComponent();
            ButtonBack.Visibility = Visibility.Hidden;
            _bonuses = _bonusService.Get();
            UpdateDataGrid();
            BoxsSetData();
        }
        public PageAdmBonus(Rank rank)
        {
            InitializeComponent();
            _rank = rank;
            _bonuses = _bonusService.Get(_rank.Id);
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
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedBonus();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
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

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }

        private void DeleteSelectedBonuses()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Bonus bonus in dataGrid.SelectedItems)
                {
                    _bonusService.Delete(bonus.Id);
                }
                UpdateDataGrid();
            }
        }
        private void UpdateDataGrid()
        {
      
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
    }
}
