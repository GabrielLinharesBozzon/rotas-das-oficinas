using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Persistence.Context;
using RO.DevTest.Persistence.Repositories;

namespace RO.DevTest.Persistence.IoC;

public static class PersistenceDependencyInjector
{
    /// <summary>
    /// Inject the dependencies of the Persistence layer into an
    /// <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to inject the dependencies into
    /// </param>
    /// <param name="configuration">
    /// The <see cref="IConfiguration"/> containing connection string information
    /// </param>
    /// <returns>
    /// The <see cref="IServiceCollection"/> with dependencies injected
    /// </returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly("RO.DevTest.Persistence")), ServiceLifetime.Singleton);

        services.AddScoped<IRepositorioCliente, ClienteRepository>();
        services.AddScoped<IRepositorioUsuario, UsuarioRepository>();
        services.AddScoped<IRepositorioProduto, RepositorioProduto>();

        return services;
    }
}
