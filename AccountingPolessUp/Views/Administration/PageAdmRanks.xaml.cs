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
    /// Логика взаимодействия для PageAdmRanks.xaml
    /// </summary>
    public partial class PageAdmRanks : Page
    {
        RankService _rankService = new RankService();
        List<Rank> _ranks; // объявляем, чтобы получить список объектов ComboBox
        public PageAdmRanks()
        {
            InitializeComponent();
            DataGridUpdater.Page = this;
            DataGridUpdater.UpdateDataGrid(_rankService.Get());
        }
        public PageAdmRanks(List<Rank> ranks)
        {

            InitializeComponent();
            _ranks=ranks; 
            DataGridUpdater.Page = this;
            DataGridUpdater.UpdateDataGrid(_rankService.Get());
            ColumSelect.Visibility = Visibility.Visible;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Rank Rank = dataGrid.SelectedItems[i] as Rank;
                    if (Rank != null)
                    {
                        _rankService.Delete(Rank.Id);
                    }
                }
            }
            DataGridUpdater.Page = this;
            DataGridUpdater.UpdateDataGrid(_rankService.Get());
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Rank Rank = dataGrid.SelectedItems[i] as Rank;
               DataNavigator.UpdateValueComboBox(_ranks.FirstOrDefault(x => x.Id == Rank.Id));
            }
            
            this.NavigationService.GoBack();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditRank();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Rank Rank = dataGrid.SelectedItems[i] as Rank;
                if (Rank != null)
                {
                    EditFrame.Content = new PageEditRank(Rank);
                }
            }
        }
    }
}
