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
    /// Логика взаимодействия для PageAddNatural.xaml
    /// </summary>
    public partial class PageAddNatural : Page
    {
        IndividualsService _individualsService = new IndividualsService();
        public PageAddNatural()
        {
            InitializeComponent();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Individuals individual = new Individuals();
            individual.FIO = FIO.Text;
            individual.Phone= Phone.Text;
            individual.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
            individual.Mail = Mail.Text;
            individual.Gender= Gender.Text;
            individual.Phone= Phone.Text;
            _individualsService.Create(individual);
        }
    }
}
