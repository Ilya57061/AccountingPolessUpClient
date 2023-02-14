using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        AuthService loginService = new AuthService();

        public Authorization()
        {
            InitializeComponent();
             Enter.IsEnabled = false;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = loginService.Login(new LoginDto { Login = Login.Text, Password = Password.Password });
                if (user == null)
                {
                    LabelErrorMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    RoleValidator.User = user;
                    WorkWindow mainWindow = new WorkWindow(user);
                    mainWindow.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void CheckChangeText(object sender, RoutedEventArgs e)
        {
            LabelErrorMessage.Visibility = Visibility.Collapsed;

            if (Password.Password.Length > 0 && Login.Text.Length > 0) Enter.IsEnabled = true;
            else Enter.IsEnabled = false;
        }

    }
}
