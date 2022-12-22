using DataAccess.Contract;
using DataAccess.Implementation;
using DataAccess.Implementation.Base;
using Infrastructure.Contract;
using Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddScoped<IMoviesInfrastructure, MoviesInfrastructure>();
builder.Services.AddScoped<IMoviesDataAccess, MoviesDataAccess>();

//Conexión SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MOVIE_DB_CONNECTION")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
