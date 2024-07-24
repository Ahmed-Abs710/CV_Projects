using Courses_Service.Commands;
using Courses_Service.DTOs;
using Courses_Service.Queries;
using Courses_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public CourseService CourseService { get; }

        public CourseController(CourseService courseService)
        {
            CourseService = courseService;
        }
        [HttpPost]
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromForm] CourseDto courseDto)
        {
            var course = new CreateCourseCommand(CourseService, courseDto);
            var res =await course.Execute();
            if (res == null)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var course = new GetAllCoursesQuery(CourseService);
            var res =await course.Execute();
            if (res==null)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCourseById")]
        public async Task<IActionResult> GetCourseById(int courseid)
        {
            var course = new GetCourseByIdQuery(CourseService, courseid);
            var res =await course.Execute();
            if (res == null)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(int courseid, [FromBody] UpdateCourseDto updateCourseDto)
        {
            var course = new UpdateCourseCommand(CourseService, courseid,updateCourseDto);
            var res =await course.Execute();
            if (res == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpDelete]
        [Route("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(int courseid)
        {
            var course = new DeleteCourseCommand(CourseService, courseid);
            var res =await course.Execute();
            var res2 = Convert.ToBoolean(res);
            if (res2)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



        
    }
}
