using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Data;
using Infrastruture.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BancoTeste"));

builder.Services.AddScoped<ProcessUploadReport>();
builder.Services.AddScoped<GetStatusFile>();
builder.Services.AddScoped<GetReportByID>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
