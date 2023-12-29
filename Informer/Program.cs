using Informer.BLL.Contract;
using Informer.BLL.Services;
using Informer.Repository.Contract;
//using Informer.Repository.DbContexts;
//using Informer.Repository.Repositories;
using Informer.Repository.Sqlite.DbContexts;
using Informer.Repository.Sqlite.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5174");
                      });
});

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoy>();

builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();

//builder.Services.AddDbContext<FDbContext>(u => u.UseSqlServer("Data Source=.;Initial Catalog=InformerDB;User ID=sa;Password=1;TrustServerCertificate=True"));

builder.Services.AddDbContext<FDbContext>(u => u.UseSqlite("Data Source=c:\\database\\blog.db"));

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();