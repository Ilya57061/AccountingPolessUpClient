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
    /// Логика взаимодействия для PageAddMembers.xaml
    /// </summary>
    public partial class PageAddMembers : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        UserService _userService = new UserService();
        IndividualsService _individualsService = new IndividualsService();
        List<User> _users;
        List<Individuals> _individuals;
        public PageAddMembers()
        {
            InitializeComponent();
            _users = _userService.Get();
            _individuals = _individualsService.Get();
            BoxIndividuals.ItemsSource = _individuals;
            BoxUser.ItemsSource = _users;
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Participants participants = new Participants();
            participants.IndividualsId = _individuals.FirstOrDefault(i => i == BoxIndividuals.SelectedItem).Id;
            participants.mmr = int.Parse(mmr.Text);
            participants.UserId = _users.FirstOrDefault(i => i == BoxUser.SelectedItem).Id;
            participants.DateEntry = DateTime.Parse(DateEntry.Text);
            participants.DateExit = DateExit.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateExit.Text);
            participants.Status = Status.Text;
            participants.GitHub = GitHub.Text;
            _participantsService.Create(participants);
        }
        private void OpenIndividuals_Click(object sender, RoutedEventArgs e)
        {
        }
       
        private void OpenUser_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
