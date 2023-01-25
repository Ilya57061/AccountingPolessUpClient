﻿using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Логика взаимодействия для PageEditStudents.xaml
    /// </summary>
    public partial class PageEditStudents : Page
    {
        StudentService _studentService = new StudentService();
        IndividualsService _individualsService=new IndividualsService();
        List<Individuals> _individuals;
        Student _student;
        public PageEditStudents(Student student)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _student = student;
            DataContext = student;
            _individuals = _individualsService.Get();
            BoxIndividuals.SelectedIndex = _individuals.IndexOf(_individuals.FirstOrDefault(p => p.Id == student.IndividualsId));
        }
        public PageEditStudents()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _student = new Student();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
           WriteData();
            _studentService.Update(_student);
         
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _studentService.Create(_student);
        }
        private void WriteData()
        {
            _student.StudentCard = long.Parse(StudentCard.Text);
            _student.Group = Group.Text;
            _student.IndividualsId= _individuals.FirstOrDefault(i => i == BoxIndividuals.SelectedItem).Id;
            _student.CourseNumber = int.Parse(CourseNumber.Text);
            _student.University=University.Text;
        }
    }
}