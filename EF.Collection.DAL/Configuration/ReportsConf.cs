using main.Models.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportsConfiguration : IEntityTypeConfiguration<Reports>
{
    public void Configure(EntityTypeBuilder<Reports> builder)
    {
        builder.ToTable("Reports"); // Назва таблиці бази даних

        builder.HasKey(r => r.ID); // Встановлення первинного ключа

        builder.Property(r => r.CategoryID) // Конфігурація властивості CategoryID
            .IsRequired();

        builder.Property(r => r.StatusID) // Конфігурація властивості StatusID
            .IsRequired();

        builder.Property(r => r.OpenDate) // Конфігурація властивості OpenDate
            .HasColumnType("date");

        builder.Property(r => r.CloseDate) // Конфігурація властивості CloseDate
            .HasColumnType("date");

        builder.Property(r => r.Description) // Конфігурація властивості Description
            .HasMaxLength(1000); // Максимальна довжина 1000 символів

        builder.Property(r => r.UserID) // Конфігурація властивості UserID
            .IsRequired();

        builder.Property(r => r.EmployeeID) // Конфігурація властивості EmployeeID
            .IsRequired();

        // Додаткові налаштування, якщо необхідно

        // Налаштування зв'язку з іншою сутністю, якщо потрібно
        // builder.HasOne(r => r.Category)
        //        .WithMany(c => c.Reports)
        //        .HasForeignKey(r => r.CategoryID);

        // builder.HasOne(r => r.Status)
        //        .WithMany(s => s.Reports)
        //        .HasForeignKey(r => r.StatusID);

        // builder.HasOne(r => r.User)
        //        .WithMany(u => u.Reports)
        //        .HasForeignKey(r => r.UserID);

        // builder.HasOne(r => r.Employee)
        //        .WithMany(e => e.Reports)
        //        .HasForeignKey(r => r.EmployeeID);
    }
}
