using account_review_api.Infrastructure.Services;
using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Data;
using Infrastruture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Financial Report Review",
        Description = "An ASP.NET Core Web API for automating and managing financial report validation, ensuring consistency, performance, and traceability in enterprise-level workflows.",
        Contact = new OpenApiContact
        {
            Name = "Victor Bertram (LinkedIn)",
            Url = new Uri("https://www.linkedin.com/in/victord08/"),
            Email= "bertramvictor8@gmail.com"
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProcessUploadReport>();
builder.Services.AddScoped<GetStatusFile>();
builder.Services.AddScoped<GetReportByID>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
