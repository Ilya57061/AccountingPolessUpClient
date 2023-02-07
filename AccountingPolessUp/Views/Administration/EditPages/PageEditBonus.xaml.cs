using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditBonus.xaml
    /// </summary>
    public partial class PageEditBonus : Page
    {

        Page _parent;
        BonusService _bonusService = new BonusService();
        RankService _RankService = new RankService();
        List<Rank> _ranks;
        Bonus _bonus;
        public PageEditBonus(Bonus bonus, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _ranks = _RankService.Get();
            DataContext = bonus;
            _bonus = bonus;
            _parent = parent;
            BoxRank.ItemsSource = _ranks;
            BoxRank.SelectedItem = _ranks.FirstOrDefault(r => r.Id == bonus.RankId);
        }
        public PageEditBonus(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _bonus = new Bonus();
            _ranks = _RankService.Get();
            _parent=parent;
            BoxRank.ItemsSource = _ranks;
            _parent = parent;
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
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _bonusService.Update(_bonus);
                DataGridUpdater.UpdateDataGrid(_bonusService.Get(), _parent);
                this.NavigationService.GoBack();
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
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _bonusService.Create(_bonus);
                DataGridUpdater.UpdateDataGrid(_bonusService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {

            _bonus.BonusName = BonusName.Text;
            _bonus.BonusDescription = BonusDescription.Text;
            _bonus.RankId = _ranks.FirstOrDefault(i => i == BoxRank.SelectedItem).Id;
        }
    }
}
