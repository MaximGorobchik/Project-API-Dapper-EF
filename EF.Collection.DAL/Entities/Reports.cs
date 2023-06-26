﻿

using System.ComponentModel.DataAnnotations;

namespace main.Models.Reports
{
    public class Reports
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public DateTime ?OpenDate { get; set; }
        public DateTime ?CloseDate { get; set; }
        public string ?Description { get; set; }
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
    }
}
