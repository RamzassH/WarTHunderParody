using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WarThunderParody;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.DAL.Repositories;
using WarThunderParody.Service.Implementations;
using WarThunderParody.Service.Interfaces;
using System.Timers;
using Timer = System.Timers.Timer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<WarThunderShopContext>(opt =>
    opt.UseNpgsql(connection));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = false,
            // строка, представляющая издателя
            ValidIssuer = "Issuer",
            // будет ли валидироваться потребитель токена
            ValidateAudience = false,
            // установка потребителя токена
            ValidAudience = "Audience",
            // будет ли валидироваться время существования
            ValidateLifetime = false,
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IBaseRepository<Nation>, NationRepository>();
builder.Services.AddScoped<IBaseRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<Role>, RolesRepository>();
builder.Services.AddScoped<IBaseRepository<Account>, AccountRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INationService, NationService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
//WarThunderShopContext.BackupDatabase();

BackupScheduler backupScheduler = new BackupScheduler();
backupScheduler.Start();


var app = builder.Build();


app.UseCors("AllowAllOrigins");
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


public class BackupScheduler
{
    private Timer backupTimer;

    public BackupScheduler()
    {
        backupTimer = new Timer();
        backupTimer.Interval = 3600000; // 1 hour
        backupTimer.Elapsed += new ElapsedEventHandler(OnBackupTimerElapsed);
    }

    public void Start()
    {
        backupTimer.Start();
    }

    public void Stop()
    {
        backupTimer.Stop();
    }

    private void OnBackupTimerElapsed(object sender, ElapsedEventArgs e)
    {
        WarThunderShopContext.BackupDatabase();
    }
}
