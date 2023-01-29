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

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для PageProfile.xaml
    /// </summary>
    public partial class PageProfile : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        //EmploymentService _employmentService = new EmploymentService();
        FinalProjectService _finalProjectService = new FinalProjectService();
        StudentService _studentService = new StudentService();
        Participants _participant;
        Student _student;
        //Employment _employment;
        //List<FinalProject> _finalProjects;
        public PageProfile(User user)
        {
            InitializeComponent();
            _participant = _participantsService.GetByUser(user.Id);
            _student=_studentService.GetByIndividuals(_participant.IndividualsId);
            //_employment = _employmentService.GetByParticipants(_participant.Id);
            //_finalProjects = _finalProjectService.GetByEmployment(_employment.Id);
            UserName.Text = _participant.Individuals.FIO;
            InfoDateStart.Text="Дата вступления: "+_participant.DateEntry.ToString("d");
            InfoDateStart.Text="Дата вступления: "+_participant.DateEntry.ToString("d");
            InfoRank.Text="Ранг: "+_participant.Mmr.ToString()+" Mmr";
            SetBasicRatingBar();
            InfoDayCount.Text ="Дата вступления: " +(DateTime.Now - _participant.DateEntry).ToString("d") +" Дней";
            //InfoCountEndProject.Text=_finalProjects.Count.ToString();
            InfoGitHub.Text= "GitHub: "+_participant.GitHub.ToString();

            InfoMale.Text = "Гендер: "+ _participant.Individuals.Gender.ToString();
            InfoBirthday.Text= "Дата рождения: " + _participant.Individuals.DateOfBirth.ToString("d");
            InfoPhone.Text= "Мобильный телефон: " +  _participant.Individuals.Phone.ToString();
            InfoMail.Text= "Электронная почта: " + _participant.Individuals.Mail.ToString();
            InfoSocial.Text= "Социальная сеть: " + _participant.Individuals.SocialNetwork.ToString();

            InfoUniversity.Text= "Учебное заведение: " + _student.University.ToString();
            InfoStudyNumber.Text= "Студенческий билет: " + _student.StudentCard.ToString();
            InfoGroup.Text= "Группа: " + _student.Group.ToString();
            InfoKurs.Text= "Курс: " + _student.CourseNumber.ToString();
        }

        private void SetBasicRatingBar()
        {
            if (_participant.Mmr >= 2000 && _participant.Mmr < 4000)
                BasicRatingBar.Value = 1;
            else if (_participant.Mmr >= 4000 && _participant.Mmr < 6000)
                BasicRatingBar.Value = 2;
            else if (_participant.Mmr >= 6000 && _participant.Mmr < 8000)
                BasicRatingBar.Value = 3;
            else if (_participant.Mmr >= 8000 && _participant.Mmr < 10000)
                BasicRatingBar.Value = 4;
            else if (_participant.Mmr >= 10000)
                BasicRatingBar.Value = 5;
            else BasicRatingBar.Value = 0;
        }
    }
}
