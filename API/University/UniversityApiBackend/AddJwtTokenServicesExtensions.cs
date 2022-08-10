using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            var bindJwtSettings = new JwtSettings();
            Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);
            Services.AddSingleton(bindJwtSettings);

            Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigingKey,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigingKey)),
                        ValidateIssuer = bindJwtSettings.ValidateIssuer,
                        ValidIssuer = bindJwtSettings.ValidIssuer,
                        ValidAudience = bindJwtSettings.ValidAudience,
                        ValidateAudience = bindJwtSettings.ValidateAudience,
                        RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
                        ValidateLifetime = bindJwtSettings.ValidateLifeTime,
                        ClockSkew = TimeSpan.FromDays(1)
                    };
                });
        }

    }
}
