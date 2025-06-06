using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace SistemaMedicoApp.API.Configurations
{
    public class CorsConfiguration
    {
        public static void AddCorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                /*
                options.AddPolicy("SistemaMedicoPolicy", builder =>
                {
                     builder.WithOrigins("http://localhost:5183")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                           //.AllowCredentials();
                });  
                */

                options.AddPolicy("SpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5183")
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                /*
                            options.AddPolicy("AllowSpecificOrigin",
                                        policy => policy.WithOrigins("http://localhost:5183") // Altere para a origem necessária
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
                            });
                */
            });
        }

        public static void UseCorsConfiguration(IApplicationBuilder app)
        {
            //app.UseCors("SistemaMedicoPolicy");
            app.UseCors("AllowAll");
        }
    }
}
