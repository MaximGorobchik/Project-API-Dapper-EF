using main.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.ToTable("Categories"); // Назва таблиці бази даних

        builder.HasKey(c => c.ID); // Встановлення первинного ключа

        builder.Property(c => c.Name) // Конфігурація властивості Name
            .IsRequired()
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(c => c.DepartmentID) // Конфігурація властивості DepartmentID
            .IsRequired();

        // Додаткові налаштування, якщо необхідно

        // Налаштування зв'язку з іншою сутністю, якщо потрібно
        // builder.HasOne(c => c.Department)
        //        .WithMany(d => d.Categories)
        //        .HasForeignKey(c => c.DepartmentID);
    }
}
