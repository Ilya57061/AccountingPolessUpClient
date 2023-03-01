using AccountingPolessUp.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace AccountingPolessUp.Models
{
    public partial class Employment
    {
        static ParticipantsService _participantsService = new ParticipantsService();
        static List<Participants> participants = _participantsService.Get();

        public string nameMentor
        {
            get
            {
                var mentor = participants.FirstOrDefault(x => x.Id == IdMentor);
                return mentor?.Individuals.FIO ?? string.Empty;
            }
        }
    }
}
