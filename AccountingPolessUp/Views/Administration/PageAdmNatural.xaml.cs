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
    /// Логика взаимодействия для PageAdmNatural.xaml
    /// </summary>
    public partial class PageAdmNatural : Page
    {
        IndividualsService _individualsService = new IndividualsService();
        public PageAdmNatural()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _individualsService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Individuals user = dataGrid.SelectedItems[i] as Individuals;
                    if (user != null)
                    {
                        _individualsService.Delete(user.Id);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageAddNatural();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Individuals individual = dataGrid.SelectedItems[i] as Individuals;
                if (individual != null)
                {
                    EditFrame.Content = new PageEditNatural(individual);

                }
            }
        }
    }
}
