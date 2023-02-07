using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditUser.xaml
    /// </summary>
    public partial class PageEditUser : Page
    {
        Page _parent;
        UserService _userService = new UserService();
        RoleService _roleService = new RoleService();
        List<Role> roles;
        User user;

        public PageEditUser(User user, Page parent)
        {
            InitializeComponent();
            Password.IsEnabled = false;
            FillDataContext(user);
            ButtonSaveEdit.Visibility = Visibility.Visible;
            _parent = parent;
        }
        public PageEditUser(User user, bool changePassword, Page parent)
        {
            InitializeComponent();
            _parent = parent;
            FillDataContext(user);
            ButtonEditPassword.Visibility = Visibility.Visible;
            Login.IsEnabled = false;
            BoxRole.IsEnabled = false;
        }
        public PageEditUser(Page parent)
        {
            InitializeComponent();
            this.user = new User();
            ButtonAdd.Visibility = Visibility.Visible;
            roles = _roleService.Get();
            BoxRole.ItemsSource = roles;
            BoxRole.SelectedIndex = roles.IndexOf(roles.FirstOrDefault(x => x.Id == user.RoleId));
            _parent = parent;
        }
        private void FillDataContext(User user)
        {
            this.user = user;
            DataContext = user;
            roles = _roleService.Get();
            BoxRole.ItemsSource = roles;
            BoxRole.SelectedIndex = roles.IndexOf(roles.FirstOrDefault(x => x.Id == user.RoleId));
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.ElementsFilledUpdateUser(this))
                    throw new Exception();
                _userService.Update(user);
                DataGridUpdater.UpdateDataGrid(_userService.Get(), _parent);
                this.NavigationService.GoBack();
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
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                RegisterDto registerDto = new RegisterDto();
                registerDto.Login = Login.Text;
                registerDto.Password = Password.Password;
                registerDto.RoleId = roles.FirstOrDefault(x => x == BoxRole.SelectedItem).Id;
                _userService.Create(registerDto);
                DataGridUpdater.UpdateDataGrid(_userService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void ButtonEditPassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Password.Password))
                    throw new Exception();

                UpdatePasswordDto upPassword = new UpdatePasswordDto();
                upPassword.Id = user.Id;
                upPassword.Password = Password.Password;
                _userService.UpdatePassword(upPassword);
                DataGridUpdater.UpdateDataGrid(_userService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void WriteData()
        {
            user.Login = Login.Text;
            user.RoleId = roles.FirstOrDefault(x => x == BoxRole.SelectedItem).Id;
        }

    }
}
