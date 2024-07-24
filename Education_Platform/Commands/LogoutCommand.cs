using Education_Platform.DTOs;
using Education_Platform.Models;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class LogoutCommand
    {
        public LogoutCommand(SignInManager<Users> signInManager)
        {
            SignInManager = signInManager;
        }

        public SignInManager<Users> SignInManager { get; }

        public async Task Excecute()
        {
            await SignInManager.SignOutAsync();
        }
    }
}
