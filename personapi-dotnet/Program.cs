using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab 1", Version = "v1" });
});

builder.Services.AddDbContext<PersonaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDbContext"));
});

builder.Services.AddTransient<IPersonaRepository, PersonaRepository>();
builder.Services.AddTransient<IProfesionRepository, ProfesionRepository>();
builder.Services.AddTransient<ITelefonoRepository, TelefonoRepository>();
builder.Services.AddTransient<IEstudioRepository, EstudioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
