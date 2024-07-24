namespace Examination_Service.DTOs
{
    public class SubmitAnswerDto
    {
        public int ExamId { get; set; }

        public string? StudentId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        public string? Answer { get; set; }

        public bool IsCorrect {  get; set; }

    }
}
