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
    /// Логика взаимодействия для PageEditNatural.xaml
    /// </summary>
    public partial class PageEditNatural : Page
    {
        IndividualsService _individualsService = new IndividualsService();
        Individuals _individual;
        public PageEditNatural(Individuals individual)
        {
            InitializeComponent();
            this._individual= individual;
            DataContext = individual;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            _individual.FIO = FIO.Text;
            _individual.Phone = Phone.Text;
            _individual.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
            _individual.Mail = Mail.Text;
            _individual.Gender = Gender.Text;
            _individual.Phone = Phone.Text;
            _individualsService.Update(_individual);
        }
    }
}
