namespace Examination_Service.DTOs
{
    public class UpdateExamDto
    {
        public string? Title { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; }

    }
}
