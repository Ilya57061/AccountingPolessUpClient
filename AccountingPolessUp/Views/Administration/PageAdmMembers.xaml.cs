using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для PageAdmMembers.xaml
    /// </summary>

    public partial class PageAdmMembers : Page
    {
        ParticipantsService _participantsService = new ParticipantsService();
        List<Participants> _participants;
        public PageAdmMembers()
        {
            InitializeComponent();
            UpdateDataGrid();
            FilterComboBox.SetBoxUsers(BoxUser);
        }

        public PageAdmMembers(List<Participants> participants)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _participants = participants;
            ButtonAdd.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxUsers(BoxUser);
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_participantsService.Get(), this);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Participants participants = dataGrid.SelectedItems[i] as Participants;
                    if (participants != null)
                    {
                        _participantsService.Delete(participants.Id);
                    }
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
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Participants participants = dataGrid.SelectedItems[i] as Participants;
                if (participants != null)
                {
                    EditFrame.Content = new PageEditMembers(participants, this);

                }
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _participantsService.Get(), BoxIndividuals.Text, Mmr.Text, BoxUser.Text, DateEntry.Text, DateExit.Text, BoxStatus.Text, GitHub.Text);
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
