using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace SistemaMedicoApp.API.Configurations
{
    /// <summary>
    /// É uma política de segurança que permite que aplicações web façam 
    /// requisições para domínios diferentes daquele de onde a aplicação 
    /// foi carregada.
    /// <summary />

    //  Em suma: Permite que o frontend (porta: 3000) em React faça requi-
    //  sições para a API do Sistema Médico(porta: 5183).  
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
                });  
                */
 
                options.AddPolicy("Frontend", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // URL do React com Vite
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// Método para executar e aplicar as configurações do CORS
        /// </summary>
        public static void UseCorsConfiguration(IApplicationBuilder app)
        {
            //app.UseCors("SistemaMedicoPolicy");
            app.UseCors("Frontend");
        }
    }
}
