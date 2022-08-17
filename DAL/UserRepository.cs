using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserRepository : IUserRepository
    {

        private readonly PostgreSqlContext context;

        public UserRepository(PostgreSqlContext context)
        {
            this.context = context;
        }
        public void RegisterUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
