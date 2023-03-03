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
        private UserService _userService = new UserService();
        private RoleService _roleService = new RoleService();

        private List<Role> roles;
        private User _user;
        private Page _parent;

        public PageEditUser(User user, Page parent)
        {
            InitializeComponent();
            FillDataContext(user);

            _parent = parent;

            ButtonSaveEdit.Visibility = Visibility.Visible;

            Password.IsEnabled = false;
        }
        public PageEditUser(User user, bool changePassword, Page parent)
        {
            InitializeComponent();
            FillDataContext(user);

            _parent = parent;
            
            ButtonEditPassword.Visibility = Visibility.Visible;

            Login.IsEnabled = false;
            BoxRole.IsEnabled = false;
        }
        public PageEditUser(Page parent)
        {
            InitializeComponent();
            CheckRole();

            _user = new User();
            _parent = parent;

            BoxRole.ItemsSource = roles;
            BoxRole.SelectedIndex = roles.IndexOf(roles.FirstOrDefault(x => x.Id == _user.RoleId));
            
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void FillDataContext(User user)
        {
            CheckRole();

            _user = user;
            DataContext = user;

            BoxRole.ItemsSource = roles;
            BoxRole.SelectedIndex = roles.IndexOf(roles.FirstOrDefault(x => x.Id == user.RoleId));
        }
        private void CheckRole()
        {
            roles = _roleService.Get();

            if (RoleValidator.User.Role.Name != "Admin")
                roles = roles.Where(x => x.Name == "User").ToList();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _user);
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

                RegisterDto registerDto = new RegisterDto
                {
                    Login = Login.Text,
                    Password = Password.Password,
                    RoleId = roles.FirstOrDefault(x => x == BoxRole.SelectedItem).Id
                };

                _userService.Create(registerDto);
                DataGridUpdater.AdmUsers.UpdateDataGrid();
                CancelFrameChecker.CreateData = true;
                MessageBox.Show("Пользователь добавлен!");
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

                UpdatePasswordDto upPassword = new UpdatePasswordDto
                {
                    Id = _user.Id,
                    Password = Password.Password
                };

                _userService.UpdatePassword(upPassword);
                DataGridUpdater.AdmUsers.UpdateDataGrid();
                NavigationService.GoBack();
                MessageBox.Show("Пароль изменен!");
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _user.Login = Login.Text;
            _user.RoleId = roles.FirstOrDefault(x => x == BoxRole.SelectedItem).Id;
        }
    }
}
