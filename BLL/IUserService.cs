using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto newUser);
    }
}
