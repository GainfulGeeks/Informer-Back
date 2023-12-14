using InformerBLL.Contract;
using InformerBLL.Services;
using InformerRepository.Contract;
using InformerRepository.DbContexts;
using InformerRepository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoy>();

builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();

builder.Services.AddDbContext<FDbContext>(u => u.UseSqlServer("Data Source=.;Initial Catalog=InformerDB;User ID=sa;Password=1;TrustServerCertificate=True"));

var app = builder.Build();

app.MapControllers();

app.Run();