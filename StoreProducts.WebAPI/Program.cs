using Microsoft.Data.SqlClient;
using StoreProducts.WebAPI.Repositories;
using StoreProducts.WebAPI.Repositories.Interfaces;
using StoreProducts.WebAPI.Services;
using StoreProducts.WebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("mssql");

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductRepository, ProductRepository>(options =>new ProductRepository(connectionString));
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
