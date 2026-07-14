using Doccure.ReviewService.Services.ReviewServices;
using Doccure.ReviewService.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IReviewService, ReviewService>();//IBranchService gorduðunde ,BranchService çaðýr
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));//DatabaseSettingsKey appsettings.json dosyasýnda DatabaseSettingsKey olarak tanýmlanacak
builder.Services.AddSingleton<IDataBaseSettings>(sp => sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);
builder.Services.AddControllers();
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
