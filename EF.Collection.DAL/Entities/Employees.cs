

using System.ComponentModel.DataAnnotations;

namespace main.Models.Employees
{
    public class Employees
    {
        [Key]
        public int ID { get; set; }
        public string ?Firstname { get; set; }
        public string ?Lastname { get; set; }
        public DateTime ?Birthdate { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }
    }
}
