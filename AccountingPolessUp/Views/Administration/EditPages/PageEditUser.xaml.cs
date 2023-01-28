using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        FormValidator validator = new FormValidator();
        UserService _userService = new UserService();
        User user;
        public PageEditUser(User user)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            this.user = user;
            DataContext = user;
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
                if (validator.AreAllElementsFilled(this))
                    throw new Exception();
                _userService.Update(user);
            }
            catch (Exception)
            {

                MessageBox.Show("Заполните все поля");
            }
         
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (validator.AreAllElementsFilled(this))
                    throw new Exception();
                _userService.Create(user);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля");
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
