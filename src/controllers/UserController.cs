using System.Text.Json;
using backend_agendeFacil.Data;
using backend_agendeFacil.src.model.schedule;
using backend_agendeFacil.src.model.tenant;
using backend_agendeFacil.src.model.users;

namespace backend_agendeFacil.src.controllers
{
    public class UserController(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<IResult> GetInfoTenantAsync(Guid id)
        {

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null) { return Results.NotFound("Profissional não encontrado."); }

            var tenantDTO = new TenantResponseDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Procedures = tenant.Procedures
            };
            return Results.Json(tenantDTO, statusCode: 200);
        }

        public async Task<IResult> CreateSolicitation(Guid id, HttpRequest request)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
                return Results.NotFound("Profissional não encontrado.");

            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();

            var data = JsonSerializer.Deserialize<ScheduleRequestDTO>(body);
            if (data == null) return Results.BadRequest("Dados inválidos no body.");

            var newSolicitation = new Schedule
            {
                TenantId = tenant.Id,
                Procedure = data.Procedure,
                Date = DateTime.SpecifyKind(data.Date, DateTimeKind.Utc),
                Time = data.Time,
                Status = SolicitationStatus.PENDING,
                User = new UserDTO
                {
                    Name = data.User.Name,
                    Email = data.User.Email,
                    Phone = data.User.Phone
                }
            };

            _context.Schedules.Add(newSolicitation);
            await _context.SaveChangesAsync();

            return Results.Json(new {body = "Solicitação criada com sucesso!"}, statusCode: 201);
        }
    }
}