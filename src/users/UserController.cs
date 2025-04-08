
// /api/user/{id}
using backend_agendeFacil.Data;
using backend_agendeFacil.src.model.tenant;

namespace backend_agendeFacil.src.users
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


    }
}