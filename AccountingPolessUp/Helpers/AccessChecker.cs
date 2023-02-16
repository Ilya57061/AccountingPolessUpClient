using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Helpers
{
    public static class AccessChecker
    {
        private static EmploymentService _employmentService = new EmploymentService();

        public static int ApplicationsInTheProjectCheck(int participantId)
        {
            return (int)_employmentService.GetByParticipants(participantId).Position.Department.DirectorId;
        }
    }
}
