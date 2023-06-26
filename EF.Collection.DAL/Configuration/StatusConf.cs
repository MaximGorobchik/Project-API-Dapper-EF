using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using main.Models.Status;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Status"); // Назва таблиці бази даних

        builder.HasKey(s => s.ID); // Встановлення первинного ключа

        builder.Property(s => s.Label) // Конфігурація властивості Label
            .HasMaxLength(100); // Максимальна довжина 100 символів

        // Додаткові налаштування, якщо необхідно
    }
}