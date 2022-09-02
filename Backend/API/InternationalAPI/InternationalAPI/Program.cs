var builder = WebApplication.CreateBuilder(args);

// 1. A�adir Localizaci�n
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Culturas (Idiomas) que la API va a soportar

var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; // Ingl�s USA - Espa�ol ESPA�A - Franc�s FRANCIA
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1])        // Espa�ol por defecto
    .AddSupportedCultures(supportedCultures)        // Aladir todas las culturas soportadas
    .AddSupportedUICultures(supportedCultures);     // A�adir culturas soportadas a UI (MVC - Views)

// 3 A�adir localizaci�n a la APP

app.UseRequestLocalization(localizationOptions);
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
