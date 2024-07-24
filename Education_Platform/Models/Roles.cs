using Microsoft.AspNetCore.Identity;

namespace Education_Platform.Models
{
    public class Roles :IdentityRole
    {
        public bool AddStudent {  get; set; }

        public bool DelteStudent {  get; set; }

        public bool UpdateStudent {  get; set; }

        public bool AddTeacher { get; set; }

        public bool DelteTeacher { get; set; }

        public bool UpdateTeacher { get; set; }

        public bool AddAdmin {  get; set; }

        public bool SendEmail {  get; set; }


    }
}
