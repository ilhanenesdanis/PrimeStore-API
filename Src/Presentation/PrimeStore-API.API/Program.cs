using PrimeStore_API.Persistence.IOC;
using PrimeStore_API.Application.IOC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapControllers();

app.Run();
