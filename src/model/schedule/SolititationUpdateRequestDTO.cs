
namespace backend_agendeFacil.src.model.schedule
{
    public class SolititationUpdateRequestDTO
    {
        public required Guid ScheduleId { get; set; }
        public required string Status { get; set; } // ENUM
    }
}