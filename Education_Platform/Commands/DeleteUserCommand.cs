using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class DeleteUserCommand
    {
        public DeleteUserCommand(UserService userService, string userid)
        {
            UserService = userService;
            Userid = userid;
        }
       
        public UserService UserService { get; }
        public string Userid { get; }

        public async Task<IdentityResult> Execute()
        {
            return await UserService.DeleteUserAsync(Userid);
        }

    }
}
