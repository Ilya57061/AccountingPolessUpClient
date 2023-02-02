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
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            this.user = user;
            DataContext = user;
            BoxIsAdmin.SelectedIndex = user.IsAdmin == true ? 0 : 1;
            BoxIsGlobalPM.SelectedIndex = user.isGlobalPM == true ? 0 : 1;
        }
        public PageEditUser()
        {
            InitializeComponent();
            this.user = new User();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
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
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
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
            user.Password = Password.Password;
            user.IsAdmin = bool.Parse(BoxIsAdmin.Text);
            user.isGlobalPM = bool.Parse(BoxIsGlobalPM.Text);
        }
    }
}
