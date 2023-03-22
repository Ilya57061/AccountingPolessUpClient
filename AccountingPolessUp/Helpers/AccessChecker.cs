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
            var directorId = _employmentService.GetByParticipants(participantId).Position.Department.DirectorId ?? -1;

            return directorId;
        }

        public static bool AccessDeleteButton()
        {
            return AccessRoles();
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

                default: return AccessRoles();
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

                default: return AccessRoles();
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

        private static bool AccessRoles()
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
    }
}
