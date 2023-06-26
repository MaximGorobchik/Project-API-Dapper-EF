using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Users;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {

        public UsersRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
