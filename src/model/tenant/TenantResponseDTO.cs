using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_agendeFacil.src.model.tenant
{
    public class TenantResponseDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<string> Procedures { get; set; } = [];
    }
}