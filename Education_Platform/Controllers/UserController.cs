using Education_Platform.Commands;
using Education_Platform.DTOs;
using Education_Platform.Queries;
using Education_Platform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService UserService { get; }

        public UserController(UserService userService)
        {
            UserService = userService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(string roleid,[FromBody]RegisterDto dto)
        {
            var command = new RegesterUserCommand(UserService, roleid, dto);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Registed Done");
            }
            else
            {
                return BadRequest(res.Errors);
            }    
        }
        [HttpPut]
        [Route("api/users/UpdateUser")]
        public async Task<IActionResult> UpdateUser(string UserId,[FromBody] UpdateUserDto dto)
        {
            var command = new UpdateUserCommand(UserService, UserId, dto);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Updated Done");
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

        [HttpDelete]
        [Route("api/users/DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userid)
        {
            var command = new DeleteUserCommand(UserService,userid);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Deleted Done");
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

        [HttpGet]
        [Route("api/users/GetUserById")]
        public async Task<IActionResult> GetUserById(string userid2)
        {
            var command = new GetUserByidQuery(UserService, userid2);
            var res = await command.Execute();
            if (res==null)
            {
                return NotFound("User Not Found");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet]
        [Route("api/users/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var command = new GetAllUsersQuery(UserService);
            var res = await command.Execute();
            return Ok(res);
        }


    }
}
