using AccountingPolessUp.Implementations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class AccessChecker
    {
        private static EmploymentService _employmentService = new EmploymentService();

        public static int ApplicationsInTheProjectCheck(int participantId)
        {
            return (int)_employmentService.GetByParticipants(participantId).Position.Department.DirectorId;
        }
        public static bool AccessDeleteButton()
        {
            switch (RoleValidator.User.Role.Name)
            {
                case "GlobalPm":
                case "Director":
                case "DirectorOrganizational":
                case "LocalPm":
                    return true;
                default: return false;
            }
        }
        public static bool AccessEditButton(Page page)
        {
            switch (RoleValidator.User.Role.Name)
            {
                case "GlobalPm":
                    if (page.Title == "PageAdmAppInTheProject")
                        return false;
                    else
                        return true;
                case "Director":
                case "DirectorOrganizational":
                case "LocalPm":
                    return true;
                default: return false;
            }
        }
        public static bool AccessAddButton(Page page)
        {
            switch (RoleValidator.User.Role.Name)
            {
                case "GlobalPm":
                    if (page.Title == "PageAdmVacancy" || page.Title == "PageAdmProjects")
                        return false;
                    else
                        return true;
                case "Director":
                case "DirectorOrganizational":
                case "LocalPm":
                    return true;
                default: return false;
            }
        }
        public static void AccessOpenButton(Page page)
        {
            if (RoleValidator.User.Role.Name != "Admin")
            {
                var grid = page.Content as Grid;
                if (grid != null)
                {
                    var childGrid = grid.Children.OfType<Grid>();
                    foreach (var item in childGrid)
                    {
                        var buttonElements = item.Children.OfType<Button>().Where(b => b.Name.StartsWith("Open"));
                        foreach (var button in buttonElements)
                        {
                            button.Visibility = Visibility.Hidden;
                        }
                    }
                   
                }
            }
        }
    }
}
