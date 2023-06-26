
using main.Models.Reports;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces

{
    public interface IReportsRepository: IGenericRepository<Reports>
    {
        //Task InsertAsync(Reports report);
    }
}
