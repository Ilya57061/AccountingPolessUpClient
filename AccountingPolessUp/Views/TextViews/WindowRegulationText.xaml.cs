using AccountingPolessUp.Models;
using System.Windows;

namespace AccountingPolessUp.Views.TextViews
{
    /// <summary>
    /// Логика взаимодействия для WindowRegulationText.xaml
    /// </summary>
    public partial class WindowRegulationText : Window
    {
        public WindowRegulationText(Regulation regulation)
        {
            InitializeComponent();
            this.Title = regulation.Name;
            Text.Text = regulation.Text;
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
