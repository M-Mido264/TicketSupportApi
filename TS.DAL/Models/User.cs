using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TS.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public byte[] Salt { get; set; }
        public byte[] HashedPassword { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int TicketId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public User()
        {
            Tickets = new Collection<Ticket>();
        }

    }

   
}
