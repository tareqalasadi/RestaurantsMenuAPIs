
using Microsoft.EntityFrameworkCore;
using RestaurantsMenu.General;
using RestaurantsMenu.Repository;
try
{


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Read and decrypt the encrypted connection string
var encryptionEngine = new EncryptionEngine();

string encryptedConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
string decryptedConnectionString = encryptionEngine.Decrypt(encryptedConnectionString);

// Add Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(decryptedConnectionString));

// Register repositories and services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();


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
}
catch (Exception ex)
{

    throw;
}
