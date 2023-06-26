using System.ComponentModel.DataAnnotations;

namespace main.Models.Users
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string ?Username { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }
}
