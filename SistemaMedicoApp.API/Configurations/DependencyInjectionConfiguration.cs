using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Domain.Services;
using SistemaMedicoApp.Infra.Data.Repositories;

namespace SistemaMedicoApp.API.Configurations
{
    /// <summary>
    /// Classe para configuração das injeções de dependência do projeto
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            
            services.AddTransient<IExameService, ExameService>();
            services.AddTransient<IExameRepository, ExameRepository>();

            services.AddTransient<IPedidoExameService, PedidoExameService>();
            services.AddTransient<IPedidoExameRepository, PedidoExameRepository>();

            services.AddTransient<IItensPedidoExameService, ItensPedidoExameService>();
            services.AddTransient<IItensPedidoExameRepository, ItensPedidoExameRepository>();
        }
    }
}
