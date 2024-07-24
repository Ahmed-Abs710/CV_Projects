namespace Courses_Service.DTOs
{
    public class AddVideoToCourseDto
    {
        public int CourseId { get; set; }

        public string? VideoUrl { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

    }
}
