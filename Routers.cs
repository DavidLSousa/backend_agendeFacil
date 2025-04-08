

using backend_agendeFacil.src.controllers;

namespace backend_agendeFacil
{
    public static class Routers
    {
        public static void Map(WebApplication app)
        {
            // Auth
            var authGroup = app.MapGroup("/api/auth");
            authGroup.MapGet("/login", () => "Login!");

            // Tenant
            var tenantGroup = app.MapGroup("/api/{id}");
            tenantGroup.MapGet("/schedule", () => "Tenant acessa sua agenda");
            tenantGroup.MapGet("/solicitations", () => "Lista de solicitações de agendamento");

            // User
            var userGroup = app.MapGroup("/api/user");
            userGroup.MapGet("/{id:guid}", async (Guid id, UserController controller) => {
                return await controller.GetInfoTenantAsync(id);
            });
            userGroup.MapPost("/{id:guid}", (Guid id, HttpRequest request, UserController controller) => {
                return controller.CreateSolicitation(id, request);
            });    
        }
    }
}