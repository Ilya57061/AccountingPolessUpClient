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
using AccountingPolessUp.Models;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoBonus.xaml
    /// </summary>
    public partial class PageInfoBonus : Page
    {
        public PageInfoBonus()
        {
            InitializeComponent();
            List<Bonus> bonuses = new List<Bonus>()
            {
                new Bonus{BonusName = "Супер бонус", BonusDescription = "Этот бонус дает супер преимущества", Rang = new Rang{RangName="Ранг 1"}},
                new Bonus{BonusName = "Мега бонус", BonusDescription = "Этот бонус дает мега преимущества", Rang = new Rang{RangName="Ранг 2"}},
                new Bonus{BonusName = "Ультра бонус", BonusDescription = "Этот бонус дает ультра преимущества", Rang = new Rang{RangName="Ранг 3"}},
                new Bonus{BonusName = "Пупер бонус", BonusDescription = "Этот бонус дает пупер преимущества", Rang = new Rang{RangName="Ранг 4"}},
                new Bonus{BonusName = "Альфа бонус", BonusDescription = "Этот бонус дает альфа преимущества", Rang = new Rang{RangName="Ранг 5"}}
            };
            BonusGrid.ItemsSource = bonuses;
        }
    }
}
