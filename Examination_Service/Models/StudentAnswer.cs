using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.Models
{
    public class StudentAnswer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exam")]
        public int ExamId {  get; set; }

        public Exam? exam { get; set; }

        public string? StudentId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId {  get; set; }

        public Question? question { get; set; }

        public string? Answer {  get; set; }

        public bool IsCorrect {  get; set; }

    }
}
