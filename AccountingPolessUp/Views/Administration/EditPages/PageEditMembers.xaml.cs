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
    /// Логика взаимодействия для PageEditMembers.xaml
    /// </summary>
    public partial class PageEditMembers : Page
    {
        Participants participants;
        public PageEditMembers(Participants participants)
        {
            InitializeComponent();
            this.participants = participants;
            IndividualsId.Text=participants.IndividualsId.ToString();
            RangId.Text=participants.RangId.ToString();
            UserId.Text=participants.UserId.ToString();
            DateEntry.Text=participants.DateEntry.ToString();
            DateExit.Text=participants.DateExit.ToString();
            Status.Text=participants.Status.ToString();
            GitHub.Text = participants.GitHub.ToString();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
