using AutoMapper;
using Course.Catalog.API.Mappings;
using Course.Catalog.API.Models.Entities;
using Course.Catalog.API.Services;
using Course.Catalog.API.Services.Interfaces;
using Course.Catalog.API.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var config = new MapperConfiguration(x => x.AddProfile<AutoMapProfile>());
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IClassService, ClassService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();