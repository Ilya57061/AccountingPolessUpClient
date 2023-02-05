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

        Page _parent;
        IndividualsService _individualsService = new IndividualsService();
        Individuals _individuals;
        public PageEditIndividuals(Individuals individuals, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _individuals = individuals;
            DataContext = individuals;
            _parent = parent;
        }
        public PageEditIndividuals(Page parent)
        {
            _parent = parent;
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _individuals = new Individuals();
        }

        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _individualsService.Update(_individuals);
                DataGridUpdater.UpdateDataGrid(_individualsService.Get());
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _individualsService.Create(_individuals);
                DataGridUpdater.UpdateDataGrid(_individualsService.Get());
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _individuals.FIO = FIO.Text;
            _individuals.Phone = Phone.Text; 
            _individuals.Mail = Mail.Text;
            _individuals.Gender = ((ComboBoxItem)BoxGender.SelectedItem).Content.ToString();
            _individuals.SocialNetwork= SocialNetwork.Text;
            _individuals.DateOfBirth= DateTime.Parse(DateOfBirth.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
