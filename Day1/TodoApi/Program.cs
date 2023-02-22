using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var connectionString = "server=localhost;database=training_2023;user=root;password=root";
var serverVersion = ServerVersion.AutoDetect(connectionString);
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbsContext>(opt => opt.UseMySql(connectionString, serverVersion));

    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





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
