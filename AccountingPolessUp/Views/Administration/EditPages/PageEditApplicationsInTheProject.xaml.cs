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
    /// Interaction logic for PageEditApplicationsInTheProject.xaml
    /// </summary>
    public partial class PageEditApplicationsInTheProject : Page
    {
        private ParticipantsService _participantsService = new ParticipantsService();
        private VacancyService _vacancyService = new VacancyService();
        private Page _parent;
        private List<Vacancy> _vacancy;
        private List<Participants> _participants;
        private ApplicationsInTheProject _applications;
        public PageEditApplicationsInTheProject(ApplicationsInTheProject applications, Page parent)
        {
            InitializeComponent();

            
            _vacancy = _vacancyService.Get();
            _participants = _participantsService.Get();
            DataContext = applications;
            _applications = applications;
            _parent = parent;

            BoxVacancy.ItemsSource = _vacancy;
            BoxParticipant.ItemsSource = _participants;
            
            BoxVacancy.SelectedIndex = _vacancy.IndexOf(_vacancy.FirstOrDefault(r => r.Id == applications.VacancyId));
            BoxParticipant.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(r => r.Id == applications.ParticipantsId));

            BoxIsAccepted.SelectedIndex = (bool)_applications.IsAccepted ? 0 : 1;
            BoxStatus.SelectedIndex = _applications.Status == "Завершено успешно" ? 0 : _applications.Status == "В работе" ? 1 : 2;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditApplicationsInTheProject(Page parent)
        {
            InitializeComponent();

            _applications = new ApplicationsInTheProject();
            _vacancy = _vacancyService.Get();
            _participants = _participantsService.Get();
            _parent = parent;

            BoxVacancy.ItemsSource = _vacancy;
            BoxParticipant.ItemsSource = _participants;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void OpenVacancy_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxVacancy.Name;

            _parent.NavigationService.Content = new PageAdmVacancy(_vacancy);
        }
        private void OpenParticipants_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxParticipant.Name;

            _parent.NavigationService.Content = new PageAdmMembers(_participants);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _applications);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Create(this, _applications);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка");
            }
        }
        private void WriteData()
        {
            _applications.Status = BoxStatus.Text;
            _applications.StatusDescription = StatusDescription.Text;

            _applications.IsAccepted = bool.Parse(BoxIsAccepted.Text);
            _applications.DateEntry = DateTime.Parse(DateEntry.Text);

            _applications.VacancyId = _vacancy.FirstOrDefault(i => i == BoxVacancy.SelectedItem).Id;
            _applications.ParticipantsId = _participants.FirstOrDefault(i => i == BoxParticipant.SelectedItem).Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
