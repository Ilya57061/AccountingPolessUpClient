using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для PageEditMembers.xaml
    /// </summary>
    public partial class PageEditMembers : Page
    {

        Page _parent;
        ParticipantsService _participantsService = new ParticipantsService();
        UserService _userService = new UserService();
        IndividualsService _individualsService = new IndividualsService();
        List<User> _users;
        List<Individuals> _individuals;

        Participants participants;
        public PageEditMembers(Participants participants, Page page)
        {
            InitializeComponent();
            _parent = page;
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _users = _userService.Get();
            _individuals = _individualsService.Get();
            this.participants = participants;
            this.DataContext = participants;
            BoxStatus.SelectedIndex = participants.Status == "Активный" ? 0 : 1;
            BoxIndividuals.SelectedIndex = _individuals.IndexOf(_individuals.FirstOrDefault(p => p.Id == participants.IndividualsId));
            BoxUser.SelectedIndex = _users.IndexOf(_users.FirstOrDefault(p => p.Id == participants.UserId));
            BoxIndividuals.ItemsSource = _individuals;
            BoxUser.ItemsSource = _users;

        }
        public PageEditMembers(Page page)
        {
            InitializeComponent();
            _parent = page;
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            participants = new Participants();
            _users = _userService.Get();
            _individuals = _individualsService.Get();
            BoxIndividuals.ItemsSource = _individuals;
            BoxUser.ItemsSource = _users;
        }
    
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _participantsService.Update(participants);
                DataGridUpdater.AdmMembers.UpdateDataGrid();
                this.NavigationService.GoBack();
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
                _participantsService.Create(participants);
                DataGridUpdater.AdmMembers.UpdateDataGrid();
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void OpenIndividuals_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxIndividuals.Name;
            _parent.NavigationService.Content = new PageAdmNatural(_individuals);
        }

        private void OpenUser_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxUser.Name;
            _parent.NavigationService.Content = new PageAdmUsers(_users);
        }
        private void WriteData()
        {
            participants.IndividualsId = _individuals.FirstOrDefault(i => i == BoxIndividuals.SelectedItem).Id;
            participants.Mmr = int.Parse(Mmr.Text);
            participants.UserId = _users.FirstOrDefault(i => i == BoxUser.SelectedItem).Id;
            participants.DateEntry = DateTime.Parse(DateEntry.Text);
            participants.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            participants.GitHub = GitHub.Text;
            participants.DateExit = DateTime.TryParse(DateExit.Text, out var dateExitResult) ? dateExitResult : (DateTime?)null;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
