using Microsoft.EntityFrameworkCore;
using SmartLearn.Application;
using SmartLearn.Infrastructure;
using SmartLearn.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args); 
    builder.Services.AddOpenApi();
    builder.Services.AddControllers();
    builder. Services.AddApplicationServices()
                        .AddInfrastructureServices();

    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)); 


var app = builder.Build(); 
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

