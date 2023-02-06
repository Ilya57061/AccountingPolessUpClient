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
            DataGridUpdater.UpdateDataGrid(_rankService.Get(), this);
        }
        public PageAdmRanks(List<Rank> ranks)
        {

            InitializeComponent();
            _ranks=ranks; 
            DataGridUpdater.UpdateDataGrid(_rankService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ConfirmFilter(dataGrid, _finalProjectService.Get().Where(x => x.EmploymentId == _employment.Id), TextBoxName.Text,
            //    TextBoxDescription.Text, TextBoxGitHub.Text, TextBoxLink.Text, DateStart.Text, DateEnd.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {

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
            DataGridUpdater.UpdateDataGrid(_rankService.Get(),this);
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
            EditFrame.Content = new PageEditRank(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Rank Rank = dataGrid.SelectedItems[i] as Rank;
                if (Rank != null)
                {
                    EditFrame.Content = new PageEditRank(Rank, this);
                }
            }
        }
    }
}
