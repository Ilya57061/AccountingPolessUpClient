using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            DataGridUpdater.AdmUsers = this;
            FilterComboBox.SetBoxRole(BoxRole);
            UpdateDataGrid();
        }
        public PageAdmUsers(List<User> users)
        {
            InitializeComponent();
            ColumSelect.Visibility = Visibility.Visible;
            _users = users;
            UpdateDataGrid();
            FilterComboBox.SetBoxRole(BoxRole);
        }
        public void UpdateDataGrid()
        {
            _users = _userService.Get();
            DataGridUpdater.UpdateDataGrid(_users, this);
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _users, Login.Text, BoxRole.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_users.FirstOrDefault(x => x.Id == user.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (User user in dataGrid.SelectedItems)
                {
                    _userService.Delete(user.Id);
                }
            }
            UpdateDataGrid();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditUser(this);
        }
        private void ButtonEditPassword_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditUser(user, true, this);
                break;
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditUser(user, this);
                break;
            }
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
