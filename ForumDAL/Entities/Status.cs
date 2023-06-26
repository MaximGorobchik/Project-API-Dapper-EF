

using System.ComponentModel.DataAnnotations;

namespace main.Models.Status
{
    public class Status
    {
        [Key]
        public int ID { get; set; }
        public string ?Label { get; set; }
    }
}
