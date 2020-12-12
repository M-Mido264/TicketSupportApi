using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Models;

namespace TS.DAL.Repositories
{
    public class AuditRepository : GenericRepository<AuditLog>
    {
        public AuditRepository(TicketSupportContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
                
        }
        public async Task<List<AuditLog>> GetByIdAsync(int id) => await GetAll().Where(x => x.TicketId == id).ToListAsync();
    }
}
