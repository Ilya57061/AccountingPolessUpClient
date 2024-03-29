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
    /// Interaction logic for PageEditScheduleOfClasses.xaml
    /// </summary>
    public partial class PageEditScheduleOfClasses : Page
    {
        

        ScheduleOfClassesService _scheduleService = new ScheduleOfClassesService();
        TrainingCoursesService _trainingCoursesService = new TrainingCoursesService();

        Page _parent;
        List<TrainingCourses> _trainingCourses;
        ScheduleOfСlasses _schedule;

        public PageEditScheduleOfClasses(ScheduleOfСlasses schedule, Page parent)
        {
            InitializeComponent();
            
            _trainingCourses = _trainingCoursesService.Get();
            DataContext = schedule;
            _schedule = schedule;
            _parent = parent;

            BoxTrainingCourses.ItemsSource = _trainingCourses;
            BoxTrainingCourses.SelectedIndex = _trainingCourses.IndexOf(_trainingCourses.FirstOrDefault(r => r.Id == schedule.TrainingCoursesId));
           

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
        }
        public PageEditScheduleOfClasses(Page parent)
        {
            InitializeComponent();

            _schedule = new ScheduleOfСlasses();
            _trainingCourses = _trainingCoursesService.Get();
            _parent = parent;

            BoxTrainingCourses.ItemsSource = _trainingCourses;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void OpenCourses_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxTrainingCourses.Name;

            _parent.NavigationService.Content = new PageAdmCourses(_trainingCourses);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _schedule);
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
                DataAccess.Create(this, _schedule);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _schedule.Description = Description.Text;
            _schedule.WorkSpaceLink = WorkSpaceLink.Text;

            _schedule.TrainingCoursesId = _trainingCourses.FirstOrDefault(i => i == BoxTrainingCourses.SelectedItem).Id;

            _schedule.DateStart = DateTime.Parse(DateStart.Text);
            _schedule.DateEnd = DateTime.Parse(DateEnd.Text);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
