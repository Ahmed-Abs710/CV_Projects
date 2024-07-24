using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class AssignRoleCommand
    {
        public AssignRoleCommand(RoleService roleService, string roleid, string userid)
        {
            RoleService = roleService;
            Roleid = roleid;
            Userid = userid;
        }
       
        public RoleService RoleService { get; }
        public string Roleid { get; }
        public string Userid { get; }

        public async Task<IdentityResult> Execute() 
        {
            return await RoleService.AssignRoleToUserAsync(Userid, Roleid);
        }
    }
}
