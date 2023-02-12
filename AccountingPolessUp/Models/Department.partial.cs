using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingPolessUp.Implementations;

namespace AccountingPolessUp.Models
{
    public partial class Department
    {
        static ParticipantsService _participantsService = new ParticipantsService();
        static List<Participants> participants = _participantsService.Get();

        public string nameDirector
        {
            get
            {
                var director = participants.FirstOrDefault(x => x.Id == DirectorId);
                return director?.Individuals.FIO ?? string.Empty;
            }
        }
    }
}
