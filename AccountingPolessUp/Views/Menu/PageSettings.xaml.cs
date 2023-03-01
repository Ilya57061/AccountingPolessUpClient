using AccountingPolessUp.Views.Settings;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Views.Menu
{
    /// <summary>
    /// Логика взаимодействия для PageSettings.xaml
    /// </summary>
    public partial class PageSettings : Page
    {
        public PageSettings()
        {
            InitializeComponent();

        }
        private void ButtonSecurity_Click(object sender, RoutedEventArgs e)
        {
            SettingFrame.Content = new PageSecurity();
        }
        private void ButtonPersonalData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
