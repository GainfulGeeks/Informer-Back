using Informer.BLL.Contract;
using Informer.BLL.Services;
using Informer.Repository.Contract;
using Informer.Repository.DbContexts;
using Informer.Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "oauth2"
            },
            Scheme = "oauth2",
            Name = "oauth2",
            In = ParameterLocation.Header
        },
        new List <string> ()
    }
});

    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    option.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoy>();

builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();

builder.Services.AddDbContext<InformerDbContext>(u => u.UseSqlite("Data Source=Informer.db"));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<InformerDbContext>();

var app = builder.Build();

//app.MapIdentityApi<IdentityUser>();
app.MapGroup("/api").MapIdentityApi<IdentityUser>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(allowSpecificOrigins);

app.MapControllers();

app.Run();