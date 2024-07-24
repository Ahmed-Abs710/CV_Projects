namespace Examination_Service.DTOs
{
    public class AnswerDto
    {
        public string? Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
