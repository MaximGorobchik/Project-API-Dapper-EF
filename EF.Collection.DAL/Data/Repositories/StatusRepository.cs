using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Status;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {

        public StatusRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
