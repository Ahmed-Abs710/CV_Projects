using Courses_Service.DTOs;
using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class UpdateCourseCommand
    {
        public UpdateCourseCommand(CourseService courseService, int courseid, UpdateCourseDto courseDto)
        {
            CourseService = courseService;
            Courseid = courseid;
            CourseDto = courseDto;
        }

        public CourseService CourseService { get; }
        public int Courseid { get; }
        public UpdateCourseDto CourseDto { get; }

        public Task<Courses> Execute() 
        { 
            return CourseService.UpdateCourseAsync(Courseid, CourseDto);
        }
    }
}
