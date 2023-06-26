using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Reports;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class ReportsRepository : GenericRepository<Reports>, IReportsRepository
    {

        public ReportsRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
