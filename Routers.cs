

using backend_agendeFacil.src.controllers;
using backend_agendeFacil.src.services;

namespace backend_agendeFacil
{
    public static class Routers
    {
        public static void Map(WebApplication app)
        {
            // Auth
            var authGroup = app.MapGroup("/api/auth");
            authGroup.MapPost("/login", 
                async (HttpRequest resquest, AuthController controller) => {
                    var tokenService = new TokenService();
                    return await controller.Login(resquest, tokenService);
                })
                .AllowAnonymous();

            // Tenant
            var tenantGroup = app.MapGroup("/api/{id:guid}");
            tenantGroup.MapGet("/schedule", 
                async (Guid id, ScheduleController controller) => {
                    return await controller.GetSchedule(id);
                })
                .RequireAuthorization();
            tenantGroup.MapGet("/solicitations", 
                async (Guid id, ScheduleController controller) => {
                    return await controller.GetSolicitations(id);
                })
                .RequireAuthorization();
            tenantGroup.MapPut("/solicitations", 
                async (Guid id, Guid scheduleId, string status, ScheduleController controller) => {
                    return await controller.UpdateSolicitation(id, scheduleId, status);
                })
                .RequireAuthorization();

            // User
            var userGroup = app.MapGroup("/api/user");
            userGroup.MapGet("/tenants", 
                async (UserController controller) => {
                    return await controller.GetTenantsAsync();
                })
                .AllowAnonymous();
            userGroup.MapGet("/{id:guid}", 
                async (Guid id, UserController controller) => {
                    return await controller.GetInfoTenantAsync(id);
                })
                .AllowAnonymous();
            userGroup.MapPost("/{id:guid}", 
                async (Guid id, HttpRequest request, UserController controller) => {
                    return await controller.CreateSolicitation(id, request);
                })
                .AllowAnonymous();
        }
    }
}