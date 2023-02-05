using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditRules.xaml
    /// </summary>
    public partial class PageEditRules : Page
    {

        Page _parent;
        RegulationService _regulationService = new RegulationService();
        OrganizationService _organizationService=new OrganizationService();
        List<Organization> _organizations;
        Regulation _regulation;
        public PageEditRules(Regulation regulation, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _regulation = regulation;
            DataContext = regulation;
            _organizations = _organizationService.Get();
            BoxOrganization.ItemsSource = _organizations;
            BoxOrganization.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o => o.Id == regulation.OrganizationId));
            _parent = parent;
        }
        public PageEditRules(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _regulation = new Regulation();
            _organizations = _organizationService.Get();
            BoxOrganization.ItemsSource = _organizations;
            _parent = parent;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _regulationService.Update(_regulation);
                DataGridUpdater.UpdateDataGrid(_regulationService.Get(),_parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _regulationService.Create(_regulation);
                DataGridUpdater.UpdateDataGrid(_regulationService.Get(),_parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void OpenRegulation_Click(object sender, RoutedEventArgs e)
        {
        }
        private void WriteData()
        {
            _regulation.Text = Text.Text;
            _regulation.Name = Name.Text;
            _regulation.Description = Description.Text;
            _regulation.OrganizationId = _organizations.FirstOrDefault(i=>i==BoxOrganization.SelectedItem).Id;
        }
    }
}
