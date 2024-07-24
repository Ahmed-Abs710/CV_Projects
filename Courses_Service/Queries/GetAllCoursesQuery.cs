using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetAllCoursesQuery
    {
        public GetAllCoursesQuery(CourseService courseService)
        {
            CourseService = courseService;
        }

        public CourseService CourseService { get; }

        public Task<IEnumerable<Courses>> Execute() 
        { 
            return CourseService.GetAllCoursesAsync();
        }

    }

}
