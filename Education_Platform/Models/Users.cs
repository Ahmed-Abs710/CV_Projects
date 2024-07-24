using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;

namespace Education_Platform.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        public bool IsActive {  get; set; }

        public DateTime ExpireationDate {  get; set; }= DateTime.UtcNow;

        public string? Type {  get; set; }

    }
}
