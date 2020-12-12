using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Models;
using TS.DAL.Repositories;

namespace TS.BL
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUserByCredentials(string userName,string password)
        {
            var user = await userRepository.GetUser(userName,password);
            return user ?? null;
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }
    }
}
