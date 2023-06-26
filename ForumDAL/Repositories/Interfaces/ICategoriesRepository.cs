
using main.Models.Categories;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces
{
    public interface ICategoriesRepository : IGenericRepository<Categories>
    {
        //Task InsertAsync(Categories category);
    }
}
