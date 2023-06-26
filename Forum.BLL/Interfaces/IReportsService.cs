

using main.Models.Reports;

namespace ReportService.BLL.Services.Interfaces
{
    public interface IReportsService
    {
        Task<IEnumerable<Reports>> GetAllReportsAsync();
        Task<Reports> GetReportByIdAsync(int id);
        Task<int> AddReportAsync(Reports report);
        Task UpdateReportAsync(int id, Reports report);
        Task DeleteReportAsync(int id);
    }
}
