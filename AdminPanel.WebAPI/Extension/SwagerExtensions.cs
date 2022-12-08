using Microsoft.OpenApi.Models;

namespace AdminPanel.WebAPI.Extension
{
    internal static class SwagerExtensions
    {
        internal static void AddSwagerAuthorization(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Admin paneli API",
                    Version = "v01",
                    Description = "Admin panelinin api kısmıdır ve bir araba kiralama şirketine hizmet edecektir."
                });

                opt.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme{
                        In = ParameterLocation.Header,
                        Description = "Lütfen tokenı giriniz",
                        Name = "Authorize",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"//JwtBearerDefaults.AuthenticationScheme
                    });

                var oASS = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"//JwtBearerDefaults.AuthenticationScheme,
                    }
                };

                var value = new List<String>();
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement(){{
                        oASS,
                        value
                    }
                });
            });
        }
    }
}
