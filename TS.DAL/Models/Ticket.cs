using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TS.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastStatusChanges { get; set; }
        public string Content { get; set; }
        public Status Status { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

    }
}
