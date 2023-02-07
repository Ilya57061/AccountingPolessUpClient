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
    /// Логика взаимодействия для PageAdmBonus.xaml
    /// </summary>
    public partial class PageAdmBonus : Page
    {
        private readonly BonusService _bonusService = new BonusService();

        public PageAdmBonus()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_bonusService.Get(), this);
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
            FilterManager.ConfirmFilter(dataGrid, _bonusService.Get(), BonusName.Text, BoxRank.Text, BonusDescription.Text);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            DataGridUpdater.UpdateDataGrid(_bonusService.Get(), this);
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
                DataGridUpdater.UpdateDataGrid(_bonusService.Get(), this);
            }
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
    }
}
