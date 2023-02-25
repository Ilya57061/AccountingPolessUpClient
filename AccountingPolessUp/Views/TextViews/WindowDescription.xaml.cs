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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.TextViews
{
    /// <summary>
    /// Логика взаимодействия для WindowRankDescription.xaml
    /// </summary>
    public partial class WindowDescription : Window
    {
        public WindowDescription(Rank rank)
        {
            InitializeComponent();
            this.Title = rank.RankName;
            Text.Text = rank.Description;
        }
        public WindowDescription(Bonus bonus)
        {
            InitializeComponent();
            this.Title = bonus.BonusName;
            Text.Text = bonus.BonusDescription;
        }
        public WindowDescription(Department department)
        {
            InitializeComponent();
            this.Title = department.FullName;
            Text.Text=department.Description;
        }
        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            if (Text != null)
            {
                Clipboard.SetText(Text.Text);
            }
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
