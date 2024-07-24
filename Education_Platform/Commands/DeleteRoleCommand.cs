using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class DeleteRoleCommand
    {
        public DeleteRoleCommand(RoleService roleService,string roleid)
        {
            RoleService = roleService;
            RoleId = roleid;
        }
        public string RoleId {  get; set; } 
        public RoleService RoleService { get; }

        public async Task<IdentityResult> Execute()
        {
            return await RoleService.DeleteRoleAsync(RoleId);
        }
    }
}
