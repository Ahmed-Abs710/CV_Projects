namespace Courses_Service.DTOs
{
    public class CourseDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Instructor { get; set; }

        public IFormFile? CoursePic { get; set; }

    }
}
