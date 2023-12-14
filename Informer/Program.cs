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

builder.Services.AddDbContext<FDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("InformerDb") ?? throw new InvalidOperationException("Connection string 'LicoriceBackContext' not found.")));

var app = builder.Build();

app.MapControllers();

app.Run();