using main.Models.Status;
using OpenQA.Selenium;
using ReportService.BLL.Services.Interfaces;
using ReportService.DAL.Repositories.Interfaces;

namespace ReportService.BLL.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _unitOfWork.StatusRepository.GetAllAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _unitOfWork.StatusRepository.GetByIdAsync(id);
        }

        public async Task<int> AddStatusAsync(Status status)
        {
            return await _unitOfWork.StatusRepository.AddAsync(status);
        }

        public async Task UpdateStatusAsync(int id, Status status)
        {
            var existingStatus = await _unitOfWork.StatusRepository.GetByIdAsync(id);
            existingStatus.Label = status.Label;
            await _unitOfWork.StatusRepository.UpdateAsync(existingStatus);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _unitOfWork.StatusRepository.DeleteAsync(id);
        }
    }
}
