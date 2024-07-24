using Education_Platform.DTOs;
using Education_Platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Education_Platform.Services
{
    public class RoleService
    {
        public RoleManager<Roles> RoleManager { get; }
        public UserManager<Users> UserManager { get; }
        public AppDbContext AppDbContext { get; }

        public RoleService(RoleManager<Roles> roleManager, UserManager<Users> userManager, AppDbContext appDbContext)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            AppDbContext = appDbContext;
        }

        //Create Role Method
        public async Task<IdentityResult> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var role = new Roles()
            {
                Name = createRoleDto.RoleName,
                AddAdmin=createRoleDto.AddAdmin,
                AddStudent=createRoleDto.AddStudent,
                AddTeacher=createRoleDto.AddTeacher,
                SendEmail = createRoleDto.SendEmail,
                UpdateStudent = createRoleDto.UpdateStudent,
                DelteStudent = createRoleDto.DelteStudent,
                DelteTeacher = createRoleDto.DelteTeacher,
                UpdateTeacher = createRoleDto.UpdateTeacher
            };
            
            return await RoleManager.CreateAsync(role);
        }

        //Update Role Method
        public async Task<IdentityResult> UpdateRoleAsync(string roleid,UpdateRoleDto UpdateRoleDto)
        {
            var role = await RoleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description="Role Not Found"});
            }
            role.Name = UpdateRoleDto.RoleName;
            role.AddAdmin = UpdateRoleDto.AddAdmin;
            role.AddStudent = UpdateRoleDto.AddStudent;
            role.AddTeacher = UpdateRoleDto.AddTeacher;
            role.SendEmail = UpdateRoleDto.SendEmail;
            role.UpdateStudent = UpdateRoleDto.UpdateStudent;
            role.DelteStudent = UpdateRoleDto.DelteStudent;
            role.DelteTeacher = UpdateRoleDto.DelteTeacher;
            role.UpdateTeacher = UpdateRoleDto.UpdateTeacher;
            return await RoleManager.UpdateAsync(role);
        }

        //Assign Role To User Method
        public async Task<IdentityResult> AssignRoleToUserAsync(string UserId , string RoleId)
        {
            var user = await UserManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError{ Description ="User Not Found"});
            }
            var role = await RoleManager.FindByIdAsync(RoleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role Not Found" });
            }
            return await UserManager.AddToRoleAsync(user,role.Name);
        }

        //Remove Role From User Method
        public async Task<IdentityResult> RemoveRoleFromUserAsync(string UserId,string RoleId)
        {
            var user = await UserManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User Not Found" });
            }
            var role = await RoleManager.FindByIdAsync(RoleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role Not Found" });
            }
            return await UserManager.RemoveFromRoleAsync(user,role.Name);
        }

        //Get The User Role Method
        public async Task<IList<string>> GetRolesForUserAsync(string UserId)
        {

            //var roles = await (from UserRole in AppDbContext.UserRoles
            //                   join role in AppDbContext.Roles
            //                   on UserRole.RoleId equals role.Id
            //                   where UserRole.UserId == UserId
            //                   select new PermissionsDto
            //                   {
            //                       AddAdmin = role.AddAdmin,
            //                       UpdateTeacher= role.UpdateTeacher,
            //                       AddStudent = role.AddStudent,
            //                       AddTeacher= role.AddTeacher,
            //                       DelteStudent = role.DelteStudent,
            //                       DelteTeacher = role.DelteTeacher,
            //                       SendEmail = role.SendEmail,
            //                       UpdateStudent = role.UpdateStudent
            //                   }).ToListAsync();

            var res =await UserManager.FindByIdAsync(UserId);
            if (res == null)
            {
                return null;
            }
            var result = await UserManager.GetRolesAsync(res);
            //var Role = new PermissionsDto {
            //       Roles = result as List<string>
            //};
            return result;
        }

        public async Task<IList<PermissionsDto>> GetUserRolesAsync(string UserId)
        {

            var roles = await (from UserRole in AppDbContext.UserRoles
                               join role in AppDbContext.Roles
                               on UserRole.RoleId equals role.Id
                               where UserRole.UserId == UserId
                               select new PermissionsDto
                               {
                                   AddAdmin = role.AddAdmin,
                                   UpdateTeacher = role.UpdateTeacher,
                                   AddStudent = role.AddStudent,
                                   AddTeacher = role.AddTeacher,
                                   DelteStudent = role.DelteStudent,
                                   DelteTeacher = role.DelteTeacher,
                                   SendEmail = role.SendEmail,
                                   UpdateStudent = role.UpdateStudent
                               }).ToListAsync();

            //var res = await UserManager.FindByIdAsync(UserId);
            //if (res == null)
            //{
            //    return null;
            //}
            //var result = await UserManager.GetRolesAsync(res);
            //var Role = new PermissionsDto {
            //       Roles = result as List<string>
            //};
            return roles;
        }

        //Get Role By ID
        public async Task<Roles> GetRoleById(string RoleId)
        {
            return await RoleManager.FindByIdAsync(RoleId);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleid)
        {
            var res = await RoleManager.FindByIdAsync(roleid);
            if (res == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role Not Found" });
            }
            return await RoleManager.DeleteAsync(res);
        }

     
    }
}
