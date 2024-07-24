using Education_Platform.Models;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetRoleByIdQuery
    {
        public GetRoleByIdQuery(RoleService roleService, string roleid)
        {
            RoleService = roleService;
            Roleid = roleid;
        }
        public RoleService RoleService { get; }
        public string Roleid { get; }

        public async Task<Roles> Execute()
        {
            return await RoleService.GetRoleById(Roleid);
        }
    }
}
