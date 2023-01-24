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
    /// Логика взаимодействия для PageAdmEducationalPortals.xaml
    /// </summary>
    public partial class PageAdmEducationalPortals : Page
    {
        
        public PageAdmEducationalPortals()
        {
            InitializeComponent();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    EducationalPortals EducationalPortals = dataGrid.SelectedItems[i] as EducationalPortals;
                    if (EducationalPortals != null)
                    {

                        //_educationalPortalsService.Delete(EducationalPortals.Id);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditEducationalPortals();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                EducationalPortals EducationalPortals = dataGrid.SelectedItems[i] as EducationalPortals;
                if (EducationalPortals != null)
                {
                    //EditFrame.Content = new PageEditEducationalPortals(EducationalPortals);

                }
            }
        }
    }
}
