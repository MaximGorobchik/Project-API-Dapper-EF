using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCatalogs.DAL.Data.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}
