using backend_agendeFacil.src.model.schedule;
using backend_agendeFacil.src.model.tenant;
using Microsoft.EntityFrameworkCore;

namespace backend_agendeFacil.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}