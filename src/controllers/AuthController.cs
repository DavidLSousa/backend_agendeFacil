
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

            var tenant = _context.Tenants.FirstOrDefault(t => t.Email == data.Email);
            if (tenant == null) { return Results.NotFound("Profissional nao encontrado."); }

            var token = tokenService.GenerateToken(tenant);

            return Results.Json(new { token, tenantId = tenant.Id }, statusCode: 200);
            // return Results.Json(new { token }).WithHeader("Authorization", $"Bearer {token}");
        }
    }
}