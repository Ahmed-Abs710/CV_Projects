using Education_Platform.Commands;
using Education_Platform.DTOs;
using Education_Platform.Models;
using Education_Platform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(UserService userService, SignInManager<Users> signInManager)
        {
            UserService = userService;
            SignInManager = signInManager;
            
        }

        public UserService UserService { get; }
        public SignInManager<Users> SignInManager { get; }
      

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            var command =new LoginUserCommand(UserService,loginDto);
            var res = await command.Execute();
            //var log = Helper.Action("login");
           
                return Ok(res);
           
             
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            var command = new LogoutCommand(SignInManager);
            await command.Excecute();
            return Ok("Logout");
        }
    }
}
