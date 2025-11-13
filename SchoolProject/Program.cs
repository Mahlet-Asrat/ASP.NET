using SchoolApi.Data;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Repositories;
using SchoolApi.Services;
using FluentValidation;
using SchoolApi.Validators;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Reflection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext (Postgres)
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseNpgsql(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositories & Services
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


builder.Services.AddValidatorsFromAssemblyContaining<CreateSchoolDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateSchoolDtoValidator>();

builder.Services.AddControllers();

// OpenAPI / Scalar
builder.Services.AddOpenApi();

var app = builder.Build();

// Dev-only UI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();            
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers into the endpoint routing system
app.MapControllers();

app.Run();
