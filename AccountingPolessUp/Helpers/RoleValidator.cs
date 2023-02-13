using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Helpers
{
    public static class RoleValidator
    {
        static ParticipantsService _participantsService = new ParticipantsService();
        public static User User { get; set; }

        public static bool RoleChecker(int id) //check department,position
        {
            Participants participant  = _participantsService.GetByUser(User.Id);

            if (User.Role.Name == "Admin")
                return true;
            else if (participant.Id == id)
                return true;
            return false;
        }
        public static bool CheckerLocalPM()
        {
            Participants participant = _participantsService.GetByUser(User.Id);
            if (User.Role.Name == "LocalPM" || User.Role.Name =="Admin")
            { 
                return true;
            }
            return false;
        }
    }
}
