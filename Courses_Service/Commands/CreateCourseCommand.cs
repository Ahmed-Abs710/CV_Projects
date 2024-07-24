using Courses_Service.DTOs;
using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class CreateCourseCommand
    {
        public CreateCourseCommand(CourseService courseService, CourseDto courseDto)
        {
            CourseService = courseService;
            CourseDto = courseDto;
        }

        public CourseService CourseService { get; }

        public CourseDto CourseDto { get; }

        public Task<Courses> Execute() 
        { 
               return CourseService.AddCourseAsync(CourseDto);
        }
    }
}
