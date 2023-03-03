using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditIndividuals.xaml
    /// </summary>
    public partial class PageEditIndividuals : Page
    {
        IndividualsService _individualsService = new IndividualsService();

        Page _parent;
        Individuals _individuals;

        public PageEditIndividuals(Individuals individuals, Page parent)
        {
            InitializeComponent();

            _individuals = individuals;
            DataContext = individuals;
            _parent = parent;

            BoxGender.SelectedIndex = _individuals.Gender == "Мужской" ? 0 : 1;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
        }
        public PageEditIndividuals(Page parent)
        {
            InitializeComponent();

            _parent = parent;
            _individuals = new Individuals();

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _individuals);

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
                DataAccess.Create(this, _individuals);

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
            _individuals.SocialNetwork = SocialNetwork.Text;

            _individuals.Gender = ((ComboBoxItem)BoxGender.SelectedItem).Content.ToString();
            _individuals.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
