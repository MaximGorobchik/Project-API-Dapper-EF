using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using main.Models.Users;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("Users"); // Назва таблиці бази даних

        builder.HasKey(u => u.ID); // Встановлення первинного ключа

        builder.Property(u => u.Username) // Конфігурація властивості Username
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(u => u.Name) // Конфігурація властивості Name
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(u => u.Password) // Конфігурація властивості Password
            .HasMaxLength(100); // Максимальна довжина 100 символів

        builder.Property(u => u.Birthdate) // Конфігурація властивості Birthdate
            .IsRequired()
            .HasColumnType("date");

        builder.Property(u => u.Age) // Конфігурація властивості Age
            .IsRequired();

        builder.Property(u => u.Email) // Конфігурація властивості Email
            .HasMaxLength(100); // Максимальна довжина 100 символів

        // Додаткові налаштування, якщо необхідно
    }
}