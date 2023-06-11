using PrimeStore_API.API.Middleware;
using PrimeStore_API.Application.IOC;
using PrimeStore_API.Persistence.IOC;
using PrimeStore_API.Persistence.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddResponseCompression(opt =>
{
    opt.EnableForHttps = true;
});



#region serviceRegistration
builder.Services.AddPersistenceDependency(builder.Configuration);
builder.Services.AddApplicationDependency();
#endregion
#region Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("SqlConnection"),
    tableName: "systemLog",
    appConfiguration:builder.Configuration,
    autoCreateSqlTable:true,
    columnOptionsSection:builder.Configuration.GetSection("Serilog:ColumnOptions"),
    schemaName:"dbo"
    ).CreateLogger();

builder.Host.UseSerilog(Log.Logger);
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();



app.UseSerilogRequestLogging();
app.UseAuthorization();

app.UseHealthChecks("/health");
#region Middlewares
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
#endregion

app.MapControllers();

app.Run();
