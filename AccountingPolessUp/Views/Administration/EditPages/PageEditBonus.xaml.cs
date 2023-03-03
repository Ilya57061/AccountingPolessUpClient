using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditBonus.xaml
    /// </summary>
    public partial class PageEditBonus : Page
    {
        private RankService _RankService = new RankService();
        private RankBonusService _rankBonusService = new RankBonusService();

        private List<Rank> _ranks;
        private Bonus _bonus;
        private Page _parent;

        public PageEditBonus(Bonus bonus, Page parent)
        {
            InitializeComponent();

            _ranks = _RankService.Get();
            _bonus = bonus;
            _parent = parent;
            DataContext = bonus;

            BoxRank.ItemsSource = _ranks;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;             
        }
        public PageEditBonus(Page parent)
        {
            InitializeComponent();
 
            _bonus = new Bonus();
            _ranks = _RankService.Get();
            _parent = parent;

            BoxRank.ItemsSource = _ranks;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            ButtonSaveRankBonus.IsEnabled = false;
            ButtonDeleteRankBonus.IsEnabled = false;
        }
        private void OpenRank_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxRank.Name;

            _parent.NavigationService.Content = new PageAdmRanks(_ranks);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _bonus);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Create(this, _bonus);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonSaveRankBonus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rankBonusService.Create(new RankBonus { RankId = _ranks.FirstOrDefault(i => i == BoxRank.SelectedItem).Id, BonusId = _bonus.Id });

                DataGridUpdater.AdmBonus.UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при создании связи");
            }

        }
        private void ButtonDeleteRankBonus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _rankBonusService.Delete(_ranks.FirstOrDefault(i => i == BoxRank.SelectedItem).Id, _bonus.Id);
                DataGridUpdater.AdmBonus.UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при удалении связи");
            }
        }
        private void WriteData()
        {
            _bonus.BonusName = BonusName.Text;
            _bonus.BonusDescription = BonusDescription.Text;
        }
    }
}
