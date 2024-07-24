using Education_Platform.DTOs;
using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class UpdateUserCommand
    {
        public UpdateUserCommand(UserService userService, string userid, UpdateUserDto dto)
        {
            UserService = userService;
            Userid = userid;
            Dto = dto;
        }
     
        public UserService UserService { get; }
        public string Userid { get; }
        public UpdateUserDto Dto { get; }

        public async Task<IdentityResult> Execute() 
        {
            return await UserService.UpdateUserAsync(Userid, Dto);
        }

    }
}
