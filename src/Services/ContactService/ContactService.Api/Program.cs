using ContactService.Business;
using ContactService.Data;
using ContactService.Data.Contexts;
using ContactService.Entity.AutoMapper.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddDatabaseServices();
builder.Services.AddAutoMapper(typeof(ContactProfile), typeof(UserProfile));
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ContactServiceContext>(opt =>
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
