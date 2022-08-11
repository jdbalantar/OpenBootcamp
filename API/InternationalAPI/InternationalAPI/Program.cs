var builder = WebApplication.CreateBuilder(args);

// 1. Añadir Localización
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Culturas (Idiomas) que la API va a soportar

var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; // Inglés USA - Español ESPAÑA - Francés FRANCIA
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1])        // Español por defecto
    .AddSupportedCultures(supportedCultures)        // Aladir todas las culturas soportadas
    .AddSupportedUICultures(supportedCultures);     // Añadir culturas soportadas a UI (MVC - Views)

// 3 Añadir localización a la APP

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
