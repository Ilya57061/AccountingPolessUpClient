using AccountingPolessUp.Views.Administration;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataGridUpdater
    {
        public static PageAdmAppInTheProject AdmAppInTheProject { get; set; }
        public static PageAdmBonus AdmBonus { get; set; }
        public static PageAdmCourses AdmCourses { get; set; }
        public static PageAdmCustomer AdmCustomer { get; set; }
        public static PageAdmDepartments AdmDepartments { get; set; }
        public static PageAdmEducationalPortals AdmEducationalPortals { get; set; }
        public static PageAdmFinalProject AdmFinalProject { get; set; }
        public static PageAdmMembers AdmMembers { get; set; }
        public static PageAdmNatural AdmNatural { get; set; }
        public static PageAdmOrganizations AdmOrganizations { get; set; }
        public static PageAdmPosition AdmPosition { get; set; }
        public static PageAdmProjects AdmProjects { get; set; }
        public static PageAdmRanks AdmRanks { get; set; }
        public static PageAdmRegistrationForCourses AdmRegistrationForCourses { get; set; }
        public static PageAdmRules AdmRules { get; set; }
        public static PageAdmScheduleOfClasses AdmScheduleOfClasses { get; set; }
        public static PageAdmStageOfProject AdmStageOfProject { get; set; }
        public static PageAdmStudents AdmStudents { get; set; }
        public static PageAdmUsers AdmUsers { get; set; }
        public static PageAdmVacancy AdmVacancy { get; set; }
        public static PageAdmWork AdmWork { get; set; }


        public static void UpdateDataGrid(object data, Page page)
        {
            var dataGrid = page.FindName("dataGrid") as DataGrid;
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = (System.Collections.IEnumerable)data;
        }

    }
}
