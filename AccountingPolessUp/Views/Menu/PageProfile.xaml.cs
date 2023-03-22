using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для PageProfile.xaml
    /// </summary>
    public partial class PageProfile : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        StudentService _studentService = new StudentService();
        Participants _participant;
        Student _student;
        public PageProfile(User user)
        {
            InitializeComponent();
            try
            {
                //_participant = _participantsService.GetByUser(user.Id);
                //_student = _studentService.GetByIndividuals(_participant.IndividualsId);
                //UserName.Text = _participant.Individuals.FIO.ToString();
                //InfoDateStart.Text = "Дата вступления: " + _participant.DateEntry.ToString("d");
                //SetBasicRatingBar();
                //InfoDayCount.Text = "Стаж: " + (DateTime.Now - _participant.DateEntry).Days + " Дней";
                //InfoGitHub.Text = _participant.GitHub.ToString();

                //InfoMale.Text = "Гендер: " + _participant.Individuals.Gender.ToString();
                //InfoBirthday.Text = "Дата рождения: " + _participant.Individuals.DateOfBirth.ToString("d");
                //InfoPhone.Text = "Мобильный телефон: " + _participant.Individuals.Phone.ToString();
                //InfoMail.Text = _participant.Individuals.Mail.ToString();
                //InfoSocial.Text = _participant.Individuals.SocialNetwork.ToString();

                //InfoUniversity.Text = "Учебное заведение: " + _student.University.ToString();
                //InfoStudyNumber.Text = "Студенческий билет: " + _student.StudentCard.ToString();
                //InfoGroup.Text = "Группа: " + _student.Group.ToString();
                //InfoKurs.Text = "Курс: " + _student.CourseNumber.ToString();
            }
            catch (Exception)
            {

                //UserName.Text = "Нет данных";
                //InfoDateStart.Text = "Дата вступления: Нет данных";
                //InfoDayCount.Text = "Стаж: Нет данных";
                //InfoGitHub.Text = "Нет данных";

                //InfoMale.Text = "Гендер: Нет данных";
                //InfoBirthday.Text = "Дата рождения: Нет данных";
                //InfoPhone.Text = "Мобильный телефон: Нет данных";
                //InfoMail.Text = "Нет данных";
                //InfoSocial.Text = "Нет данных";

                //InfoUniversity.Text = "Учебное заведение: Нет данных";
                //InfoStudyNumber.Text = "Студенческий билет: Нет данных";
                //InfoGroup.Text = "Группа: Нет данных";
                //InfoKurs.Text = "Курс: Нет данных";
            }

        }

        private void SetBasicRatingBar()
        {
        //    if (_participant.Mmr >= 100 && _participant.Mmr < 1000)
        //    { BasicRatingBar.Value = 2; InfoRank.Text = "Ранг: Джун"; }
        //    else if (_participant.Mmr >= 1000 && _participant.Mmr < 4000)
        //    { BasicRatingBar.Value = 3; InfoRank.Text = "Ранг: Мидл"; }
        //    else if (_participant.Mmr >= 4000)
        //    { BasicRatingBar.Value = 4; InfoRank.Text = "Ранг: Сеньёр"; }
        //    else
        //    {
        //        BasicRatingBar.Value = 1; InfoRank.Text = "Ранг: Стажер";
        //    }
        }
        private void HyperlinkGitHub_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Process.Start(_participant.GitHub);

            //}
            //catch (Exception)
            //{
            //    HyperlinkGitHub.IsEnabled = false;
            //    InfoGitHub.Foreground = new SolidColorBrush(Colors.Gray);
            //}
        }
        private void HyperlinkMail_Click(object sender, RoutedEventArgs e)
        {
            //Clipboard.SetText(_participant.Individuals.Mail);
        }
        private void HyperlinkSocial_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Process.Start(_participant.Individuals.SocialNetwork);
            //}
            //catch (Exception)
            //{
            //    HyperlinkSocial.IsEnabled = false;
            //    InfoSocial.Foreground = new SolidColorBrush(Colors.Gray);
            //}
        }
    }
}
