using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AccountingPolessUp.Helpers
{
    public static class RoleValidator
    {
        private static ParticipantsService _participantsService = new ParticipantsService();
        private static Participants _participant;
        public static User User { get; set; }

        public static bool RoleChecker(int id) //check department,position
        {
            _participant = _participantsService.GetByUser(User.Id);
            //switch (User.Role.Name)
            //{
            //    case "Admin":
            //        return true;
            //    case "GlobalPm":
            //    case "Director":
            //    case "DirectorOrganizational":
            //        if (_participant.Id == id) return true;
            //        else return false;
            //    case "LocalPm":

            //        break;
            //    default:
            //        break;
            //}
            if (User.Role.Name == "Admin")
                return true;
            else if (_participant.Id == id)
                return true;
            return false;
        }

    }
}
