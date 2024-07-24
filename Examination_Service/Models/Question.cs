using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string? Text {  get; set; }

        [ForeignKey("Exam")]
        public int ExamId {  get; set; }

        public Exam? exam {  get; set; }

        public IEnumerable<Answer>? answers {  get; set; }

        public IEnumerable<StudentAnswer>? studentAnswers { get; set; }
    }
}
