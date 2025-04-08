
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
            tenantGroup.MapGet("/schedule", (string id) => $"Tenant acessa sua agenda, {id}");
            tenantGroup.MapGet("/solicitations", (string id) => "Lista de solicitações de agendamento");

            // User
            var userGroup = app.MapGroup("/api/user");
            userGroup.MapGet("/{id}", (string id) => "Usuário seleciona tenant");
                // Esse ID é o profissional e esse get retorna infos do profisisonla selecionado;
            userGroup.MapGet("/{id}/solicitation", (string id) => "envio de form para agendamento");    
                // Envio do form para agendamento, o qual deve ser enviado para o tenant;
        }
    }
}