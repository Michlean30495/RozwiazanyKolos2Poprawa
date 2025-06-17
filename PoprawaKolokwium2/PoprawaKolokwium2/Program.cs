using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2.Data;
using PoprawaKolokwium2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();