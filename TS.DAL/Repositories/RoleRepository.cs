using System;
using System.Collections.Generic;
using System.Text;
using TS.DAL.Models;

namespace TS.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(TicketSupportContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {

        }
    }
}
