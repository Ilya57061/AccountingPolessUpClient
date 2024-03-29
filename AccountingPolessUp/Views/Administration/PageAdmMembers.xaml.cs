﻿using AccountingPolessUp.Helpers;
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
    /// Логика взаимодействия для PageAdmMembers.xaml
    /// </summary>

    public partial class PageAdmMembers : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        List<Participants> _participants;
        public PageAdmMembers()
        {
            InitializeComponent();
            DataGridUpdater.AdmMembers = this;
            UpdateDataGrid();
            FilterComboBox.SetBoxUsers(BoxUser);
            FilterComboBox.SetBoxIndividuals(BoxIndividuals);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmMembers(List<Participants> participants)
        {
            InitializeComponent();
            DataGridUpdater.AdmMembers = this;
            ColumSelect.Visibility = Visibility.Visible;
            _participants = participants;
            ButtonAdd.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxUsers(BoxUser);
            FilterComboBox.SetBoxIndividuals(BoxIndividuals);
            UpdateDataGrid();
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        public void UpdateDataGrid()
        {
            _participants = _participantsService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                _participants = _participants.Where(x => x.User.Role.Name == "User").ToList();
            DataGridUpdater.UpdateDataGrid(_participants, this);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Participants participants = dataGrid.SelectedItems[i] as Participants;
                    if (participants != null)
                        _participantsService.Delete(participants.Id);
                }
            }
            UpdateDataGrid();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Participants participant = dataGrid.SelectedItems[i] as Participants;
                DataNavigator.UpdateValueComboBox(_participants.FirstOrDefault(x => x.Id == participant.Id));
            }
            this.NavigationService.GoBack();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditMembers(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Participants participants = dataGrid.SelectedItems[i] as Participants;
                if (participants != null)
                {
                    EditFrame.Content = new PageEditMembers(participants, this);
                    ButtonCancel.Visibility = Visibility.Visible;
                }
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _participants, BoxIndividuals.Text, Mmr.Text, BoxUser.Text, DateEntry.Text, DateExit.Text, BoxStatus.Text, GitHub.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
