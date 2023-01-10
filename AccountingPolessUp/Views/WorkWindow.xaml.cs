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
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    { 
    
        public WorkWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageProfile();

        }
        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            //List<Individuals> individuals = _indvidualsService.Get();
            MainFrame.Content = new PageProfile();
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

        private void ButtonEmployment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageEmployment();
        }
    }
}
