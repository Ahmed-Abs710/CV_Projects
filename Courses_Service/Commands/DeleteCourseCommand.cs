using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class DeleteCourseCommand
    {
        public DeleteCourseCommand(CourseService courseService, int courseid)
        {
            CourseService = courseService;
            Courseid = courseid;
        }

        public CourseService CourseService { get; }
        public int Courseid { get; }

        public Task<bool> Execute()
        { 
            return CourseService.DeleteCourseAsync(Courseid);
        }
    }
}
