using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.Models
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exam")]
        public int ExamId {  get; set; }

        public Exam? exam { get; set; }

        public string? StudentId {  get; set; }

        public double Score {  get; set; }
    }
}
