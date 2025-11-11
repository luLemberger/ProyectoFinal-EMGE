using Microsoft.EntityFrameworkCore; 
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;

using LicenciasAPI.Validators;
using LicenciasAPI.Data;
using LicenciasAPI.Services;
using LicenciasAPI.UnitOfWork;
using LicenciasAPI.Repositories;
using LicenciasAPI.Controllers;
using LicenciasAPI.Response;
using LicenciasAPI.Models;
using LicenciasAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<LicenciaValidator>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Licencias API",
        Version = "v1",
        Description = "API para gestión de licencias de suboficiales"
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ILicenciaService, LicenciaService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILicenciaRepository, LicenciaRepository>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Licencias API ");
});


app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();

//if (app.Environment.IsDevelopment())
//{
//   app.UseSwagger();
//    app.UseSwaggerUI();
//    app.UseDeveloperExceptionPage();
//}

app.UseAuthorization();
app.MapControllers();
app.Run();
