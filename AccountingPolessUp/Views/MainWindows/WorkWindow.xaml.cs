using AccountingPolessUp.Models;
using AccountingPolessUp.Views;
using AccountingPolessUp.Views.Administration;
using AccountingPolessUp.Views.Information;
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

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        User _user;
        public WorkWindow(User user)
        {
            _user = user;
            InitializeComponent();
            if (user.IsAdmin == true)
            {
                Admin.Visibility = Visibility.Visible;
            }
            else if (user.isGlobalPM == true && user.IsAdmin == false)
            {

                foreach (TreeViewItem item in Admin.Items)
                {
                    item.Visibility = Visibility.Collapsed;
                    // TreeViewItem visible
                    Projects.Visibility= Visibility.Visible;
                    StageOfProject.Visibility= Visibility.Visible;
                    Vacancy.Visibility= Visibility.Visible;
                    AppInTheProject.Visibility= Visibility.Visible;
                }
            }
            else
            {
                Admin.Visibility = Visibility.Hidden;
            }
            MainFrame.Content = new PageProfile(user);

        }
        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageProfile(_user);
        }
        private void ButtonPositions_Click(object sender, RoutedEventArgs e) // вакансии
        {
            MainFrame.Content = new PagePositions();
        }
        private void ButtonMentor_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageMentor();
        }
        private void ButtonEmployment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageEmployment();
        }
        private void ButtonProjects_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageProjects();
        }
        private void ButtonInfoRules_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoRules();
        }
        private void ButtonInfoDepartments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoDepartments();
        }
        private void ButtonInfoPositiones_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoPositions();
        }
        private void ButtonInfoСourses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoСourses();
        }
        private void ButtonInfoBonus_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoBonus();
        }
        private void ButtonInfoRanks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoRanks();
        }
        private void ButtonInfoPositions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoPositions();
        }

        #region Adm
        private void ButtonAdmRules_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmRules();
        }
        private void ButtonAdmDepartments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmDepartments();
        }
        private void ButtonAdmApplications_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmAppInTheProject();
        }
        private void ButtonAdmPositiones_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInfoPositions();
        }
        private void ButtonAdmCourses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmCourses();
        }
        private void ButtonAdmRanks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmRanks();
        }
        private void ButtonAdmWork_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmWork();
        }
        private void ButtonAdmStudents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmStudents();
        } 
        private void ButtonAdmRegistrationForCourses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmRegistrationForCourses();
        } 
        private void ButtonAdmStageOfProject_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmStageOfProject();
        }
        private void ButtonAdmNatural_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmNatural();
        }
        private void ButtonAdmProjects_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmProjects();
        }
        private void ButtonAdmOrganization_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmOrganizations();
        }
        private void ButtonAdmUsers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmUsers();
        }
        private void ButtonAdmMembers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmMembers();
        }
        private void ButtonAdmBonus_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmBonus();
        }
        private void ButtonAdmCustomer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmCustomer();
        }
        private void ButtonAdmEducationalPortals_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmEducationalPortals();
        }
        private void ButtonAdmFinalProject_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmFinalProject();
        }
        private void ButtonAdmPosition_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmPosition();
        }
        private void ButtonAdmVacancy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmVacancy();
        }
        private void ButtonAdmSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageAdmScheduleOfClasses();
        }
        #endregion
    }
}
