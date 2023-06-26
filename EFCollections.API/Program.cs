using EFCatalogs.DAL.Data;
using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.DAL.Data.Repositories;
using EFCatalogs.Interfaces;
using EFCatalogs.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReportContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
});
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
