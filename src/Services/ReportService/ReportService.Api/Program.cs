using Microsoft.EntityFrameworkCore;
using ReportService.Business;
using ReportService.Data.Contexts;
using ReportService.Data.Repositories.Abstract;
using ReportService.Data.Repositories.Concrete.EntityFramework;
using ReportService.Entity.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddDatabaseServices();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddAutoMapper(typeof(ReportProfile));
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ReportServiceContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
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
