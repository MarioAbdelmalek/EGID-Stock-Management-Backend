using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        void RegisterUser(User newUser);
    }
}
