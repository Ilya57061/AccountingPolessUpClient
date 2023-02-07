using AccountingPolessUp.Helpers;
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

        Page _parent;
        ApplicationsInTheProjectService _applicationService = new ApplicationsInTheProjectService();
        List<Vacancy> _vacancy;
        VacancyService _vacancyService = new VacancyService();
        ParticipantsService _participantsService = new ParticipantsService();
        List<Participants> _participants;
        ApplicationsInTheProject _applications;
        public PageEditApplicationsInTheProject(ApplicationsInTheProject applications, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            try
            {
                _vacancy = _vacancyService.Get();
                _participants = _participantsService.Get();
                DataContext = applications;
                _applications = applications;
                BoxVacancy.ItemsSource = _vacancy;
                BoxParticipant.ItemsSource = _participants;
                BoxWorkStatus.SelectedIndex = _applications.WorkStatus == "Принят в работу" ? 0 : 1;
                BoxVacancy.SelectedIndex = _vacancy.IndexOf(_vacancy.FirstOrDefault(r => r.Id == applications.VacancyId));
                BoxParticipant.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(r => r.Id == applications.ParticipantsId));
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка на стороне сервера", "Ошибка");
            }
            _parent = parent;
        }
        public PageEditApplicationsInTheProject(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _parent = parent;
            try
            {
                _applications = new ApplicationsInTheProject();
                _vacancy = _vacancyService.Get();
                _participants = _participantsService.Get();
                BoxVacancy.ItemsSource = _vacancy;
                BoxParticipant.ItemsSource = _participants;

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка на стороне сервера", "Ошибка");
            }

        }
        private void OpenVacancy_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxVacancy.Name;
            _parent.NavigationService.Content = new PageAdmVacancy(_vacancy);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _applicationService.Update(_applications);
                DataGridUpdater.UpdateDataGrid(_applicationService.Get(), _parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка API", "Ошибка");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _applicationService.Create(_applications);
                DataGridUpdater.UpdateDataGrid(_applicationService.Get(), _parent);

            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка");
            }
        }
        private void WriteData()
        {
            _applications.WorkStatus = ((ComboBoxItem)BoxWorkStatus.SelectedItem).Content.ToString();
            _applications.DateEntry = DateTime.Parse(DateEntry.Text);
            _applications.VacancyId = _vacancy.FirstOrDefault(i => i == BoxVacancy.SelectedItem).Id;
            _applications.ParticipantsId = _participants.FirstOrDefault(i => i == BoxParticipant.SelectedItem).Id;
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
