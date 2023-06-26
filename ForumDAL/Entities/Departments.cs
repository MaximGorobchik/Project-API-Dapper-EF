using System.ComponentModel.DataAnnotations;

namespace main.Models.Departments
{
    public class Departments
    {
        [Key]
        public int ID { get; set; }
        public string ?Name { get; set; }
    }
}
