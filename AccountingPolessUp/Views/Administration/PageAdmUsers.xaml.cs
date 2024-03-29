﻿using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmUsers(List<User> users)
        {
            InitializeComponent();
            ColumSelect.Visibility = Visibility.Visible;
            _users = users;
            UpdateDataGrid();
            FilterComboBox.SetBoxRole(BoxRole);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public void UpdateDataGrid()
        {

            _users = _userService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                _users = _users.Where(x => x.Role.Name == "User").ToList();
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
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEditPassword_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditUser(user, true, this);
                ButtonCancel.Visibility = Visibility.Visible;
                break;
            }
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditUser(user, this);
                ButtonCancel.Visibility = Visibility.Visible;
                break;
            }
        }
    }
}
