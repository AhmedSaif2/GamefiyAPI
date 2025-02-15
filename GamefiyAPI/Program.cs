using GamefiyAPI.Data;
using GamefiyAPI.Models;
using GamefiyAPI.Repositories;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IRepository<Game>, Repository<Game>>();
builder.Services.AddTransient<IRepository<Publisher>, Repository<Publisher>>();
builder.Services.AddTransient<IRepository<User>, Repository<User>>();
builder.Services.AddTransient<IRepository<Review>, Repository<Review>>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
