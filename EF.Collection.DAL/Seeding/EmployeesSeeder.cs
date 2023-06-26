using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeesSeeder : ISeeder<Employees>
{
    private static readonly List<Employees> employees = new()
    {
        new Employees
        {
            ID = 1,
            Firstname = "John",
            Lastname = "Doe",
            Birthdate = new DateTime(1990, 1, 1),
            Age = 31,
            DepartmentID = 1
        },
        new Employees
        {
            ID = 2,
            Firstname = "Jane",
            Lastname = "Smith",
            Birthdate = new DateTime(1995, 2, 15),
            Age = 28,
            DepartmentID = 2
        }
    };

    public void Seed(EntityTypeBuilder<Employees> builder) => builder.HasData(employees);
}