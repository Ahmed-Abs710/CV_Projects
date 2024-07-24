namespace Courses_Service.DTOs
{
    public class AddCommentToVideoDto
    {
        public int VideoId { get; set; }

        public string? CommentText { get; set; }

        public string? UserId { get; set; }

    }
}
