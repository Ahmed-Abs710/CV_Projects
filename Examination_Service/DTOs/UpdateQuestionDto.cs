using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.DTOs
{
    public class UpdateQuestionDto
    {
        public string? Text { get; set; }

        public int ExamId { get; set; }
    }
}
