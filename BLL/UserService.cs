using AutoMapper;
using BLL.ModelsDto;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserService : IUserService
    {

        IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public void RegisterUser(RegisterUserDto newUser)
        {
            UserDto u = new UserDto { Username = newUser.Username, Password = newUser.Password };
            userRepository.RegisterUser(mapper.Map<User>(u));
        }
    }
}
