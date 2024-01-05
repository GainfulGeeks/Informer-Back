using Informer.BLL.Contract;
using Informer.BLL.Services;
using Informer.Repository.Contract;
using Informer.Repository.DbContexts;
using Informer.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var allowSpecificOrigins = "AllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoy>();

builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();

builder.Services.AddDbContext<InformerDbContext>(u => u.UseSqlite("Data Source=Informer.db"));

var app = builder.Build();

app.UseCors(allowSpecificOrigins);

app.MapControllers();

app.Run();