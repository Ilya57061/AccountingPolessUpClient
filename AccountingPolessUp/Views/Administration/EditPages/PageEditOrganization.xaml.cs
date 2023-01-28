﻿using AccountingPolessUp.Helpers;
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
    /// Логика взаимодействия для PageEditOrganization.xaml
    /// </summary>
    public partial class PageEditOrganization : Page
    {

        FormValidator validator = new FormValidator();
        OrganizationService _organizationService = new OrganizationService();
        Organization _organization;
        public PageEditOrganization(Organization organization)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _organization = organization;
            DataContext = organization;
        }
        public PageEditOrganization()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _organization= new Organization();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _organizationService.Update(_organization);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _organizationService.Create(_organization);
        }
        private void WriteData()
        {
            _organization.Fullname = FullName.Text;
            _organization.Address= Address.Text;
            _organization.Contacts=Contacts.Text;
            _organization.WebSite = Website.Text;
            _organization.FoundationDate = DateTime.Parse(FoundationDate.Text);
        }
    }
}
