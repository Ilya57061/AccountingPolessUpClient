using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.ViewModels;
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
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Settings
{
    /// <summary>
    /// Логика взаимодействия для PageChangePassword.xaml
    /// </summary>
    public partial class PageSecurity : Page
    {
        private UserService _userService = new UserService();
        public PageSecurity()
        {
            InitializeComponent();
        }
        private void FlipperFront_Click(object sender, RoutedEventArgs e)
        {
            Flipper.Height = 256;
        }
        private void FlipperBack_Click(object sender, RoutedEventArgs e)
        {
            Flipper.Height = 50;
        }
        private void ButtonChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Password.Password == RepeatPassword.Password && !string.IsNullOrEmpty(Password.Password))
                {
                    _userService.UpdatePassword(new UpdatePasswordDto { Id = RoleValidator.User.Id, Password = Password.Password });
                    ButtonChangePassword.Background = new SolidColorBrush(Color.FromRgb(156, 204, 101));
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка");
                }
            }
            catch (Exception)
            {
               
            }
            
        }
    }
}
