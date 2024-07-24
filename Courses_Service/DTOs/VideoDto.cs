namespace Courses_Service.DTOs
{
    public class VideoDto
    {
       public string? courseid { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public IFormFile? videopath { get; set; }
    }
}
