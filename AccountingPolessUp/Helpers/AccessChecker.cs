using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                    if (page.Title== "PageAdmVacancy")
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
                int count = VisualTreeHelper.GetChildrenCount(page);

                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(page, i);

                    if (child is Button && (child as Button).Content.ToString().StartsWith("Open"))
                    {
                        (child as Button).Visibility = Visibility.Hidden;
                    }

                }
            }
        }
    }
}
