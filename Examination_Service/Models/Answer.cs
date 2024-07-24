using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Service.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public string? Text { get; set; }

        public bool IsCorrect {  get; set; }

        [ForeignKey("Question")]
        public int QuestionId {  get; set; }

        public Question? question {  get; set; }
    }
}
