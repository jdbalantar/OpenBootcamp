using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string CONNECTION = "ConnectionSQLite";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION);
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlite(connectionString));


// 7. Añadiendo el Servicio de Autorizacion JWT 
// TODO:
builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();


// 4. Añadir los servicios personalizados
// Carpeta Services
builder.Services.AddScoped<IStudentService, StudentService>();
// TODO: Añadir el resto de servicios

builder.Services.AddEndpointsApiExplorer();

// 8. Añadir Autorizacion

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// 9. Configuracion Swagger para que tenga en cuenta la autorizacion con JWT

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // Definimos la seguridad para la authorizacion
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// 5. Añadimos los CORS - Así controlamos quienes pueden hacer peticiones a nuestra API
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin(); // Cualquier aplicacion puede consumir la API
        builder.AllowAnyMethod(); // Pueden usar todos los métodos
        builder.AllowAnyHeader(); // Pueden mandar cualquier cabecera
    });
});

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

// 6. Decir a nuestra aplicacion que haga uso de CORS

app.UseCors("CorsPolicy");

app.Run();
