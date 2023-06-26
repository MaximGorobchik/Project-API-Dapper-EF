using main.Models.Status;

namespace ReportService.BLL.Services.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int id);
        Task<int> AddStatusAsync(Status status);
        Task UpdateStatusAsync(int id, Status status);
        Task DeleteStatusAsync(int id);
    }
}
