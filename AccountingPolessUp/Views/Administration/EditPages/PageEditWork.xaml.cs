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
    /// Логика взаимодействия для PageEditWork.xaml
    /// </summary>
    public partial class PageEditWork : Page
    {
        private ParticipantsService _participantsService = new ParticipantsService();
        private PositionService _positionsService = new PositionService();
        private EmploymentService _employmentService = new EmploymentService();
        private List<Position> _positions;
        private List<Participants> _participants;
        private Page _parent;
        private Employment employment;
        
        public PageEditWork(Employment employment, Page parent)
        {
            InitializeComponent();
            _parent = parent;
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            SetPositions();
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
            SetPositions();
            employment = new Employment();
            _participants = _participantsService.Get();
            BoxParticipants.ItemsSource = _participants;
            BoxMentors.ItemsSource = _participants;
            BoxPosition.ItemsSource = _positions;
            AccessChecker.AccessOpenButton(this);
        }
        private void SetPositions()
        {
            _positions = _positionsService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
            {
                _positions = _positions.Where(x => RoleValidator.RoleChecker((int)x.Department.DirectorId) == true).ToList();
            }
            BoxPosition.ItemsSource = _positions;
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
