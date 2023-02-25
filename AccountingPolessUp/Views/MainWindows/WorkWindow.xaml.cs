using AccountingPolessUp.Models;
using AccountingPolessUp.Views;
using AccountingPolessUp.Views.Administration;
using AccountingPolessUp.Views.Information;
using AccountingPolessUp.Views.Menu;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            PreviewKeyDown += WorkWindow_PreviewKeyDown;
            SetCommonUIElementsVisibility();
            MainFrame.Content = new PageProfile(user);
        }
        private void WorkWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var focusedElement = Keyboard.FocusedElement;
            if (focusedElement is TextBox)
                return;
            if (e.Key == Key.Back)
                e.Handled = true;
        }
        private void SetCommonUIElementsVisibility()
        {
            switch (_user.Role.Name)
            {
                case "Admin":
                    Admin.Visibility = Visibility.Visible;
                    break;
                case "GlobalPm":
                case "Director":
                case "DirectorOrganizational":
                    foreach (TreeViewItem item in Admin.Items)
                    {
                        item.Visibility = Visibility.Collapsed;
                        MainDepartments.Visibility = Visibility.Visible;
                        ButtonAdmEducationalPortals.Visibility = Visibility.Collapsed;
                        AppInTheProject.Visibility = Visibility.Collapsed;
                    }

                    if (_user.Role.Name == "DirectorOrganizational")
                    {
                        Courses.Visibility = Visibility.Visible;
                        Participants.Visibility = Visibility.Visible;
                    }
                    if (_user.Role.Name == "GlobalPm")
                    {
                        CommerceProjects.Visibility = Visibility.Visible;
                        Vacancy.Visibility = Visibility.Collapsed;
                        Projects.Visibility = Visibility.Visible;
                        AppInTheProject.Visibility = Visibility.Visible;
                    }
                    break;
                case "LocalPm":
                    foreach (TreeViewItem item in Admin.Items)
                    {
                        item.Visibility = Visibility.Collapsed;
                        CommerceProjects.Visibility = Visibility.Visible;
                    }
                    foreach (TreeViewItem item in CommerceProjects.Items)
                    {
                        item.Visibility = Visibility.Collapsed;
                        Projects.Visibility = Visibility.Visible;
                        StageOfProject.Visibility = Visibility.Visible;
                        AppInTheProject.Visibility = Visibility.Visible;
                    }
                    break;
                default:
                    Admin.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageSettings();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem button = sender as TreeViewItem;
            switch (button.Name)
            {

                case "ButtonProfile":
                    MainFrame.Content = new PageProfile(_user);
                    break;
                case "ButtonPositions":
                    MainFrame.Content = new PagePositions();
                    break;
                case "ButtonMentor":
                    MainFrame.Content = new PageMentor();
                    break;
                case "ButtonEmployment":
                    MainFrame.Content = new PageEmployment();
                    break;
                case "ButtonProjects":
                    MainFrame.Content = new PageProjects();
                    break;
                case "ButtonInfoRules":
                    MainFrame.Content = new PageInfoRules();
                    break;
                case "ButtonInfoPositiones":
                    MainFrame.Content = new PageInfoPositions();
                    break;
                case "ButtonInfoСourses":
                    MainFrame.Content = new PageInfoСourses();
                    break;
                case "ButtonInfoBonus":
                    MainFrame.Content = new PageInfoBonus();
                    break;
                case "ButtonInfoDepartments":
                    MainFrame.Content = new PageInfoDepartments();
                    break;
                case "ButtonInfoRanks":
                    MainFrame.Content = new PageInfoRanks();
                    break;
                case "ButtonInfoPositions":
                    MainFrame.Content = new PageInfoPositions();
                    break;
                case "ButtonAdmRules":
                    MainFrame.Content = new PageAdmRules();
                    break;
                case "ButtonAdmDepartments":
                    MainFrame.Content = new PageAdmDepartments();
                    break;
                case "AppInTheProject":
                    MainFrame.Content = new PageAdmAppInTheProject();
                    break;
                case "ButtonAdmPositiones":
                    MainFrame.Content = new PageInfoPositions();
                    break;
                case "ButtonAdmCourses":
                    MainFrame.Content = new PageAdmCourses();
                    break;
                case "ButtonAdmRanks":
                    MainFrame.Content = new PageAdmRanks();
                    break;
                case "ButtonAdmWork":
                    MainFrame.Content = new PageAdmWork();
                    break;
                case "ButtonAdmStudents":
                    MainFrame.Content = new PageAdmStudents();
                    break;
                case "ButtonAdmRegistrationForCourses":
                    MainFrame.Content = new PageAdmRegistrationForCourses();
                    break;
                case "StageOfProject":
                    MainFrame.Content = new PageAdmStageOfProject();
                    break;
                case "ButtonAdmNatural":
                    MainFrame.Content = new PageAdmNatural();
                    break;
                case "Projects":
                    MainFrame.Content = new PageAdmProjects();
                    break;
                case "ButtonAdmOrganization":
                    MainFrame.Content = new PageAdmOrganizations();
                    break;
                case "ButtonAdmUsers":
                    MainFrame.Content = new PageAdmUsers();
                    break;
                case "ButtonAdmMembers":
                    MainFrame.Content = new PageAdmMembers();
                    break;
                case "ButtonAdmBonus":
                    MainFrame.Content = new PageAdmBonus();
                    break;
                case "ButtonAdmCustomer":
                    MainFrame.Content = new PageAdmCustomer();
                    break;
                case "ButtonAdmEducationalPortals":
                    MainFrame.Content = new PageAdmEducationalPortals();
                    break;
                case "ButtonAdmPosition":
                    MainFrame.Content = new PageAdmPosition();
                    break;
                case "Departments":
                    MainFrame.Content = new PageAdmDepartments();
                    break;
                case "Vacancy":
                    MainFrame.Content = new PageAdmVacancy();
                    break;
                case "ButtonAdmSchedule":
                    MainFrame.Content = new PageAdmScheduleOfClasses();
                    break;
                case "ButtonAdmFinalProjects":
                    MainFrame.Content = new PageAdmFinalProject();
                    break;
            }
        }
    }
}
