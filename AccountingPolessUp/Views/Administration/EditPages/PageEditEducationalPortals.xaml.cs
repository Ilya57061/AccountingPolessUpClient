using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditEducationalPortals.xaml
    /// </summary>
    public partial class PageEditEducationalPortals : Page
    {
        public PageEditEducationalPortals()
        {
            InitializeComponent();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
        }
        private void WriteData()
        {
            
        }
    }
}
