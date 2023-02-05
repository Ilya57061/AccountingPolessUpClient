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
        List<User> _users;
        public PageAdmUsers()
        {
            InitializeComponent();
           DataGridUpdater.UpdateDataGrid(_userService.Get(),this);
        }
        public PageAdmUsers(List<User> users)
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_userService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            _users = users;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                User user = dataGrid.SelectedItems[i] as User;
                DataNavigator.UpdateValueComboBox(_users.FirstOrDefault(x => x.Id == user.Id));
            }

            this.NavigationService.GoBack();
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
            DataGridUpdater.UpdateDataGrid(_userService.Get(),this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditUser(this);
        }
        private void ButtonEditPassword_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                User user = dataGrid.SelectedItems[i] as User;
                if (user != null)
                {
                    EditFrame.Content = new PageEditUser(user, true,this);

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
                    EditFrame.Content = new PageEditUser(user,this);

                }
            }
        }
    }
}
