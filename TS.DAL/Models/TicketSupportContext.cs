using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TS.DAL.Models
{
    public class TicketSupportContext : DbContext
    {
        public TicketSupportContext(DbContextOptions<TicketSupportContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
