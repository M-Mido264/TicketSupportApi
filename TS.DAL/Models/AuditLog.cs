using System;
using System.Collections.Generic;
using System.Text;

namespace TS.DAL.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime DateTime { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
    }
}
