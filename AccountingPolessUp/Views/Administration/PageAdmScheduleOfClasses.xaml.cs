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
    /// Interaction logic for PageAdmScheduleOfClasses.xaml
    /// </summary>
    public partial class PageAdmScheduleOfClasses : Page
    {
        ScheduleOfClassesService _scheduleOfClassesService = new ScheduleOfClassesService();
        public PageAdmScheduleOfClasses()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _scheduleOfClassesService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    ScheduleOfСlasses Schedule = dataGrid.SelectedItems[i] as ScheduleOfСlasses;
                    if (Schedule != null)
                    {
                        _scheduleOfClassesService.Delete(Schedule.Id);
                    }
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageAdmScheduleOfClasses();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                ScheduleOfСlasses Schedule = dataGrid.SelectedItems[i] as ScheduleOfСlasses;
                if (Schedule != null)
                {
                    EditFrame.Content = new PageEditScheduleOfClasses(Schedule);
                }
            }
        }
    }
}
