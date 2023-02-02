using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;


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
            Password.IsEnabled = false;
            FillDataContext(user);
            ButtonSaveEdit.Visibility = Visibility.Visible;
        }
        public PageEditUser(User user, bool changePassword)
        {
            InitializeComponent();
            FillDataContext(user);
            ButtonEditPassword.Visibility = Visibility.Visible;
            Login.IsEnabled = false;
            BoxIsAdmin.IsEnabled = false;
            BoxIsGlobalPM.IsEnabled = false;
       
        }
        public PageEditUser()
        {
            InitializeComponent();
            this.user = new User();
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void FillDataContext(User user)
        {
            this.user = user;
            DataContext = user;
            BoxIsAdmin.SelectedIndex = user.IsAdmin == true ? 0 : 1;
            BoxIsGlobalPM.SelectedIndex = user.isGlobalPM == true ? 0 : 1;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.ElementsFilledUpdateUser(this))
                    throw new Exception();
                _userService.Update(user);
                DataGridUpdater.UpdateDataGrid(_userService.Get());
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
                registerDto.IsAdmin = bool.Parse(BoxIsAdmin.Text);
                registerDto.Password = Password.Password;
                registerDto.isGlobalPM = bool.Parse(BoxIsGlobalPM.Text);
                _userService.Create(registerDto);
                DataGridUpdater.UpdateDataGrid(_userService.Get());
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
                DataGridUpdater.UpdateDataGrid(_userService.Get());
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void WriteData()
        {
            user.Login = Login.Text;
            user.IsAdmin = bool.Parse(BoxIsAdmin.Text);
            user.isGlobalPM = bool.Parse(BoxIsGlobalPM.Text);
        }

    }
}
