
namespace backend_agendeFacil
{
    public static class Routers
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/", () => "Hello World!");
            app.MapGet("/api", () => "Api");
        }
    }
}