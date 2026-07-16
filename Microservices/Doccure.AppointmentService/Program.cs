using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Services.AppointmentDetailService;
using Doccure.AppointmentService.Services.AppointmentService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAppointmentService, AppointmentService>();//IAppointmentService gördüðünde AppointmentService'i enjekte etmesi için DI container'a ekledik
builder.Services.AddScoped<IAppointmentDetailService, AppointmentDetailService>();//IAppointmentDetailService gördüðünde AppointmentDetailService'i enjekte etmesi için DI container'a ekledik
builder.Services.AddDbContext<AppointmentContext>();


builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
