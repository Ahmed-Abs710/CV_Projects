using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetCourseByIdQuery
    {
        public GetCourseByIdQuery(CourseService courseService, int courseid)
        {
            CourseService = courseService;
            Courseid = courseid;
        }

        public CourseService CourseService { get; }
        public int Courseid { get; }

        public Task<Courses> Execute() 
        {
            return CourseService.GetCourseByIdAsync(Courseid);
        }
    }
}
