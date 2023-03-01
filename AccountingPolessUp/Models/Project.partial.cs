using AccountingPolessUp.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace AccountingPolessUp.Models
{
    public partial class Project
    {
        static ParticipantsService _participantsService = new ParticipantsService();
        static List<Participants> participants = _participantsService.Get();

        public string nameLocalPM
        {
            get
            {
                var localPM = participants.FirstOrDefault(x => x.Id == idLocalPM);
                return localPM?.Individuals.FIO ?? string.Empty;
            }
        }
    }
}
