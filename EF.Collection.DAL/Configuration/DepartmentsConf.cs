using main.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
{
    public void Configure(EntityTypeBuilder<Departments> builder)
    {
        builder.ToTable("Departments"); // Назва таблиці бази даних

        builder.HasKey(d => d.ID); // Встановлення первинного ключа

        builder.Property(d => d.Name) // Конфігурація властивості Name
            .IsRequired()
            .HasMaxLength(100); // Максимальна довжина 100 символів

        // Додаткові налаштування, якщо необхідно

        // Налаштування зв'язку з іншою сутністю, якщо потрібно
        // builder.HasMany(d => d.Categories)
        //        .WithOne(c => c.Department)
        //        .HasForeignKey(c => c.DepartmentID);
    }
}
