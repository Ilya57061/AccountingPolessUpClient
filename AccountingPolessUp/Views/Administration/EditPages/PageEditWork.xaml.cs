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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditWork.xaml
    /// </summary>
    public partial class PageEditWork : Page
    {
        Page _parent;
        ParticipantsService _participantsService = new ParticipantsService();
        PositionService _positionsService = new PositionService();
        EmploymentService _employmentService = new EmploymentService();
        List<Position> _positions;
        List<Participants> _participants;
        Employment employment;
        public PageEditWork(Employment employment, Page parent)
        {
            InitializeComponent();
            _parent = parent;
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _positions = _positionsService.Get();
            _participants = _participantsService.Get();
            this.employment = employment;
            this.DataContext = employment;
            BoxMentors.ItemsSource = _participants;
            BoxPosition.ItemsSource = _positions;
            BoxStatus.SelectedIndex = employment.Status == "Завершено успешно" ? 0 : 1;
            BoxParticipants.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == employment.ParticipantsId));
            BoxMentors.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == employment.IdMentor));
            BoxPosition.SelectedIndex = _positions.IndexOf(_positions.FirstOrDefault(p => p.Id == employment.PositionId));
            BoxParticipants.ItemsSource = _participants;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditWork(Page parent)
        {
            InitializeComponent();
            _parent = parent;
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            employment = new Employment();
            _positions = _positionsService.Get();
            _participants = _participantsService.Get();
            BoxParticipants.ItemsSource = _participants;
            BoxMentors.ItemsSource = _participants;
            BoxPosition.ItemsSource = _positions;
            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _employmentService.Update(employment);
                DataGridUpdater.AdmWork.UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void OpenParticipants_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxParticipants.Name;
            _parent.NavigationService.Content = new PageAdmMembers(_participants);
        }
        private void OpenMentors_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxMentors.Name;
            _parent.NavigationService.Content = new PageAdmMembers(_participants);
        }
        private void OpenPositions_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxPosition.Name;
            _parent.NavigationService.Content = new PageAdmPosition(_positions);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _employmentService.Create(employment);
                DataGridUpdater.AdmWork.UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            employment.ParticipantsId = _participants.FirstOrDefault(i => i == BoxParticipants.SelectedItem).Id;
            employment.PositionId = _positions.FirstOrDefault(i => i == BoxPosition.SelectedItem).Id;
            employment.DateStart = DateStart.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateStart.Text);
            employment.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            employment.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            employment.StatusDescription = StatusDescription.Text;
            var selectedMentor = _participants.FirstOrDefault(i => i == BoxMentors.SelectedItem);
            if (selectedMentor != null)
                employment.IdMentor = selectedMentor.Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
