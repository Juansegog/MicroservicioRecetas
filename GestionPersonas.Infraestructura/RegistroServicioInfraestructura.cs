using GestionRecetas.Application.Contratos;
using GestionRecetas.Infraestructura.Persistencia;
using GestionRecetas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionRecetas.Infraestructura
{
    public static class RegistroServicioInfraestructura
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AplicacionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UsuariosConnectionString")));

            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            return services;
        }
    }
}
