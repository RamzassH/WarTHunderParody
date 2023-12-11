using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WarThunderParody.DAL;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.DAL.Repositories;
using WarThunderParody.Domain.Entity;
using WarThunderParody.Service.Implementations;
using WarThunderParody.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(connection));

builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IBaseRepository<Nation>, NationRepository>();
builder.Services.AddScoped<IBaseRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<Roles>, RolesRepository>();
builder.Services.AddScoped<IBaseRepository<UserRole>, UserRoleRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INationService, NationService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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