

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
            var tenantGroup = app.MapGroup("/api/{id:guid}");
                // Esse id virá do token
                // Acessiveis so quando autenticadas autenticados pelo token JWT
            tenantGroup.MapGet("/schedule", (Guid id, ScheduleController controller) => {
                return controller.GetSchedule(id);
            });
            tenantGroup.MapGet("/solicitations", (Guid id, ScheduleController controller) => {
                return controller.GetSolicitations(id);
            });
            tenantGroup.MapPut("/solicitations", (Guid id, Guid scheduleId, string status, ScheduleController controller) => {
                return controller.UpdateSolicitation(id, scheduleId, status);
            });

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