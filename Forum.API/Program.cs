    using ForumDAL.Repositories;
using ReportService.BLL.Interfaces;
using ReportService.BLL.Services;
using ReportService.BLL.Services.Interfaces;
using ReportService.DAL.Repositories;
using ReportService.DAL.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Налаштування залежностей для роботи з базою даних

// Реєстрація залежності для підключення до бази даних SQL Server
builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));

// Реєстрація залежності для транзакції бази даних
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});

// Реєстрація репозиторіїв

// Реєстрація репозиторія для категорій
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

// Реєстрація репозиторія для департаментів
builder.Services.AddScoped<IDepartmentsRepository, DepartmentRepository>();

// Реєстрація репозиторія для співробітників
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

// Реєстрація репозиторія для звітів
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

// Реєстрація репозиторія для статусів
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

// Реєстрація репозиторія для користувачів
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Реєстрація репозиторія для роботи з одиницею роботи (UnitOfWork)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IReportsService, ReportsService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IUsersService, UsersService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
