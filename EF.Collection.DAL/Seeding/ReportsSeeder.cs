using System;
using System.Collections.Generic;
using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Reports;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class ReportsSeeder : ISeeder<Reports>
    {
        private static readonly List<Reports> reports = new()
        {
            new Reports
            {
                ID = 1,
                CategoryID = 1,
                StatusID = 1,
                OpenDate = new DateTime(2023, 1, 1),
                CloseDate = new DateTime(2023, 1, 5),
                Description = "Report 1 description",
                UserID = 1,
                EmployeeID = 1
            },
            new Reports
            {
                ID = 2,
                CategoryID = 2,
                StatusID = 2,
                OpenDate = new DateTime(2023, 2, 1),
                CloseDate = new DateTime(2023, 2, 5),
                Description = "Report 2 description",
                UserID = 2,
                EmployeeID = 2
            }
        };

        public void Seed(EntityTypeBuilder<Reports> builder) => builder.HasData(reports);
    }
}
