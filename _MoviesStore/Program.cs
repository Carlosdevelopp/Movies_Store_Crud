using AutoMapper;
using DataAccess.Contract;
using DataAccess.Implementation;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<Movies, MoviesDTO>()
      .ForMember(p => p.TitleMovie, org => org.MapFrom(p => p.Title.ToUpper()))
      .ForMember(p => p.DescriptionMovie, org => org.MapFrom(p => p.Description.ToLower()));

});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
