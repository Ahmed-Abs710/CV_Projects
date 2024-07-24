using System.ComponentModel.DataAnnotations;

namespace Examination_Service.Models
{
    public class Exam
    {
        [Key]
        public int Id {  get; set; }

        public string? Title {  get; set; }

        public DateTime CreateDate {  get; set; }= DateTime.Now;

        public DateTime UpdateDate {  get; set; }

        public IEnumerable<Question>? questions { get; set; }

        public IEnumerable<ExamResult>? examResults { get; set; }

        public IEnumerable<StudentAnswer>? studentAnswers { get; set; }
    }
}
