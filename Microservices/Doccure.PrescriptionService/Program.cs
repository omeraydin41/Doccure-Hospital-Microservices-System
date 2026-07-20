using Doccure.PrescriptionService.Context;
using Doccure.PrescriptionService.Services.PrescriptionService;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper Kaydý 
builder.Services.AddAutoMapper(typeof(Program));

// Prescription Service Kaydý
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();//IPrescriptionService interfacesini gorunce PrescriptionService classýna yönel

builder.Services.AddControllers();

// PostgreSQL DbContext
builder.Services.AddDbContext<PrescriptionContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// Swagger
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