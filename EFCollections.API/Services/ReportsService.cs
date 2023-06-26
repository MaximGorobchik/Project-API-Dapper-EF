
using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.Interfaces;
using main.Models.Reports;

namespace EFCatalogs.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reports>> GetAllReportsAsync()
        {
            // Виконати потрібні операції для отримання всіх звітів
            return await _unitOfWork._ReportsRepository.GetAllAsync();
        }

        public async Task<Reports> GetReportByIdAsync(int id)
        {
            // Виконати потрібні операції для отримання звіту за ідентифікатором
            return await _unitOfWork._ReportsRepository.GetByIdAsync(id);
        }

        public async Task<int> AddReportAsync(Reports report)
        {
            // Виконати потрібні операції для додавання нового звіту
            return await _unitOfWork._ReportsRepository.AddAsync(report);
        }

        public async Task UpdateReportAsync(int id, Reports report)
        {
            // Виконати потрібні операції для оновлення звіту
            var existingReport = await _unitOfWork._ReportsRepository.GetByIdAsync(id);
            if (existingReport != null)
            {
                // Виконати оновлення звіту
                existingReport.CategoryID = report.CategoryID;
                existingReport.StatusID = report.StatusID;
                existingReport.OpenDate = report.OpenDate;
                existingReport.CloseDate = report.CloseDate;
                existingReport.Description = report.Description;
                existingReport.UserID = report.UserID;
                existingReport.EmployeeID = report.EmployeeID;
                await _unitOfWork._ReportsRepository.UpdateAsync(existingReport);
            }
        }

        public async Task DeleteReportAsync(int id)
        {
            // Виконати потрібні операції для видалення звіту за ідентифікатором
            await _unitOfWork._ReportsRepository.DeleteAsync(id);
        }
    }
}
