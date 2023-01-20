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
        ParticipantsService _participantsService = new ParticipantsService();
        PositionService _positionsService = new PositionService();
        EmploymentService _employmentService = new EmploymentService();
        List<Position> _positions;
        List<Participants> _participants;

        Employment employment;
        public PageEditWork(Employment employment)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _positions = _positionsService.Get();
            _participants = _participantsService.Get();
            this.employment = employment;
            this.DataContext = employment;
            BoxParticipants.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(p => p.Id == employment.ParticipantsId));
            BoxPosition.SelectedIndex = _positions.IndexOf(_positions.FirstOrDefault(p => p.Id == employment.PositionId));
            BoxParticipants.ItemsSource = _participants;
            BoxPosition.ItemsSource = _positions;

        }
        public PageEditWork()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            employment = new Employment();
            _positions = _positionsService.Get();
            _participants = _participantsService.Get();
            BoxParticipants.ItemsSource = _participants;
            BoxPosition.ItemsSource = _positions;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {

            WriteData();
            _employmentService.Update(employment);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _employmentService.Create(employment);
        }
        private void WriteData()
        {
            employment.ParticipantsId = _participants.FirstOrDefault(i => i == BoxParticipants.SelectedItem).Id;
            employment.PositionId = _positions.FirstOrDefault(i => i == BoxPosition.SelectedItem).Id;
            employment.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
        }
    }
}
