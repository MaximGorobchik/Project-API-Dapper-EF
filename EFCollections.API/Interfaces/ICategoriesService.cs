using main.Models.Categories;

namespace EFCatalogs.Interfaces
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
