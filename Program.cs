using StudentProject.Data;
using StudentProject.Repositories;
using StudentProject.Repositories.Interfaces;
using StudentProject.Services;
using StudentProject.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.Reflection.Metadata.Ecma335;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
