using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;

namespace AccountingPolessUp.Helpers
{
    public static class RoleValidator
    {
        private static ParticipantsService _participantsService = new ParticipantsService();
        private static Participants _participant;
        public static User User { get; set; }
        public static bool RoleChecker(int id)
        {
            _participant = _participantsService.GetByUser(User.Id);
            if (User.Role.Name == "Admin")
                return true;
            else if (_participant.Id == id)
                return true;
            return false;
        }

    }
}
