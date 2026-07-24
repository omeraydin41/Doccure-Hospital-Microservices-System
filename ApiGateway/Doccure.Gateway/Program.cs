using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//OCELOT CONFÝG.
builder.Configuration.AddJsonFile(
    // Parametre 1: "ocelot.json"
    // Konfigürasyon verilerinin okunacaðý dosyanýn adýný (veya yolunu) belirtir.
    "ocelot.json",

    optional: false,
    // Parametre 2: optional: false
    // Dosyanýn zorunlu olup olmadýðýný belirler. 'false' yazýldýðý için uygulama baþlatýlýrken
    // bu dosya bulunamazsa uygulama hata verir (exception fýrlatýr) ve çalýþmayý durdurur.

    // Parametre 3: reloadOnChange: true
    // Uygulama çalýþýr durumdayken dosya içeriði deðiþtirilirse, uygulamanýn yeniden 
    // baþlatýlmasýna gerek kalmadan yeni ayarlarýn otomatik olarak hafýzaya yüklenmesini saðlar.
    reloadOnChange: true
);

builder.Services.AddOcelot();//OCELOT EKLENDÝ 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

await app.UseOcelot();

app.MapControllers();

app.Run();
