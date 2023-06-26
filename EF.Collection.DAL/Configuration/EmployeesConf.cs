using main.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable("Employees"); // Назва таблиці бази даних

        builder.HasKey(e => e.ID); // Встановлення первинного ключа

        builder.Property(e => e.Firstname) // Конфігурація властивості Firstname
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(e => e.Lastname) // Конфігурація властивості Lastname
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(e => e.Birthdate) // Конфігурація властивості Birthdate
            .HasColumnType("date");

        builder.Property(e => e.Age) // Конфігурація властивості Age
            .IsRequired();

        builder.Property(e => e.DepartmentID) // Конфігурація властивості DepartmentID
            .IsRequired();

        // Додаткові налаштування, якщо необхідно

        // Налаштування зв'язку з іншою сутністю, якщо потрібно
        // builder.HasOne(e => e.Department)
        //        .WithMany(d => d.Employees)
        //        .HasForeignKey(e => e.DepartmentID);
    }
}