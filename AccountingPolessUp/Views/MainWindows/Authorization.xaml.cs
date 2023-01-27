using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        LoginService loginService = new LoginService();
        public Authorization()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(Login.Text)) throw new Exception("Неверный логин");
                if(string.IsNullOrEmpty(Password.Password)) throw new Exception("Неверный пароль");
                User user = loginService.Login(new LoginModel { Login = Login.Text, Password = Password.Password });
                if (user ==null)
                {
                    throw new Exception("Некорректные логин и(или) пароль");
                }
                else
                {
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
    }
}
