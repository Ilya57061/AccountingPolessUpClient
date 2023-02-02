using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
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

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmUsers.xaml
    /// </summary>
    public partial class PageAdmUsers : Page
    {
        UserService _userService = new UserService();
        public PageAdmUsers()
        {
            InitializeComponent();
            DataGridUpdater.Page = this;
           DataGridUpdater.UpdateDataGrid(_userService.Get());
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    User user = dataGrid.SelectedItems[i] as User;
                    if (user != null)
                    {
                        _userService.Delete(user.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_userService.Get());
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditUser();
        }
        private void ButtonEditPassword_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                User user = dataGrid.SelectedItems[i] as User;
                if (user != null)
                {
                    EditFrame.Content = new PageEditUser(user, true);

                }
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                User user = dataGrid.SelectedItems[i] as User;
                if (user != null)
                {
                    EditFrame.Content = new PageEditUser(user);

                }
            }
        }
    }
}
