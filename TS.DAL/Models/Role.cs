using System;
using System.Collections.Generic;
using System.Text;

namespace TS.DAL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
