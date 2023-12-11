using BackEnd.Core.Helpers;
using BackEnd.Core.Interfaces;
using BackEnd.EF;
using BackEnd.EF.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BackEndDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepositoryApp<>), typeof(RepositoryApp<>));
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
