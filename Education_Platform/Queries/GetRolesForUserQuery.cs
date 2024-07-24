using Education_Platform.DTOs;
using Education_Platform.Models;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetRolesForUserQuery
    {
        public GetRolesForUserQuery(RoleService roleService, string userid)
        {
            RoleService = roleService;
            Userid = userid;
        }

        public RoleService RoleService { get; }
        public string Userid { get; }

        public async Task<IList<string>> Execute()
        {
            return await RoleService.GetRolesForUserAsync(Userid);
        }
    }
}
