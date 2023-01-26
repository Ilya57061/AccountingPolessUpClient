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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Interaction logic for PageEditApplicationsInTheProject.xaml
    /// </summary>
    public partial class PageEditApplicationsInTheProject : Page
    {
        ApplicationsInTheProjectService _applicationService = new ApplicationsInTheProjectService();
        List<Vacancy> _vacancy;
        VacancyService _vacancyService = new VacancyService();
        ParticipantsService _participantsService = new ParticipantsService();
        List<Participants> _participants;
        ApplicationsInTheProject _applications;
        public PageEditApplicationsInTheProject(ApplicationsInTheProject applications)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _vacancy = _vacancyService.Get();
            _participants = _participantsService.Get();
            DataContext = applications;
            _applications = applications;
            BoxVacancy.ItemsSource = _vacancy;
            BoxParticipant.ItemsSource = _participants;
            BoxVacancy.SelectedIndex = _vacancy.IndexOf(_vacancy.FirstOrDefault(r => r.Id == applications.VacancyId));
            BoxParticipant.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(r => r.Id == applications.ParticipantsId));
        }
        public PageEditApplicationsInTheProject()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _applications = new ApplicationsInTheProject();
            _vacancy = _vacancyService.Get();
            _participants = _participantsService.Get();
            BoxVacancy.ItemsSource = _vacancy;
            BoxParticipant.ItemsSource = _participants;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _applicationService.Update(_applications);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _applicationService.Create(_applications);
        }
        private void WriteData()
        {
            _applications.WorkStatus = WorkStatus.Text;
            _applications.DateEntry = DateTime.Parse(DateEntry.Text);
            _applications.VacancyId = _vacancy.FirstOrDefault(i => i == BoxVacancy.SelectedItem).Id;
            _applications.ParticipantsId = _vacancy.FirstOrDefault(i => i == BoxParticipant.SelectedItem).Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
