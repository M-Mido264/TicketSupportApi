using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Models;

namespace TS.DAL.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository(TicketSupportContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {

        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
