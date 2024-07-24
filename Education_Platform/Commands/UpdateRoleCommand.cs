using Education_Platform.DTOs;
using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Commands
{
    public class UpdateRoleCommand
    {
        public UpdateRoleCommand(RoleService roleService, UpdateRoleDto updateRoleDto, string roleid)
        {
            RoleService = roleService;
            UpdateRoleDto = updateRoleDto;
            Roleid = roleid;
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public bool AddStudent { get; set; }

        //public bool DelteStudent { get; set; }

        //public bool UpdateStudent { get; set; }

        //public bool AddTeacher { get; set; }

        //public bool DelteTeacher { get; set; }

        //public bool UpdateTeacher { get; set; }

        //public bool AddAdmin { get; set; }

        //public bool SendEmail { get; set; }
        public RoleService RoleService { get; }
        public UpdateRoleDto UpdateRoleDto { get; }
        public string Roleid { get; }

        public async Task<IdentityResult> Execute() 
        {
            //var dto = new UpdateRoleDto()
            //{
            //    RoleName = Name,
            //    AddAdmin = AddAdmin,
            //    AddStudent = AddStudent,
            //    AddTeacher = AddTeacher,
            //    DelteStudent = DelteStudent,
            //    DelteTeacher = DelteTeacher,
            //    SendEmail = SendEmail,
            //    UpdateStudent = UpdateStudent,
            //    UpdateTeacher = UpdateTeacher
            //};
            return await RoleService.UpdateRoleAsync(Roleid, UpdateRoleDto);
        }

    }
}
