using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditMembers.xaml
    /// </summary>
    public partial class PageEditMembers : Page
    {
        private UserService _userService = new UserService();
        private IndividualsService _individualsService = new IndividualsService();
        private List<User> _users;
        private List<Individuals> _individuals;
        private Page _parent;
        private Participants _participants;
        public PageEditMembers(Participants participants, Page page)
        {
            InitializeComponent();
            _parent = page;
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            CheckRole();
            _individuals = _individualsService.Get();
            _participants = participants;
            this.DataContext = participants;
            BoxStatus.SelectedIndex = participants.Status == "Активный" ? 0 : 1;
            BoxIndividuals.SelectedIndex = _individuals.IndexOf(_individuals.FirstOrDefault(p => p.Id == participants.IndividualsId));
            BoxUser.SelectedIndex = _users.IndexOf(_users.FirstOrDefault(p => p.Id == participants.UserId));
            BoxIndividuals.ItemsSource = _individuals;
            BoxUser.ItemsSource = _users;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditMembers(Page page)
        {
            InitializeComponent();
            _parent = page;
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _participants = new Participants();
            CheckRole();
            _individuals = _individualsService.Get();
            BoxIndividuals.ItemsSource = _individuals;
            BoxUser.ItemsSource = _users;
            AccessChecker.AccessOpenButton(this);
        }
        private void CheckRole()
        {
            _users = _userService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                _users = _users.Where(x => x.Role.Name == "User").ToList();

        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess.Update(this, _participants);
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
                DataAccess.Create(this, _participants);

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
            _participants.IndividualsId = _individuals.FirstOrDefault(i => i == BoxIndividuals.SelectedItem).Id;
            _participants.Mmr = int.Parse(Mmr.Text);
            _participants.UserId = _users.FirstOrDefault(i => i == BoxUser.SelectedItem).Id;
            _participants.DateEntry = DateTime.Parse(DateEntry.Text);
            _participants.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            _participants.GitHub = GitHub.Text;
            _participants.DateExit = DateTime.TryParse(DateExit.Text, out var dateExitResult) ? dateExitResult : (DateTime?)null;
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
