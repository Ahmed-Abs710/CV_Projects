using Education_Platform.Models;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetAllUsersQuery
    {
        public GetAllUsersQuery(UserService userService)
        {
            UserService = userService;
        }

        public UserService UserService { get; }

        public async Task<List<Users>> Execute() 
        {
            var users = UserService.UserManager.Users.ToList();
            return await Task.FromResult(users);
        }
    }
}
