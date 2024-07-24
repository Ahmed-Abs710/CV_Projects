using Education_Platform.DTOs;
using Education_Platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Education_Platform.Services
{
    public class UserService
    {
        public UserManager<Users> UserManager { get; }
        public SignInManager<Users> SignInManager { get; }
        public RoleService RoleService { get; }

        // public IEmailSender EmailSender { get; }

        public UserService(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleService roleService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleService = roleService;
            //  EmailSender = emailSender;
        }

        //Add New User Method
        public async Task<IdentityResult> RegisterUserAsync(string  roleid,RegisterDto registerDto)
        {
            var User = new Users { 
                    FullName = registerDto.FullName,
                    Email = registerDto.Email,
                    DateOfBirth = registerDto.DateOfBirth,
                    UserName = registerDto.UserName
            };
            var res = await UserManager.CreateAsync(User, registerDto.Password);
            if (res != null && roleid != null)
            {
                var userid = await (from users in UserManager.Users where users.UserName == User.UserName select users.Id).FirstOrDefaultAsync();
                await RoleService.AssignRoleToUserAsync(userid,roleid);
            }
            if (res.Succeeded)
            {
               var token =await UserManager.GenerateEmailConfirmationTokenAsync(User);
               await UserManager.ConfirmEmailAsync(User,token);
                return res;
            }
            else
            {
                return res;
            }   
        }

        //Sign in Method
        public async Task<object> LoginUserAsync(LoginDto loginDto)
        {
            var notfound = new UserDto{ id = "" , name ="Invalid Useranem Or Password"};
            if (loginDto.Username == null || loginDto.Password ==null)
            {
                return notfound;
            }
            var res = await SignInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
                    
            if (res.Succeeded)
            {
               var  user = await UserManager.FindByNameAsync(loginDto.Username);
                var role = await RoleService.GetRolesForUserAsync(user.Id);
                var result = new UserDto { id = user.Id, name = role.FirstOrDefault().ToString() };
                return result;
            }
            else
            {

                return notfound;
            }
            
        }
        //Update User Method
        public async Task<IdentityResult> UpdateUserAsync(string UserId , UpdateUserDto updateUserDto)
        {
            var result =await UserManager.FindByIdAsync(UserId);
            if (result == null)
            {
                return IdentityResult.Failed(new IdentityError{Description = "User Not Found" });
            }
            result.FullName = updateUserDto.FullName;
            result.UserName = updateUserDto.username;
            result.Email = updateUserDto.email;
            result.PhoneNumber = updateUserDto.phone;
            return await UserManager.UpdateAsync(result);
        }

        //Find User Method
        public async Task<Users> GetUserByIdAsync(string UserId)
        {
            var res = await UserManager.FindByIdAsync(UserId);
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }   
        }

        //Delete User
        public async Task<IdentityResult> DeleteUserAsync(string UserId)
        {
            var user = await UserManager.FindByIdAsync(UserId);
            if (user ==null)
            {
                return IdentityResult.Failed(new IdentityError { Description ="User Not Found"});
            }
            return await UserManager.DeleteAsync(user);
        }
    }
}
