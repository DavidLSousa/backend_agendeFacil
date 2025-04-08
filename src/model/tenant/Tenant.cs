namespace backend_agendeFacil.src.model.tenant
{
    public class Tenant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }

        public required string Specialty { get; set; }
        public List<string> Procedures { get; set; } = [];
    }
}
