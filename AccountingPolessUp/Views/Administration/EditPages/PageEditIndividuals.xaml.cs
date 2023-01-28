using AccountingPolessUp.Helpers;
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

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditIndividuals.xaml
    /// </summary>
    public partial class PageEditIndividuals : Page // физ лицо
    {

        FormValidator validator = new FormValidator();
        IndividualsService _individualsService = new IndividualsService();
        Individuals _individuals;
        public PageEditIndividuals(Individuals individuals)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _individuals = individuals;
            DataContext = individuals;
        }
        public PageEditIndividuals()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _individuals = new Individuals();
        }

        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _individualsService.Update(_individuals);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _individualsService.Create(_individuals);
        }
        private void WriteData()
        {
            _individuals.FIO = FIO.Text;
            _individuals.Phone = Phone.Text; 
            _individuals.Mail = Mail.Text;
            _individuals.Gender= Gender.Text;
            _individuals.SocialNetwork= SocialNetwork.Text;
        }
    }
}
