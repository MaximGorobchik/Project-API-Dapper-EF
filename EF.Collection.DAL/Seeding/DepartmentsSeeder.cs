using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class DepartmentsSeeder : ISeeder<Departments>
    {
        private static readonly List<Departments> departments = new()
        {
            new Departments
            {
                ID = 1,
                Name = "Department 1"
            },
            new Departments
            {
                ID = 2,
                Name = "Department 2"
            }
        };

        public void Seed(EntityTypeBuilder<Departments> builder) => builder.HasData(departments);
    }
}