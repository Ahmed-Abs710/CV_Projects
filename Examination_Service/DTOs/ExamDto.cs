namespace Examination_Service.DTOs
{
    public class ExamDto
    {
        public string? Title { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; }

    }
}
