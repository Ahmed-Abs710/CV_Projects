using System.ComponentModel.DataAnnotations;

namespace Courses_Service.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }

        public string? Title {  get; set; }

        public string? Description {  get; set; }

        public string? Instructor {  get; set; }

        public DateTime CreateDate {  get; set; }= DateTime.Now;

        public string? CoursePic { get; set; }

        public ICollection<Videos> video {  get; set; }
    }
}
