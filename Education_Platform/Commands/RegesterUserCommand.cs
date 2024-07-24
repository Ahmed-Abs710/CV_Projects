using Education_Platform.DTOs;
using Education_Platform.Services;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Education_Platform.Commands
{
    public class RegesterUserCommand
    {
        public RegesterUserCommand(UserService userService, string roleid, RegisterDto dto)
        {
            UserService = userService;
            Roleid = roleid;
            Dto = dto;
        }
        //public string Email { get; set; }

        //public string Password { get; set; }

        //public string FullName {  get; set; }

        public DateTime DateOfBirth { get; set; }
        public UserService UserService { get; }
        public string Roleid { get; }
        public RegisterDto Dto { get; }

        public async Task<IdentityResult> Execute() 
        {
            //var Dto = new RegisterDto() { 
            //    FullName = FullName,
            //    DateOfBirth = DateOfBirth,
            //    Email = Email
            //};
            return await UserService.RegisterUserAsync(Roleid, Dto);
        }
    }
}
