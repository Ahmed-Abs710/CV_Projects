using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.DTOs
{
    public class UpdateAnswerDto
    {
        public string? Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
