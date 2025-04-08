
namespace backend_agendeFacil.src.model.users
{
    public class UserDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; } 
    }
}