using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Status;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StatusSeeder : ISeeder<Status>
{
    private static readonly List<Status> statuses = new()
    {
        new Status
        {
            ID = 1,
            Label = "Active"
        },
        new Status
        {
            ID = 2,
            Label = "Inactive"
        }
    };

    public void Seed(EntityTypeBuilder<Status> builder) => builder.HasData(statuses);
}