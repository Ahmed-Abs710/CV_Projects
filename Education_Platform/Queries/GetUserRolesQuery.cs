using Education_Platform.DTOs;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetUserRolesQuery
    {
        public GetUserRolesQuery(RoleService roleService, string userid)
        {
            RoleService = roleService;
            Userid = userid;
        }

        public RoleService RoleService { get; }
        public string Userid { get; }

        public async Task<IList<PermissionsDto>> Execute()
        {
            return await RoleService.GetUserRolesAsync(Userid);
        }
    }
}
