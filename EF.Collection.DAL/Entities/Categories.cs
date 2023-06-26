using System.ComponentModel.DataAnnotations;

namespace main.Models.Categories
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        public string ?Name { get; set; }
        public int DepartmentID { get; set; }
    }
}
