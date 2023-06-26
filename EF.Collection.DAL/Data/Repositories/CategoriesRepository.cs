using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Categories;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {

        public CategoriesRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
