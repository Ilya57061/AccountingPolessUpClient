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
        public PageAddMembers()
        {
            InitializeComponent();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Participants participants = new Participants();
            participants.IndividualsId = int.Parse(IndividualsId.Text);
            participants.RangId = int.Parse(RangId.Text);
            participants.UserId = int.Parse(UserId.Text);
            participants.DateEntry = DateTime.Parse(DateEntry.Text);
            participants.DateExit = DateTime.Parse(DateExit.Text);
            participants.Status = Status.Text;
            participants.GitHub = GitHub.Text;
            _participantsService.Create(participants);
        }
        private void OpenIndividuals_Click(object sender, RoutedEventArgs e)
        {
        }
        private void OpenRank_Click(object sender, RoutedEventArgs e)
        {
        }
        private void OpenUser_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
