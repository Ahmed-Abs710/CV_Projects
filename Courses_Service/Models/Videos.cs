using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Service.Models
{
    public class Videos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Courses")]
        public int CourseId {  get; set; }

        public string? VideoUrl {  get; set; }

        public string? Title {  get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }= DateTime.Now;

        public Courses? Courses { get; set; }

        public ICollection<Comments> comment {  get; set; }
    }
}
