using Application.Interfaces;
using Application.UseCase;
using Application.UseCase.Peliculas;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom

var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IServiceGetAll, ServiceGetAll>();
///// inyecciones dependencias peliculas
builder.Services.AddScoped<IPeliculaService, PeliculaService>();

builder.Services.AddScoped<IPeliculaQuery, PeliculaQuery>();

builder.Services.AddScoped<IPeliculasCommand, PeliculasCommand>();

/// Inyecciones dependencias generos

builder.Services.AddScoped<IGeneroService, GeneroService>();

builder.Services.AddScoped<IGeneroQuery, GeneroQuery>();

builder.Services.AddScoped<IGenerosCommand, GenerosCommand>();

/// Inyecciones Funciones IFuncionesService

builder.Services.AddScoped<IFuncionesService, FuncionesService>();
builder.Services.AddScoped<IFuncionesCommand, FuncionesCommand>();
builder.Services.AddScoped<IFuncionesQuery, FuncionesQuery>();
builder.Services.AddScoped<ITicketCommand, TicketCommand>();
builder.Services.AddScoped<ITicketQuery, TicketQuery>();
builder.Services.AddScoped<ITicketCommand,TicketCommand>();
builder.Services.AddScoped<ISalaQuery,SalaQuery>();
builder.Services.AddScoped<ISalaService,SalaService>();
builder.Services.AddScoped<IPeliculaQuery,PeliculaQuery>();
builder.Services.AddScoped<IPeliculaService,PeliculaService>();
builder.Services.AddScoped<IGeneroQuery,GeneroQuery>();
builder.Services.AddScoped<IGeneroService,GeneroService>();
builder.Services.AddScoped<IGenerosCommand,GenerosCommand>();
builder.Services.AddScoped<IPeliculasCommand,PeliculasCommand>();


/// agregar automapper
/// 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
