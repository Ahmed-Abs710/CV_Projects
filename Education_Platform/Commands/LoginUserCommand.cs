using Education_Platform.DTOs;
using Education_Platform.Models;
using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class LoginUserCommand
    {
        public LoginUserCommand(UserService userService, LoginDto loginDto)
        {
            UserService = userService;
            LoginDto = loginDto;
        }
        //public string Email { get; set; }

        //public string Password { get; set; }
        public UserService UserService { get; }
        public LoginDto LoginDto { get; }

        public async Task<object> Execute() 
        {
            return await UserService.LoginUserAsync(LoginDto);
        }

    }
}
