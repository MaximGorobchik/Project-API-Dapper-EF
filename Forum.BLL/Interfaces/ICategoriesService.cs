using main.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.BLL.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetCategoryByIdAsync(int id);
        Task<int> AddCategoryAsync(Categories category);
        Task UpdateCategoryAsync(int id, Categories category);
        Task DeleteCategoryAsync(int id);
    }
}
