global using Microsoft.EntityFrameworkCore;
global using ChartProject_Api.Data;
global using ChartProject_Api.Models;
global using ChartProject_Api.Interfaces;
global using ChartProject_Api.Repository;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerContext>((options) =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Orange"))
);
builder.Services.AddScoped<ICustomer, CustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


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
