using Doccure.BranchService.Services; // Ayarlarýnýn bulunduðu klasörün namespace'i
using Doccure.BranchService.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBranchService, BranchService>();//IBranchService gorduðunde ,BranchService çaðýr
builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.

// --- VERÝ TABANI AYARLARI BURAYA EKLENDÝ ---
// appsettings.json içerisindeki "DatabaseSettings" alanýný DatabaseSettings sýnýfýna baðlar
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettingsKey"));//DatabaseSettingsKey appsettings.json dosyasýnda DatabaseSettingsKey olarak tanýmlanacak

// Kod içinde IDatabaseSettings istendiðinde doldurulan bu deðerlerin teslim edilmesini saðlar
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
// ------------------------------------------

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