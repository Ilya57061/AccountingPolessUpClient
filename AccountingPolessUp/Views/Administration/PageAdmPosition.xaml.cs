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
    /// Логика взаимодействия для PageAdmPosition.xaml
    /// </summary>
    public partial class PageAdmPosition : Page
    {
        PositionService _positionService = new PositionService();
        public PageAdmPosition()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_positionService.Get(), this);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Position position = dataGrid.SelectedItems[i] as Position;
                    if (position != null)
                    {
                        _positionService.Delete(position.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_positionService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditPosition(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Position position = dataGrid.SelectedItems[i] as Position;
                if (position != null)
                {
                    EditFrame.Content = new PageEditPosition(position, this);

                }
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
