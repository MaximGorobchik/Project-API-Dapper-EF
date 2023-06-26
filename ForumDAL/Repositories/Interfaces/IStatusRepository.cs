using main.Models.Status;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces
{
    public interface IStatusRepository: IGenericRepository<Status>
    {
        //Task InsertAsync(Status status);
    }
}
