using Microsoft.EntityFrameworkCore;
using main.Models.Categories;
using main.Models.Departments;
using main.Models.Employees;
using main.Models.Reports;
using main.Models.Status;
using main.Models.Users;

namespace EFCatalogs.DAL.Data
{
    public class ReportContext : DbContext
    {
        public ReportContext()
        {

        }
        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentsConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
            modelBuilder.ApplyConfiguration(new ReportsConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Report_Service;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
            }
        }
    }
}
