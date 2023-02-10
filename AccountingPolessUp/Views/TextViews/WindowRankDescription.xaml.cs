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
    public partial class WindowRankDescription : Window
    {
        public WindowRankDescription(Rank rank)
        {
            InitializeComponent();
            this.Title = rank.RankName;
            Text.Text = rank.Description;
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
