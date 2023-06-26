namespace ReportService.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> DeleteAsync(int id);
        Task<int> AddAsync(T t);
        Task UpdateAsync(T t);
    }
}
