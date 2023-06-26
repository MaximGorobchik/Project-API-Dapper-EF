using System.Collections.Generic;
using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class CategoriesSeeder : ISeeder<Categories>
    {
        private static readonly List<Categories> categories = new()
        {
            new Categories
            {
                ID = 1,
                Name = "Category 1",
                DepartmentID = 1
            },
            new Categories
            {
                ID = 2,
                Name = "Category 2",
                DepartmentID = 2
            }
        };

        public void Seed(EntityTypeBuilder<Categories> builder) => builder.HasData(categories);
    }
}
