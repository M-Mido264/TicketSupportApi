using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Helpers;
using TS.DAL.Models;
using TS.DAL.Repositories;

namespace TicketSupport
{
    public class DataSeed
    {
        public static void SeedDefaultCredintials(TicketSupportContext context)
        {
            if (!context.Roles.Any())
            {
                var adminRole = new Role
                {
                    Name = "Administrator",
                };
                context.Roles.Add(adminRole);

                var techRole = new Role
                {
                    Name = "TechnicalTeam",
                };
                context.Roles.Add(techRole);

                var supportRole = new Role
                {
                    Name = "SupportTeam",
                };
                context.Roles.Add(supportRole);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                byte[] passwordHash, passwordSalt;
                SecurityHelpers.CreatePasswordHash("P@ssw0rd", out passwordHash, out passwordSalt);
                var adminUser = new User
                {
                    UserName = "systemAdmin",
                    Name = "Admin",
                    HashedPassword = passwordHash,
                    Salt = passwordSalt,
                    RoleId = 1
                };
                context.Users.Add(adminUser);
                var technicalUser = new User
                {
                    UserName = "technical",
                    Name = "Technical",
                    HashedPassword = passwordHash,
                    Salt = passwordSalt,
                    RoleId = 2
                };
                context.Users.Add(technicalUser);
                var SupportUser = new User
                {
                    UserName = "support",
                    Name = "Support",
                    HashedPassword = passwordHash,
                    Salt = passwordSalt,
                    RoleId = 3
                };
                context.Users.Add(SupportUser);
                context.SaveChanges();
            }
        }
    }
}
