using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Helpers;
using TS.DAL.Models;

namespace TS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(TicketSupportContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
                
        }
        public async Task<User> GetUser(string userName,string password)
        {
            var user =  await GetAll().FirstOrDefaultAsync(x => x.UserName == userName);
            if (user != null)
            {
                if (SecurityHelpers.VerifyPasswordHash(password, user.Salt, user.HashedPassword))
                {
                    return user;
                }
                return null;
            }
            else return null;
        }
    }
}
