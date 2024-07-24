namespace Education_Platform.DTOs
{
    public class UpdateUserDto
    {
        public string? FullName { get; set; }

        public string? username { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

       // public DateTime ExpireationDate { get; set; } = DateTime.UtcNow;
    }
}
