using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Courses_Service.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Videos")]
        public int VideoId {  get; set; }

        public string? CommentText {  get; set; }

        public string? UserId {  get; set; }

        public DateTime CreateDate {  get; set; }= DateTime.Now;

        [JsonIgnore]
        public Videos? Video {  get; set; }


    }
}
