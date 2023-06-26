using main.Models.Categories;
using ReportService.BLL.Interfaces;
using ReportService.DAL.Repositories.Interfaces;

namespace ReportService.BLL.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            // Виконати потрібні операції для отримання всіх категорій
            return await _unitOfWork.CategoriesRepository.GetAllAsync();
        }

        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            // Виконати потрібні операції для отримання категорії за ідентифікатором
            return await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
        }

        public async Task<int> AddCategoryAsync(Categories category)
        {
            // Виконати потрібні операції для додавання нової категорії
            return await _unitOfWork.CategoriesRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(int id, Categories category)
        {
            // Виконати потрібні операції для оновлення категорії
            var existingCategory = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
            if (existingCategory != null)
            {
                // Виконати оновлення категорії
                existingCategory.Name = category.Name;
                await _unitOfWork.CategoriesRepository.UpdateAsync(existingCategory);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            // Виконати потрібні операції для видалення категорії за ідентифікатором
            await _unitOfWork.CategoriesRepository.DeleteAsync(id);
        }
    }
}
