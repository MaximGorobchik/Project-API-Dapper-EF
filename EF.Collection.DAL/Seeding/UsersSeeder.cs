using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsersSeeder : ISeeder<Users>
{
    private static readonly List<Users> users = new()
    {
        new Users
        {
            ID = 1,
            Username = "john.doe",
            Name = "John Doe",
            Password = "password",
            Birthdate = new DateTime(1990, 1, 1),
            Age = 31,
            Email = "john.doe@example.com"
        },
        new Users
        {
            ID = 2,
            Username = "jane.smith",
            Name = "Jane Smith",
            Password = "password",
            Birthdate = new DateTime(1995, 2, 15),
            Age = 28,
            Email = "jane.smith@example.com"
        }
    };

    public void Seed(EntityTypeBuilder<Users> builder) => builder.HasData(users);
}