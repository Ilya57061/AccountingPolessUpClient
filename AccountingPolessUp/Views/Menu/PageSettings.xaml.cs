using AccountingPolessUp.Views.Settings;
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
