using System.Data.SqlClient;

namespace ReportService.DAL.Repositories
{
    public class Connection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Server=FSB\MYSERVER;Initial Catalog=CoinsProject;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}
