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
    public class RoleController : ControllerBase
    {
        public RoleService RoleService { get; }
        public UserService UserService { get; }

        public RoleController(RoleService roleService, UserService userService)
        {
            RoleService = roleService;
            UserService = userService;
        }
        [HttpPost]
        [Route("api/roles/create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            var command = new CreateRoleCommand(RoleService,dto);
            var res =await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Role Created");
            }
            else
            {
                return BadRequest(res.Errors);
            }
            
        }

        [HttpPut]
        [Route("api/roles/UpdateRole")]
        public async Task<IActionResult> UpdateRole(string roleid, [FromBody] UpdateRoleDto dto)
        {
            var command = new UpdateRoleCommand(RoleService,dto, roleid);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Role Updated");
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

        [HttpDelete]
        [Route("api/roles/DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleid)
        {
            var command = new DeleteRoleCommand(RoleService,roleid);
            var res =await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Role Deleted");
            }
            return BadRequest(res.Errors);
        }

        [HttpGet]
        [Route("api/roles/GetRoleById")]
        public async Task<IActionResult> GetRoleById(string roleid)
        {
            var command = new GetRoleByIdQuery(RoleService , roleid);
            var res = await command.Execute();
            if (res == null)
            {
               return NotFound("Role Not Found");
            }
            else
            {
                return Ok(res);
            }     
        }

        [HttpGet]
        [Route("api/roles/GetRoleForUserById")]
        public async Task<IActionResult> GetRoleForUserById(string userid)
        {
            var command = new GetRolesForUserQuery(RoleService, userid);
            var res = await command.Execute();
            if (res == null)
            {
                return NotFound("Role Not Found");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet("GetUserRolesAsync")]
        public async Task<IActionResult> GetUserRolesAsync(string userid)
        {
            var command = new GetUserRolesQuery(RoleService, userid);
            var res = await command.Execute();
            if (res == null)
            {
                return NotFound("Role Not Found");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var command = new GetAllRolesQuery(RoleService);
            var res = await command.Execute();
            if (res==null)
            {
                return NotFound("Roles Not Found");
            }
            else
            {
                return Ok(res);
            }         
        }

        [HttpPost]
        [Route("api/roles/AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(string roleid,string userid)
        {
            var command = new AssignRoleCommand(RoleService, roleid, userid);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Assign Done");
            }
            else
            {
                return BadRequest(res.Errors);
            }
            
        }

        [HttpPost]
        [Route("api/roles/RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(string roleid, string userid)
        {
            var command = new RemoveRoleCommand(RoleService,roleid , userid);
            var res = await command.Execute();
            if (res.Succeeded)
            {
                return Ok("Removed Done");
            }
            else
            {
                return BadRequest(res.Errors);
            }
           
        }
    }
}
