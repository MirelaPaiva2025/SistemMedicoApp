using Microsoft.OpenApi.Models;

namespace SistemaMedicoApp.API.Configurations
{
    /// <summary>
    /// Classe para configuração da biblioteca do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                // Verifique se você está chamando SwaggerDoc apenas uma vez com "v1".
                c.SwaggerDoc("r1", new OpenApiInfo
                {
                    Title = "Sistema Médico - Gestão de Pedidos de Exame",
                    Description = "API desenvolvida para valiação - MV Sistemas.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Mirela Paiva",
                        Email = "mirella.paiva@mv.com.br",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                    }
                });
            });

        }

        /// <summary>
        /// Método para executar e aplicar as configurações do Swagger
        /// </summary>
        public static void UseSwaggerConfiguration(IApplicationBuilder app)
        {
            app.UseSwagger();
            ///
            app.UseSwaggerUI(c =>
            {
                // Customizando o título e o tema do SwaggerUI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaMedico API v1");
                c.DocumentTitle = "Sistema Médico - Gestão de Pedidos de Exame";
            });
            /*
            app.UseSwaggerUI(c =>
            {
               c.InjectStylesheet("https://cdnjs.cloudflare.com/ajax/libs/swagger-ui/4.15.5/swagger-ui.css");

            });*/
            
        }
    }
}
