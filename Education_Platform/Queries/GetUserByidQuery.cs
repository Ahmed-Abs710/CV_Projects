using Education_Platform.Models;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetUserByidQuery
    {
        public GetUserByidQuery(UserService userService, string userid)
        {
            UserService = userService;
            Userid = userid;
        }
       
        public UserService UserService { get; }
        public string Userid { get; }

        public async Task<Users> Execute() 
        {
            return await UserService.GetUserByIdAsync(Userid);
        }

    }
}
