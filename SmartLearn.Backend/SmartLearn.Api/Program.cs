using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLearn.Application;
using SmartLearn.Domain.Entities;
using SmartLearn.Infrastructure;
using SmartLearn.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddApplicationServices()
    .AddInfrastructureServices();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString)); 

builder.Services.AddDataProtection();

builder.Services.AddIdentityCore<User>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();