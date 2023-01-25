using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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
        BonusService _bonusService = new BonusService();
        RangService _rangService = new RangService();
        List<Rang> _rangs;
        Bonus _bonus;
        public PageEditBonus(Bonus bonus)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _rangs = _rangService.Get();
            DataContext = bonus;
            _bonus = bonus;
            BoxRang.ItemsSource = _rangs;
            BoxRang.SelectedIndex = _rangs.IndexOf(_rangs.FirstOrDefault(r => r.Id == bonus.RangId));
        }
        public PageEditBonus()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _bonus = new Bonus();
        }
        private void OpenRank_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _bonusService.Update(_bonus);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _bonusService.Create(_bonus);
        }
        private void WriteData()
        {
            _bonus.BonusName = BonusName.Text;
            _bonus.BonusDescription = BonusDescription.Text;
            _bonus.RangId = _rangs.FirstOrDefault(i => i == BoxRang.SelectedItem).Id;
        }
    }
}
