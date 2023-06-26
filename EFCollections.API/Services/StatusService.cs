using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.Interfaces;
using main.Models.Status;

namespace EFCatalogs.Services
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
            return await _unitOfWork._StatusRepository.GetAllAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _unitOfWork._StatusRepository.GetByIdAsync(id);
        }

        public async Task<int> AddStatusAsync(Status status)
        {
            return await _unitOfWork._StatusRepository.AddAsync(status);
        }

        public async Task UpdateStatusAsync(int id, Status status)
        {
            var existingStatus = await _unitOfWork._StatusRepository.GetByIdAsync(id);
            existingStatus.Label = status.Label;
            await _unitOfWork._StatusRepository.UpdateAsync(existingStatus);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _unitOfWork._StatusRepository.DeleteAsync(id);
        }
    }
}
