
namespace backend_agendeFacil.src.model.tenant
{
    public class TenantResponseDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<string> Procedures { get; set; } = [];
    }
}