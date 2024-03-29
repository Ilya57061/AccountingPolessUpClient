﻿using AccountingPolessUp.Helpers;
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
    /// Interaction logic for PageEditRegistrationForCourses.xaml
    /// </summary>
    public partial class PageEditRegistrationForCourses : Page
    {
        private RegistrationForCoursesService _registrationForCoursesService = new RegistrationForCoursesService();
        private ParticipantsService _participantsService = new ParticipantsService();
        private TrainingCoursesService _trainingCoursesService = new TrainingCoursesService();

        private Page _parent;
        private List<Participants> _participants;
        private List<TrainingCourses> _trainingCourses;
        private RegistrationForCourses _registrationForCourses;
        public PageEditRegistrationForCourses(RegistrationForCourses registrationForCourses, Page parent)
        {
            InitializeComponent();
            
            _trainingCourses = _trainingCoursesService.Get();
            _participants = _participantsService.Get();
            DataContext = registrationForCourses;
            _registrationForCourses = registrationForCourses;
            _parent = parent;

            BoxTrainingCourses.ItemsSource = _trainingCourses;
            BoxParticipant.ItemsSource = _participants;
            BoxTrainingCourses.SelectedIndex = _trainingCourses.IndexOf(_trainingCourses.FirstOrDefault(r => r.Id == registrationForCourses.TrainingCoursesId));
            BoxParticipant.SelectedIndex = _participants.IndexOf(_participants.FirstOrDefault(r => r.Id == registrationForCourses.ParticipantsId));
           
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditRegistrationForCourses(Page parent)
        {
            InitializeComponent();
           
            _registrationForCourses = new RegistrationForCourses();
            _participants = _participantsService.Get();
            _trainingCourses = _trainingCoursesService.Get();    
            _parent = parent;

            BoxParticipant.ItemsSource = _participants;
            BoxTrainingCourses.ItemsSource = _trainingCourses;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _registrationForCourses);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Create(this, _registrationForCourses);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _registrationForCourses.DateEntry = DateTime.Parse(DateEntry.Text);

            _registrationForCourses.TrainingCoursesId = _trainingCourses.FirstOrDefault(i => i == BoxTrainingCourses.SelectedItem).Id;
            _registrationForCourses.ParticipantsId = _participants.FirstOrDefault(i => i == BoxParticipant.SelectedItem).Id;
        }
        private void OpenParticipants_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxParticipant.Name;

            _parent.NavigationService.Content = new PageAdmMembers(_participants);
        }
        private void OpenCourses_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxTrainingCourses.Name;

            _parent.NavigationService.Content = new PageAdmCourses(_trainingCourses);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
