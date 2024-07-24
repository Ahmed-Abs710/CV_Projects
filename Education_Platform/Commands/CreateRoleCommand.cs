using Education_Platform.DTOs;
using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;
using System.Data.Common;

namespace Education_Platform.Commands
{
    public class CreateRoleCommand
    {
        public CreateRoleCommand(RoleService roleService, CreateRoleDto createRoleDto)
        {
            RoleService = roleService;
            CreateRoleDto = createRoleDto;
        }
        public string Name {  get; set; }
        public bool AddStudent { get; set; }

        public bool DelteStudent { get; set; }

        public bool UpdateStudent { get; set; }

        public bool AddTeacher { get; set; }

        public bool DelteTeacher { get; set; }

        public bool UpdateTeacher { get; set; }

        public bool AddAdmin { get; set; }

        public bool SendEmail { get; set; }
        public RoleService RoleService { get; }
        public CreateRoleDto CreateRoleDto { get; }

        public async Task<IdentityResult> Execute()
        {
            //var dto = new CreateRoleDto() { 
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
            return await RoleService.CreateRoleAsync(CreateRoleDto);
        }
    }
}
