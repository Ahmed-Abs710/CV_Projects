using Education_Platform.Models;
using Education_Platform.Services;

namespace Education_Platform.Queries
{
    public class GetAllRolesQuery
    {
        public GetAllRolesQuery(RoleService roleService)
        {
            RoleService = roleService;
        }

        public RoleService RoleService { get; }

        public async Task<List<Roles>> Execute() 
        {
            var roles = RoleService.RoleManager.Roles.ToList();
            return await Task.FromResult(roles);
        }

    }
}
