using AutoMapper;
using Gestfin;
using Gestfin.Dtos;
using Gestfin.Mappers;
using Gestfin.Models;
using Gestfin.Services.Implementations;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MainDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IComunidadesService,ComunidadesService>();
builder.Services.AddScoped<IPropiedadesService,PropiedadesService>();
builder.Services.AddScoped<IPropietariosService, PropietariosService>();
builder.Services.AddScoped<IRecibosService, RecibosService>();
builder.Services.AddScoped<IRepartosService, RepartosService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
