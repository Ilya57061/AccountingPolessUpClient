﻿using AccountingPolessUp.Implementations;
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
    /// Логика взаимодействия для PageEditUser.xaml
    /// </summary>
    public partial class PageEditUser : Page
    {
        UserService _userService = new UserService();
        User user;
        public PageEditUser(User user)
        {
            InitializeComponent();
            this.user = user;
            DataContext = user;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            user.Login = Login.Text;
            user.Password = Password.Password;
            user.IsAdmin = bool.Parse(BoxIsAdmin.Text);
            _userService.Update(user);
        }
    }
}