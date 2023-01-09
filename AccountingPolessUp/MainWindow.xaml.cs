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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IndividualsService _indvidualsService;
        public MainWindow()
        {
            InitializeComponent();
            _indvidualsService = new IndividualsService();
            GridInformation.Visibility = Visibility.Hidden;
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            List<Individuals> individuals = _indvidualsService.Get();
            PersonName.Content = individuals[0].FIO;
            PersonPosition.Content = "Пошел в жопу кузьмич";
            GridInformation.Visibility = Visibility.Visible;
        }

        private void ButtonPositions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCourses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMentor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
