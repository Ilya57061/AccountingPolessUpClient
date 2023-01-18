using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmMembers.xaml
    /// </summary>

    public partial class PageAdmMembers : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        public PageAdmMembers()
        {
            InitializeComponent();
            membersGrid.ItemsSource = _participantsService.Get();
           // membersGrid.ItemsSource = new List<Participants>() { new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" }, new Participants { Id = 1, IndividualsId = 2, RangId = 3, UserId = 1, DateEntry = DateTime.Now, DateExit = DateTime.Now, GitHub = "git", Status = "status check" } };
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (membersGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < membersGrid.SelectedItems.Count; i++)
                {
                    Participants participants = membersGrid.SelectedItems[i] as Participants;
                    if (participants != null)
                    {
                        
                        _participantsService.Delete(participants.Id);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageAddMembers();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < membersGrid.SelectedItems.Count; i++)
            {
                Participants participants = membersGrid.SelectedItems[i] as Participants;
                if (participants != null)
                {
                    EditFrame.Content = new PageEditMembers(participants);

                }
            }
        }
    }
}
