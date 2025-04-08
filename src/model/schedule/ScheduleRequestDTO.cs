
using backend_agendeFacil.src.model.users;

namespace backend_agendeFacil.src.model.schedule
{
    public class ScheduleRequestDTO
    {
        public required string Procedure { get; set; }
        public required DateTime Date { get; set; }
        public required TimeSpan Time { get; set; }
        public SolicitationStatus Status { get; set; } = SolicitationStatus.PENDING; // ENUM
        public required UserDTO User { get; set; }
    }
}