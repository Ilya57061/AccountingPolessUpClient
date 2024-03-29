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
    /// Логика взаимодействия для PageEditFinalProject.xaml
    /// </summary>
    public partial class PageEditFinalProject : Page
    {
        private FinalProjectService _finalProjectService = new FinalProjectService();
        private EmploymentService _employmentService = new EmploymentService();

        private List<Employment> _employments;
        private FinalProject _finalProject;
        private Employment _employment;
        private Page _parent;

        public PageEditFinalProject(FinalProject finalProject, Employment employment, Page parent)
        {
            InitializeComponent();
            SetEmployments();

            _finalProject = finalProject;
            DataContext = finalProject;
            _employment = employment;
            _parent = parent;

            BoxEmployment.SelectedIndex = _employments.IndexOf(_employments.FirstOrDefault(p => p.Id == _finalProject.EmploymentId));

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditFinalProject(Employment employment, Page parent)
        {
            InitializeComponent();
            SetEmployments();

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            _finalProject = new FinalProject();
            _employment = employment;
            _parent = parent;

            AccessChecker.AccessOpenButton(this);
        }
        private void SetEmployments()
        {
            _employments = _employmentService.Get();

            if (RoleValidator.User.Role.Name != "Admin")
                _employments = _employments.Where(x => RoleValidator.RoleChecker((int)x.Position.Department.DirectorId) == true).ToList();

            BoxEmployment.ItemsSource = _employments;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _finalProject);

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
                DataAccess.Create(this, _finalProject);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _finalProject.DateStart = DateTime.Parse(DateStart.Text);
            _finalProject.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            _finalProject.Name = Name.Text;
            _finalProject.Description = Description.Text;
            _finalProject.GitHub = GitHub.Text;
            _finalProject.Links = Links.Text;
            var selectedEmployment = _employments.FirstOrDefault(i => i == BoxEmployment.SelectedItem);
            if (selectedEmployment != null)
                _finalProject.EmploymentId = selectedEmployment.Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        private void OpenEmployment_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxEmployment.Name;
            _parent.NavigationService.Content = new PageAdmWork(_employments);
        }
    }
}
