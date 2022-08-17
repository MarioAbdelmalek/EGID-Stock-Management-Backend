using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        IUserService userService;

        public UserController(IJwtAuthenticationManager jwtAuthenticationManager, IUserService userService)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.userService = userService;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public void RegisterUser(RegisterUserDto newUser)
        {
            userService.RegisterUser(newUser);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] RegisterUserDto userCred)
        {
            var generatedToken = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (generatedToken == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(generatedToken);
            }
        }
    }
}
