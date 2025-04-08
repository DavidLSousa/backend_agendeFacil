
using System.Text.Json;
using backend_agendeFacil.Data;
using backend_agendeFacil.src.model.schedule;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sprache;

namespace backend_agendeFacil.src.controllers
{
    public class ScheduleController(AppDbContext context)
    {
        private readonly AppDbContext _context = context;
        public async Task<IResult> GetSchedule(Guid id)
        {
            var data = await _context.Schedules
                .Where(t => t.TenantId == id && t.Status == SolicitationStatus.CONFIRMED)
                .Include(t => t.User)
                .OrderBy(t => t.Date)
                .ToListAsync();

            return Results.Json(data, statusCode: 200);
        }

        public async Task<IResult> GetSolicitations(Guid id)
        {
            var data = await _context.Schedules
                .Where(t => t.TenantId == id && t.Status == SolicitationStatus.PENDING)
                .Include(t => t.User)
                .OrderBy(t => t.Date)
                .ToListAsync();

            return Results.Json(data, statusCode: 200);
        }

        public async Task<IResult> UpdateSolicitation(Guid id, Guid scheduleId, string status)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null) { return Results.NotFound("Solicitação nao encontrada."); }

            var statusEnum = GetEnumStatus(status);
            if (statusEnum == null) { return Results.BadRequest("Status inválido."); }

            schedule.Status = (SolicitationStatus)statusEnum;

            await _context.SaveChangesAsync();

            return Results.Json(new { message = $"Tenant atualiza sua solicitação - {id}" }, statusCode: 200);
        }

        private static SolicitationStatus? GetEnumStatus(string status)
        {
            if (Enum.TryParse<SolicitationStatus>(status, true, out var parsedStatus))
                return parsedStatus;

            return null; 
        }
    }
}