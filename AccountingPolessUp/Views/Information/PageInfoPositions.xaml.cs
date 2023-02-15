using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoPositions.xaml
    /// </summary>
    public partial class PageInfoPositions : Page
    {
        private readonly PositionService _positionService = new PositionService();
        public ObservableCollection<Position> Positions { get; set; }
        public PageInfoPositions()
        {
            InitializeComponent();
            Positions= new ObservableCollection<Position>(_positionService.Get());
            DataContext = Positions;
            FilterComboBox.SetBoxDepartments(BoxDepartment);
        }
        public PageInfoPositions(int departmentId)
        {
            InitializeComponent();
            ButtonBack.Visibility = Visibility.Visible;
            Positions = new ObservableCollection<Position>(_positionService.Get(departmentId));
            DataContext = Positions;
            FilterComboBox.SetBoxDepartments(BoxDepartment);
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(this, Positions, FullName.Text, Description.Text, BoxDepartment.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(filter);
            DataContext = Positions;
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}
