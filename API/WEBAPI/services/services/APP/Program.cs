using System.Data;
using System.Data.SQLite;
using BLL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string databasePath = "../DBM/DATABASE/database.db";

builder.Services.AddTransient<IDbConnection>(db => new SQLiteConnection($"Data Source={databasePath};Version=3;"));

builder.Services.AddTransient<IRoboActionRepository, RoboActionRepository>();
builder.Services.AddTransient<IRoboActionServices, RoboActionServices>();

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