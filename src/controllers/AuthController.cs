
using System.Text.Json;
using backend_agendeFacil.Data;
using backend_agendeFacil.src.model.tenant;
using backend_agendeFacil.src.services;

namespace backend_agendeFacil.src.controllers
{
    public class AuthController(AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        public async Task<IResult> Login(HttpRequest request, TokenService tokenService)
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            var data = JsonSerializer.Deserialize<LoginRequestDTO>(body);

            if (data == null) return Results.BadRequest("Dados de login inválidos.");

            var tenant = _context.Tenants.FirstOrDefault(t => t.Email == data.Email);
            if (tenant == null) { return Results.NotFound("Profissional nao encontrado."); }

            var token = tokenService.GenerateToken(tenant);

            var tenantDTO = new TenantResponseDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Procedures = tenant.Procedures
            };

            return Results.Json(new { token, tenantDTO }, statusCode: 200);
        }
    }
}